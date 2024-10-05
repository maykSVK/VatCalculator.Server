namespace VatCalculator.Server.Models
{
    using VatCalculator.Server.Enums;

    /// <summary>
    /// Represents the request model for performing VAT calculations.
    /// This model is used to pass the necessary input data for the calculation.
    /// </summary>
    public class CalculationRequest
    {
        /// <summary>
        /// Gets or sets the monetary amount for the calculation depending on the <see cref="Type"/>.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the type of amount (Net, Gross, or VAT) being passed for calculation.
        /// </summary>
        public AmountType Type { get; set; }

        /// <summary>
        /// Gets or sets the VAT rate as a decimal percentage.a
        /// </summary>
        public decimal VatRate { get; set; }
    }
}
