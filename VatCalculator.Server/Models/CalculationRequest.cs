using VatCalculator.Server.Enums;

namespace VatCalculator.Server.Models
{
    /// <summary>
    /// Calculation request model class.
    /// </summary>
    public class CalculationRequest
    {
        /// <summary>
        /// Gets or sets Amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets Amount type.
        /// </summary>
        public AmountType Type { get; set; }

        /// <summary>
        /// Gets or sets VAT rate.
        /// </summary>
        public decimal VatRate { get; set; }
    }

}
