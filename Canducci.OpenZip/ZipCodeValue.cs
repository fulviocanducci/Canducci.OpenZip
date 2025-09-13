namespace Canducci.OpenZip
{
    public sealed class ZipCodeValue
    {
        internal ZipCodeValue(string number)
        {
            Number = number;
        }

        public string Number { get; private set; }

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
