namespace Numaka.VinValidator
{
    /// <summary>
    /// VIN validation result
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// VIN validation result
        /// </summary>
        /// <param name="error">VIN validation error</param>
        internal ValidationResult(ValidationError? error = null)
        {
            Error = error;
        }

        /// <summary>
        /// VIN validation error
        /// </summary>
        /// <value></value>
        public ValidationError? Error { get; }

        /// <summary>
        /// Is it a valid validation result?
        /// </summary>
        /// <returns></returns>
        public bool IsValid => !Error.HasValue;

        /// <summary>
        /// Create a valid VIN validation result
        /// </summary>
        /// <returns></returns>
        internal static ValidationResult Valid() => new ValidationResult();

        /// <summary>
        /// Create an invalid VIN validation result
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        internal static ValidationResult Invalid(ValidationError error) => new ValidationResult(error);
    }
}