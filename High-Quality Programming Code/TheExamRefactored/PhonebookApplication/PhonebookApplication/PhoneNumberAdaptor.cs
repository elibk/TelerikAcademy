namespace PhonebookApplication
{
    using System;
    using System.Linq;
    using System.Text;

    public static class PhoneNumberAdaptor
    {
        public const string CountryCode = "+359";

        public static string ParseToAdaptedPhoneNumber(string phoneNumber)
        {
            //// fixed bottle neck - useless reapeting of parse. The more commands -> more slowly, because the parsing was
            //// repeted as many times as the charecters in the output count.
            StringBuilder result = new StringBuilder();

            foreach (char symbol in phoneNumber)
            {
                if (char.IsDigit(symbol) || (symbol == '+'))
                {
                    result.Append(symbol);
                }
            }

            if (result.Length >= 2 && result[0] == '0' && result[1] == '0')
            {
                result.Remove(0, 1);
                result[0] = '+';
            }

            while (result.Length > 0 && result[0] == '0')
            {
                result.Remove(0, 1);
            }

            if (result.Length > 0 && result[0] != '+')
            {
                result.Insert(0, CountryCode);
            }

            return result.ToString();
        }
    }
}
