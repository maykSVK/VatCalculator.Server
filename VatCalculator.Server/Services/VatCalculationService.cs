using VatCalculator.Server.Enums;
using VatCalculator.Server.Models;
using VatCalculator.Server.Services.Interfaces;

namespace VatCalculator.Server.Services
{
    /// <summary>
    /// Implementation of VAT Calculation service.
    /// </summary>
    public class VatCalculationService : IVatCalculationService
    {
        /// <summary>
        /// Calcualates amounts.
        /// </summary>
        /// <param name="request">Calculation input parameters.</param>
        /// <returns>Object with calculation results.</returns>
        public CalculationResponse CalculateAmounts(CalculationRequest request)
        {
            // Validate VAT rate
            var validVatRates = new List<decimal> { 10m, 13m, 20m };
            if (!validVatRates.Contains(request.VatRate))
            {
                throw new ArgumentException("Invalid VAT rate. Valid rates are 10%, 13%, and 20%.");
            }

            // Convert VAT rate from percentage to decimal
            decimal vatRateDecimal = request.VatRate / 100m;

            decimal netAmount = 0m;
            decimal grossAmount = 0m;
            decimal vatAmount = 0m;

            // Perform calculations based on the provided amount and type
            switch (request.Type)
            {
                case AmountType.Net:
                    netAmount = request.Amount;
                    if (netAmount <= 0)
                    {
                        throw new ArgumentException("Net amount must be greater than zero.");
                    }

                    vatAmount = netAmount * vatRateDecimal;
                    grossAmount = netAmount + vatAmount;
                    break;

                case AmountType.Gross:
                    grossAmount = request.Amount;
                    if (grossAmount <= 0)
                    {
                        throw new ArgumentException("Gross amount must be greater than zero.");
                    }

                    netAmount = grossAmount / (1 + vatRateDecimal);
                    vatAmount = grossAmount - netAmount;
                    break;

                case AmountType.Vat:
                    vatAmount = request.Amount;
                    if (vatAmount <= 0)
                    {
                        throw new ArgumentException("VAT amount must be greater than zero.");
                    }

                    netAmount = vatAmount / vatRateDecimal;
                    grossAmount = netAmount + vatAmount;
                    break;

                default:
                    throw new ArgumentException("Invalid amount type provided.");
            }

            // Round amounts to two decimal places
            return new CalculationResponse
            {
                NetAmount = Math.Round(netAmount, 2, MidpointRounding.AwayFromZero),
                GrossAmount = Math.Round(grossAmount, 2, MidpointRounding.AwayFromZero),
                VatAmount = Math.Round(vatAmount, 2, MidpointRounding.AwayFromZero)
            };
        }
    }

}
