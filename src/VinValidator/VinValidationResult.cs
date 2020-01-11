namespace Numaka.VinValidator
{
    /// <summary>
    /// VIN validation result
    /// </summary>
    public class VinValidationResult
    {
        /// <summary>
        /// VIN validation result
        /// </summary>
        /// <param name="error">VIN validation error</param>
        internal VinValidationResult(VinValidationError? error = null)
        {
            Error = error;
        }

        /// <summary>
        /// VIN validation error
        /// </summary>
        /// <value></value>
        public VinValidationError? Error { get; }

        /// <summary>
        /// Is it a valid validation result?
        /// </summary>
        /// <returns></returns>
        public bool IsValid => !Error.HasValue;

        /// <summary>
        /// Create a valid VIN validation result
        /// </summary>
        /// <returns></returns>
        internal static VinValidationResult Valid() => new VinValidationResult();

        /// <summary>
        /// Create an invalid VIN validation result
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        internal static VinValidationResult Invalid(VinValidationError error) => new VinValidationResult(error);
    }
}