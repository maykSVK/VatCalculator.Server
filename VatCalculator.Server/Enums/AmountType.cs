namespace VatCalculator.Server.Enums
{
    /// <summary>
    /// Specifies the type of amount used in VAT calculations.
    /// </summary>
    public enum AmountType
    {
        /// <summary>
        /// Represents an unknown amount type. This is the default value.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Represents the net amount, which is the value before VAT is applied.
        /// </summary>
        Net = 1,

        /// <summary>
        /// Represents the gross amount, which is the total value including VAT.
        /// </summary>
        Gross = 2,

        /// <summary>
        /// Represents the VAT amount, which is the tax applied on the net amount.
        /// </summary>
        Vat = 3,
    }
}
