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

        public List<string> AddDigit(int digit)
        {
            if (digit < 0 || digit > 9)
                throw new ArgumentOutOfRangeException();
            if(_operand == null)
            {
                if (_first == null)
                    _first = 0;
                _first = 10 * _first + digit;
            }
            else
            {
                if (_second == null)
                    _second = 0;
                _second = 10 * _second + digit;
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
    }
}
