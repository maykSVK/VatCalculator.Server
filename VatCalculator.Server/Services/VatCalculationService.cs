using VatCalculator.Server.Calculators;
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
            var vatRateDecimal = request.VatRate / 100m;

            // Get the appropriate calculator based on the amount type
            var calculator = AmountCalculatorFactory.GetCalculator(request.Type);
            calculator.CalculateAmounts(request.Amount, vatRateDecimal, out decimal netAmount, out decimal grossAmount, out decimal vatAmount);

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
