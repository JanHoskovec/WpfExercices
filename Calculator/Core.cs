using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Core
    {
        private Operand _first = new Operand();
        private Operand _second = new Operand();
        private char? _operator = null;


        public List<string> AddDigit(int digit)
        {
            if (_operator == null)
            {
                if (_first.Value == null)
                    _first.Initialize();
                _first.AddDigit(digit);
            }
            else
            {
                if (_second.Value == null)
                    _second.Initialize();
                _second.AddDigit(digit);
            }
            return new List<string>() { _first.Typeset(), _second.Typeset() };
        }

        public char SetOperator(char @operator)
        {
            if (@operator == '+' || @operator == '-' || @operator == '*' || @operator == '/')
                _operator = @operator;
            else
                throw new ArgumentException();
            return (char)_operator;
        }

        public void Clear()
        {
            _first = new Operand();
            _second = new Operand();
            _operator = null;
        }

        public string Compute()
        {
            double res = 0;

            switch (_operator)
            {
                case ('+'):
                    res = (double)(_first.Value + _second.Value);
                    break;
                case ('-'):
                    res = (double)(_first.Value - _second.Value);
                    break;
                case ('*'):
                    res = (double)(_first.Value * _second.Value);
                    break;
                case ('/'):
                    if (_second.Value == 0)
                        throw new DivideByZeroException();
                    res = (double)(_first.Value / _second.Value);
                    break;
            }
            return res.ToString();
        }

        public List<String> Point()
        {
            if (_operator == null)
            {
                if (_first == null)
                    _first = new Operand();
                _first.SetPoint();
            }
            else
            {
                _second.SetPoint();
            }
            return new List<string>() { _first.Typeset(), _second.Typeset() };
        }

        public List<string> ChangeSign()
        {
            if (_operator == null)
            {
                _first.ChangeSign();
            }
            else
            {
                _second.ChangeSign();
            }
            return new List<string>() { _first.Typeset(), _second.Typeset() };
        }
    }
}
