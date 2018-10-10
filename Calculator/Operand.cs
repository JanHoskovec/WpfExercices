using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Operand
    {
        public double? Value { get; set; } = null;
        private int? _decimals = null;
        private bool _negative = false;

        private double AddDigitBefore(double x, int digit, bool negative)
        {
            if (negative)
                x = 10 * x - digit;
            else
                x = 10 * x + digit;
            return x;
        }

        private double AddDigitAfter(double x, int digit, int pos, bool negative)
        {
            if (negative)
                x -= digit * Math.Pow(10, -pos);
            else
                x += digit * Math.Pow(10, -pos);
            return x;
        }

        public void Initialize()
        {
            Value = 0;
        }

        public void AddDigit(int digit)
        {
            if (digit < 0 || digit > 9)
                throw new ArgumentOutOfRangeException();

            if (_decimals != null)
            {
                _decimals++;
                Value = AddDigitAfter((double)Value, digit, (int)_decimals, _negative);
            }
            else
            {
                Value = AddDigitBefore((double)Value, digit, _negative);
            }
        }

        public void ChangeSign()
        {
            _negative = !_negative;
            Value *= -1;
        }

        public void SetPoint()
        {
            _decimals = 0;

        }

        public void Percent()
        {
            Value *= 0.01;
        }
        
        public string Typeset()
        {
            string res = "";
            if (_decimals == 0)
                res = Value.ToString() + ",";
            else if (Value != null)
                res = Value.ToString();
            return res;
        }
    }
}
