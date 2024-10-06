namespace VatCalculator.Server.Calculators
{
    /// <summary>
    /// Calculator for calculating the net and gross amounts when the VAT amount is provided.
    /// </summary>
    public class VatAmountCalculator : IAmountCalculator
    {
        /// <summary>
        /// Calculates the net amount and gross amount based on the provided VAT amount and VAT rate.
        /// </summary>
        /// <param name="amount">The VAT amount provided as input.</param>
        /// <param name="vatRateDecimal">The VAT rate as a decimal (e.g., 0.2 for 20% VAT).</param>
        /// <param name="netAmount">The calculated net amount (VAT / vatRate).</param>
        /// <param name="grossAmount">The calculated gross amount (net + VAT).</param>
        /// <param name="vatAmount">The calculated VAT amount, which in this case is the same as the input.</param>
        public void CalculateAmounts(decimal amount, decimal vatRateDecimal, out decimal netAmount, out decimal grossAmount, out decimal vatAmount)
        {
            vatAmount = amount;
            netAmount = vatAmount / vatRateDecimal;
            grossAmount = netAmount + vatAmount;
        }
    }

}
