using VatCalculator.Server.Models;

namespace VatCalculator.Server.Services.Interfaces
{
    /// <summary>
    /// VAT Calculation service interface.
    /// </summary>
    public interface IVatCalculationService
    {
        /// <summary>
        /// Calcualates amounts.
        /// </summary>
        /// <param name="request">Calculation input parameters.</param>
        /// <returns>Object with calculation results.</returns>
        CalculationResponse CalculateAmounts(CalculationRequest request);
    }
}
