namespace VatCalculator.Server.Calculators
{
    /// <summary>
    /// Calculator for calculating the net and VAT amounts when the gross amount is provided.
    /// </summary>
    public class GrossAmountCalculator : IAmountCalculator
    {
        /// <summary>
        /// Calculates the net amount and VAT based on the provided gross amount and VAT rate.
        /// </summary>
        /// <param name="amount">The gross amount provided as input.</param>
        /// <param name="vatRateDecimal">The VAT rate as a decimal (e.g., 0.2 for 20% VAT).</param>
        /// <param name="netAmount">The calculated net amount (gross / (1 + vatRate)).</param>
        /// <param name="grossAmount">The calculated gross amount, which in this case is the same as the input.</param>
        /// <param name="vatAmount">The calculated VAT amount (gross - net).</param>
        public void CalculateAmounts(decimal amount, decimal vatRateDecimal, out decimal netAmount, out decimal grossAmount, out decimal vatAmount)
        {
            grossAmount = amount;
            netAmount = grossAmount / (1 + vatRateDecimal);
            vatAmount = grossAmount - netAmount;
        }
    }

}
