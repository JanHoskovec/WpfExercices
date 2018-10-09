using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Core
    {
        private double _first = 0;
        private double _second = 0;
        private char? _operand = null;

        public string AddDigit(int digit)
        {
            if (digit < 0 || digit > 9)
                throw new ArgumentOutOfRangeException();
            string result = "";
            if(_operand == null)
            { 
                _first = 10 * _first + digit;
                result = _first.ToString();
            }
            else
            {
                _second = 10 * _second + digit;
                result = _second.ToString();
            }
            return result;
        }

        public char SetOperand(char operand)
        {
            if (operand == '+' || operand == '-' || operand == '*' || operand == '/')
                _operand = operand;
            else
                throw new ArgumentException();
            return (char)_operand;
        }
    }
}
