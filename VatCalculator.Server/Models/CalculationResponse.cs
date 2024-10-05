namespace VatCalculator.Server.Models
{
    /// <summary>
    /// Represents the response model for VAT calculations.
    /// </summary>
    public class CalculationResponse
    {
        /// <summary>
        /// Gets or sets the calculated net amount.
        /// </summary>
        public decimal NetAmount { get; set; }

        /// <summary>
        /// Gets or sets the calculated gross amount.
        /// </summary>
        public decimal GrossAmount { get; set; }

        /// <summary>
        /// Gets or sets the calculated VAT amount.
        /// </summary>
        public decimal VatAmount { get; set; }
    }
}
