namespace Numaka.VinValidator
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// VIN Validator
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validate a vehicle identification number
        /// </summary>
        /// <param name="vin">The vehicle identification number</param>
        /// <returns>Validation result</returns>
        public static ValidationResult Validate(string vin)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(vin))
                {
                    return ValidationResult.Invalid(ValidationError.NullOrEmpty);
                }

                if (vin.Length != 17)
                {
                    return ValidationResult.Invalid(ValidationError.InvalidLength);
                }

                if (!Regex.IsMatch(vin, "[A-HJ-NPR-Z0-9]{13}[0-9]{4}"))
                {
                    return ValidationResult.Invalid(ValidationError.InvalidPattern);
                }

                if (GetCheckDigit(vin) != vin[8])
                {
                    return ValidationResult.Invalid(ValidationError.InvalidCheckDigit);
                }

                return ValidationResult.Valid();
            }
            catch
            {
                return ValidationResult.Invalid(ValidationError.Unknown);
            }
        }

        /// <summary>
        /// Algorithm: https://en.wikipedia.org/wiki/Vehicle_identification_number#Check-digit_calculation
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        private static char GetCheckDigit(string vin)
        {
            int Transliterate(char c) => "0123456789.ABCDEFGH..JKLMN.P.R..STUVWXYZ".IndexOf(c) % 10;

            var map = "0123456789X";
            var weights = "8765432X098765432";
            var sum = 0;

            for (var i = 0; i < 17; ++i)
            {
                sum += Transliterate(vin[i]) * map.IndexOf(weights[i]);
            }

            return map[sum % 11];
        }
    }
}