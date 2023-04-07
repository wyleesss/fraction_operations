namespace Fractions
{
    public partial class Fraction
    {
        protected int _wholePart;
        public int WholePart
        {
            get => _wholePart;
            set
            {
                if (value < 0)
                {
                    if (_sign == '+')
                        _sign = '-';

                    _wholePart = value *= -1;
                }

                else
                    _wholePart = value;
            }
        }

        protected int _numerator;
        public int Numerator
        {
            get => _numerator;
            set
            {
                if (value < 0)
                {
                    if (_sign == '-')
                        _sign = '+';

                    else
                        _sign = '-';

                    _numerator = value *= -1;
                }

                else
                    _numerator = value;
            }
        }

        protected int _denominator;
        public int Denominator
        {
            get => _denominator;
            set
            {
                if (value == 0)
                    throw new ArgumentException("знаменник не може дорівнювати 0");

                if (value < 0)
                {
                    if (_sign == '-')
                        _sign = '+';

                    else
                        _sign = '-';

                    _denominator = value *= -1;
                }

                else
                    _denominator = value;
            }
        }

        protected char _sign;
        public char Sign
        {
            get => _sign;
            set
            {
                if (value != '+' && value != '-')
                    throw new ArgumentException("знак дробу недопустимий");

                _sign = value;
            }
        }

        public Fraction()
        {
            _sign = '+';
            _numerator = 0;
            _denominator = 1;
            _wholePart = 0;
        }

        public Fraction(int numerator, int denominator, int wholePart = 0, char sign = '+')
        {
            Sign = sign;
            Numerator = numerator;
            Denominator = denominator;
            WholePart = wholePart;
        }
    }
}