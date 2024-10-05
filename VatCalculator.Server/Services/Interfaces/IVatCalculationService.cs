namespace VatCalculator.Server.Services.Interfaces
{
    using VatCalculator.Server.Models;

    /// <summary>
    /// Interface for VAT calculation services.
    /// </summary>
    public interface IVatCalculationService
    {
        /// <summary>
        /// Calculates the net, gross, and VAT amounts based on the input request parameters.
        /// </summary>
        /// <param name="request">The input parameters for the calculation, including amount, amount type, and VAT rate.</param>
        /// <returns>A <see cref="CalculationResponse"/> object containing the calculated net, gross, and VAT amounts.</returns>
        CalculationResponse CalculateAmounts(CalculationRequest request);
    }
}
