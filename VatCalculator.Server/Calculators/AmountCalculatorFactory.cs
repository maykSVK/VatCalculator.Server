using VatCalculator.Server.Enums;

namespace VatCalculator.Server.Calculators
{
    /// <summary>
    /// Factory that returns the appropriate calculator based on the provided amount type.
    /// </summary>
    public class AmountCalculatorFactory
    {
        /// <summary>
        /// Gets the calculator for the specified amount type (Net, Gross, or VAT).
        /// </summary>
        /// <param name="type">The type of amount (Net, Gross, or VAT).</param>
        /// <returns>An instance of IAmountCalculator specific to the amount type.</returns>
        public static IAmountCalculator GetCalculator(AmountType type)
        {
            return type switch
            {
                AmountType.Net => new NetAmountCalculator(),
                AmountType.Gross => new GrossAmountCalculator(),
                AmountType.Vat => new VatAmountCalculator(),
                _ => throw new ArgumentException("Invalid amount type provided.")
            };
        }
    }

}
