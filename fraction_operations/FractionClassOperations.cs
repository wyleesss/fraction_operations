using static Processes.GCDAndLCMFunctions;
using static Processes.SwapFunctions;

namespace Fractions
{
    public partial class Fraction
    { 
        public bool IsImproper() => _numerator > _denominator;

        public bool IsMixed() => _wholePart != 0;

        public bool IsInteger() => _numerator % _denominator == 0;

        public float ToFloat() => (float)_numerator / _denominator + _wholePart; 

        public Fraction Reduce()
        {
            int _GCD = GCD(_numerator, _denominator);
            _numerator /= _GCD;
            _denominator /= _GCD;

            return this;
        }

        public Fraction SeparateWholePart()
        {
            _wholePart += _numerator / _denominator;
            _numerator %= _denominator;

            return this;
        }

        public Fraction RemoveWholePart()
        {
            _numerator += _wholePart * _denominator;
            _wholePart = 0;

            return this;
        }

        public Fraction Reverse()
        {
            if (IsMixed())
                RemoveWholePart();

            Swap<int>(ref _numerator, ref _denominator);

            Reduce();

            if (IsImproper())
                SeparateWholePart();

            return this;
        }

        public Fraction ReduceToLCD(ref Fraction other)
        {
            int _LCM = LCM(_denominator, other._denominator);

            int thisAdditionalMultiplier = _LCM / _denominator;
            int otherAdditionalMultiplier = _LCM / other._denominator;

            _numerator *= thisAdditionalMultiplier;
            _denominator *= thisAdditionalMultiplier;

            other._numerator *= otherAdditionalMultiplier;
            other._denominator *= otherAdditionalMultiplier;

            return this;
        }

        static void ReduceToLCD(ref Fraction ff, ref Fraction fs) => ff.ReduceToLCD(ref fs);
        
        static public Fraction operator + (Fraction ff, Fraction fs)
        {
            if (ff._sign == '-' && fs._sign == '+')
            {
                ff._sign = '+';

                Fraction ExResult = ff - fs;
                ExResult._sign = '-';

                return ExResult;
            }

            if (ff._sign == '+' && fs._sign == '-')
            {
                fs._sign = '+';

                return ff - fs;
            }

            if (ff._sign == '-' && fs._sign == '-')
            {
                ff._sign = '+';
                fs._sign = '+';

                Fraction ExResult = ff + fs;
                ExResult._sign = '-';

                return ExResult;
            }

            if (ff.IsMixed())
                ff.RemoveWholePart();

            if (fs.IsMixed())
                fs.RemoveWholePart();
            
            //ReduceToLCD(ref ff, ref fs);

            Fraction Result = new Fraction(ff._numerator + fs._numerator, ff._denominator);

            Result.Reduce();

            if (Result.IsImproper()) 
                Result.SeparateWholePart();

            return Result;
        }

        static public Fraction operator - (Fraction ff, Fraction fs)
        {
            if (ff._sign == '-' && fs._sign == '+')
            {
                ff._sign = '+';

                Fraction ExResult = ff + fs;
                ExResult._sign = '-';

                return ExResult;
            }

            if (ff._sign == '+' && fs._sign == '-')
            {
                fs._sign = '+';

                return ff + fs;
            }

            if (ff._sign == '-' && fs._sign == '-')
            {
                ff._sign = '+';
                fs._sign = '+';

                Fraction ExResult = ff - fs;
                ExResult._sign = '-';

                return ExResult;
            }

            if (ff.IsMixed())
                ff.RemoveWholePart();

            if (fs.IsMixed())
                fs.RemoveWholePart();

            ReduceToLCD(ref ff, ref fs);

            Fraction Result = new Fraction(ff._numerator - fs._numerator, ff._denominator);

            Result.Reduce();

            if (Result.IsImproper())
                Result.SeparateWholePart();

            return Result;
        }

        static public Fraction operator * (Fraction ff, Fraction fs)
        {
            if (ff.IsMixed())
                ff.RemoveWholePart();

            if (fs.IsMixed())
                fs.RemoveWholePart();

            Fraction Result = new Fraction(ff._numerator * fs._numerator, ff._denominator * fs._denominator);

            Result.Reduce();

            if (Result.IsImproper())
                Result.SeparateWholePart();

            if ((ff._sign == '-' && fs._sign == '+') || (ff._sign == '+' && fs._sign == '-'))
                Result._sign = '-';

            return Result;
        }

        static public Fraction operator / (Fraction ff, Fraction fs)
        {
            return ff * fs.Reverse();
        }
    }
}