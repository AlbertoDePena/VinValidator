namespace Numaka.VinValidator
{
    /// <summary>
    /// VIN validation error
    /// </summary>
    public enum ValidationError
    {
        /// Unknown
        Unknown = 0,
        /// VIN is null or empty
        NullOrEmpty = 1,
        /// VIN length (17)
        InvalidLength = 2,
        /// VIN pattern
        InvalidPattern = 3,
        /// VIN check digit
        InvalidCheckDigit = 4
    }
}