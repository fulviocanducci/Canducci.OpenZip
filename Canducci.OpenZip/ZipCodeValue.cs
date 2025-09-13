namespace Canducci.OpenZip
{
    /// <summary>
    /// Represents a ZIP code value that ensures a valid format with exactly 8 numeric digits.
    /// </summary>
    /// <remarks>This class provides methods for parsing and validating ZIP code strings, ensuring they
    /// conform to the expected format. Instances of <see cref="ZipCodeValue"/> are immutable once created.</remarks>
    public sealed class ZipCodeValue
    {
        internal ZipCodeValue(string number)
        {
            Number = number;
        }

        public string Number { get; private set; }

        /// <summary>
        /// Attempts to parse the specified string into a <see cref="ZipCodeValue"/> object.
        /// </summary>
        /// <remarks>The input string is considered valid if it can be converted to a numeric
        /// representation with exactly 8 digits. If the input is invalid, the method returns <see langword="false"/>
        /// and sets <paramref name="zipCodeValue"/> to <see langword="null"/>.</remarks>
        /// <param name="value">The string representation of the zip code to parse. Must not be null or empty.</param>
        /// <param name="zipCodeValue">When this method returns, contains the parsed <see cref="ZipCodeValue"/> if the parsing succeeded;
        /// otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the string was successfully parsed into a <see cref="ZipCodeValue"/>; otherwise,
        /// <see langword="false"/>.</returns>
        public static bool TryParse(string value, out ZipCodeValue zipCodeValue)
        {
            zipCodeValue = null;
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            string number = value.ToNumber();
            if (number.Length != 8)
            {
                return false;
            }
            zipCodeValue = new ZipCodeValue(number);
            return true;
        }

        /// <summary>
        /// Parses the specified string representation of a ZIP code into a <see cref="ZipCodeValue"/> object.
        /// </summary>
        /// <param name="value">The string representation of the ZIP code to parse.</param>
        /// <returns>A <see cref="ZipCodeValue"/> object that represents the parsed ZIP code.</returns>
        /// <exception cref="System.FormatException">Thrown if the <paramref name="value"/> is not a valid ZIP code format.</exception>
        public static ZipCodeValue Parse(string value)
        {
            if (TryParse(value, out ZipCodeValue zipCodeValue))
            {
                return zipCodeValue;
            }
            throw new System.FormatException("Invalid ZipCode");
        }

        public static implicit operator string(ZipCodeValue zipCodeValue)
        {
            return zipCodeValue.Number;
        }

        public static implicit operator ZipCodeValue(string value)
        {
            return Parse(value);
        }
    }
}
