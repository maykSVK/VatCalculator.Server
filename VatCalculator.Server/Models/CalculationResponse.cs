namespace VatCalculator.Server.Models
{
    /// <summary>
    /// Calculation response model class.
    /// </summary>
    public class CalculationResponse
    {
        /// <summary>
        /// Gets or sets Net Amount.
        /// </summary>
        public decimal NetAmount { get; set; }

        /// <summary>
        /// Gets or sets Gross Amount.
        /// </summary>
        public decimal GrossAmount { get; set; }

        /// <summary>
        /// Gets or sets VAT Amount.
        /// </summary>
        public decimal VatAmount { get; set; }
    }

}
