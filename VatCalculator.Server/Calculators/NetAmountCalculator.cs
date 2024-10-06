namespace VatCalculator.Server.Calculators
{
    /// <summary>
    /// Calculator for calculating the gross and VAT amounts when the net amount is provided.
    /// </summary>
    public class NetAmountCalculator : IAmountCalculator
    {
        /// <summary>
        /// Calculates the gross amount and VAT based on the provided net amount and VAT rate.
        /// </summary>
        /// <param name="amount">The net amount provided as input.</param>
        /// <param name="vatRateDecimal">The VAT rate as a decimal (e.g., 0.2 for 20% VAT).</param>
        /// <param name="netAmount">The calculated net amount, which in this case is the same as the input.</param>
        /// <param name="grossAmount">The calculated gross amount (net + VAT).</param>
        /// <param name="vatAmount">The calculated VAT amount (net * vatRate).</param>
        public void CalculateAmounts(decimal amount, decimal vatRateDecimal, out decimal netAmount, out decimal grossAmount, out decimal vatAmount)
        {
            netAmount = amount;
            vatAmount = netAmount * vatRateDecimal;
            grossAmount = netAmount + vatAmount;
        }
    }
}
