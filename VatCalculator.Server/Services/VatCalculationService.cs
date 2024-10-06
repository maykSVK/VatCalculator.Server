using VatCalculator.Server.Enums;
using VatCalculator.Server.Models;
using VatCalculator.Server.Services.Interfaces;

namespace VatCalculator.Server.Services
{
    /// <summary>
    /// Implementation of VAT calculation service.
    /// </summary>
    public class VatCalculationService : IVatCalculationService
    {
        /// <summary>
        /// Calculates the net, gross, and VAT amounts based on the input request parameters.
        /// </summary>
        /// <param name="request">The input parameters for the calculation, including amount, amount type, and VAT rate.</param>
        /// <returns>A <see cref="CalculationResponse"/> object containing the calculated net, gross, and VAT amounts.</returns>
        public CalculationResponse CalculateAmounts(CalculationRequest request)
        {
            // Validations
            var validVatRates = new List<decimal> { 10m, 13m, 20m };
            if (!validVatRates.Contains(request.VatRate))
            {
                throw new ArgumentException("Invalid VAT rate. Valid rates are 10%, 13%, and 20%.");
            }

            if (request.Amount <= 0)
            {
                throw new ArgumentException($"{request.Type} amount must be greater than zero.");
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
                    vatAmount = netAmount * vatRateDecimal;
                    grossAmount = netAmount + vatAmount;
                    break;

                case AmountType.Gross:
                    grossAmount = request.Amount;
                    netAmount = grossAmount / (1 + vatRateDecimal);
                    vatAmount = grossAmount - netAmount;
                    break;

                case AmountType.Vat:
                    vatAmount = request.Amount;
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
