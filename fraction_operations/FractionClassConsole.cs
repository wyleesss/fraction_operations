using System.Text.RegularExpressions;

namespace Fractions
{
    public partial class Fraction
    {
        public override string ToString() => $"{(_sign == '+' ? "" : _wholePart == 0 && _numerator == 0 ? "" : _sign)}" +
                               (_wholePart == 0 && _numerator != 0 ? "" 
                                : _wholePart != 0 && _numerator == 0 ? $"{_wholePart}" : $"{_wholePart} ") +
                               (_numerator == 0 ? "" : $"{_numerator}/{_denominator}");
        public static Fraction Parse(string input)
        {
            string pattern = @"^(\+|-)?(\d{1,7})(\s(\+|-)?(\d{1,5})/\d{1,5})?$|^(\+|-)?(\d{1,7})/\d{1,7}$";

            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(input))
                throw new ArgumentException("невірний формат вводу");

            Fraction Result = new Fraction();

            if (!char.IsDigit(input[0]))
            {
                Result.Sign = input[0];
                input = input.Substring(1);
            }

            if (!input.Contains('/'))
                Result.WholePart = Convert.ToInt32(input);

            else if (input.Contains('/') && !input.Contains(' '))
            {
                Result.Numerator = Convert.ToInt32(input.Substring(0, input.IndexOf('/')));
                Result.Denominator = Convert.ToInt32(input.Substring(input.IndexOf('/') + 1));
            }

            else if (input.Contains('/') && input.Contains(' '))
            {
                Result.WholePart = Convert.ToInt32(input.Substring(0, input.IndexOf(' ')));

                input = input.Substring(input.IndexOf(' ') + 1);

                Result.Numerator = Convert.ToInt32(input.Substring(0, input.IndexOf('/')));
                Result.Denominator = Convert.ToInt32(input.Substring(input.IndexOf('/') + 1));
            }

            return Result;
        }
    }
}
