using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Core
    {
        private double? _first = null;
        private double? _second = null;
        private char? _operand = null;
        private int? _decimals1 = null;
        private int? _decimals2 = null;
        private bool _negative1 = false;
        private bool _negative2 = false;

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



        public List<string> AddDigit(int digit)
        {
            if (digit < 0 || digit > 9)
                throw new ArgumentOutOfRangeException();
            if (_operand == null)
            {
                if (_first == null)
                    _first = 0;
                if (_decimals1 != null)
                {
                    _decimals1++;
                    _first = AddDigitAfter((double)_first, digit, (int)_decimals1, _negative1);
                }
                else
                {
                    _first = AddDigitBefore((double)_first, digit, _negative1);
                }
            }
            else
            {
                if (_second == null)
                    _second = 0;
                if (_decimals2 != null)
                {
                    _decimals2++;
                    _second = AddDigitAfter((double)_second, digit, (int)_decimals2, _negative2);
                }
                else
                {
                    _second = AddDigitBefore((double)_second, digit, _negative2);
                }
            }
            return new List<string>() { _first.ToString(), _second.ToString() };
        }

        public char SetOperand(char operand)
        {
            if (operand == '+' || operand == '-' || operand == '*' || operand == '/')
                _operand = operand;
            else
                throw new ArgumentException();
            return (char)_operand;
        }

        public void Clear()
        {
            _first = null;
            _second = null;
            _operand = null;
            _decimals1 = null;
            _decimals2 = null;
            _negative1 = false;
            _negative2 = false;
        }

        public string Compute()
        {
            double res = 0;

            switch (_operand)
            {
                case ('+'):
                    res = (double)(_first + _second);
                    break;
                case ('-'):
                    res = (double)(_first - _second);
                    break;
                case ('*'):
                    res = (double)(_first * _second);
                    break;
                case ('/'):
                    if (_second == 0)
                        throw new DivideByZeroException();
                    res = (double)(_first / _second);
                    break;
            }
            return res.ToString();
        }

        public List<String> Point()
        {
            string res1, res2;
            if (_second == null)
            {
                _decimals1 = 0;
                res1 = _first.ToString() + ",";
                res2 = _second.ToString();
            }
            else
            {
                _decimals2 = 0;
                res1 = _first.ToString();
                res2 = _second.ToString() + ",";
            }


            return new List<string>() { res1, res2 };
        }

        public List<string> ChangeSign()
        {
            if (_operand == null)
            {
                _negative1 = !_negative1;
                _first *= -1;
            }
            else
            {
                _negative2 = !_negative2;
                _second *= -1;
            }
            return new List<string>() { _first.ToString(), _second.ToString() };
        }
    }
}
