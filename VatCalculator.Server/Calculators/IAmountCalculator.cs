namespace VatCalculator.Server.Calculators
{
    /// <summary>
    /// Interface for calculating the net amount, gross amount, and VAT amount.
    /// Each implementation should define how these amounts are calculated based on the input amount.
    /// </summary>
    public interface IAmountCalculator
    {
        /// <summary>
        /// Calculates the net, gross, and VAT amounts based on the input amount and VAT rate.
        /// </summary>
        /// <param name="amount">The input amount, which can be either the net, gross, or VAT amount depending on the calculation type.</param>
        /// <param name="vatRateDecimal">The VAT rate as a decimal (e.g., 0.2 for 20% VAT).</param>
        /// <param name="netAmount">The calculated net amount (output).</param>
        /// <param name="grossAmount">The calculated gross amount (output).</param>
        /// <param name="vatAmount">The calculated VAT amount (output).</param>
        void CalculateAmounts(decimal amount, decimal vatRateDecimal, out decimal netAmount, out decimal grossAmount, out decimal vatAmount);
    }
}
