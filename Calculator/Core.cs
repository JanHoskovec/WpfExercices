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

        private double ComputeInner()
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
                default: // here, the operator is not set yet = we only have the first operand set
                    res = (double)_first.Value;
                    break;
            }
            return res;
        }

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

        public List<string> SetOperator(char _operator)
        {
            if (_operator == '+' || _operator == '-' || _operator == '*' || _operator == '/')
            {
                if(this._operator != null)
                {
                    _first.Value = ComputeInner();
                    _second = new Operand();
                }
                this._operator = _operator;
            }
            else
                throw new ArgumentException();
            return new List<string>() { _first.Typeset(), this._operator.ToString(), _second.Typeset() } ;
        }

        public void Clear()
        {
            _first = new Operand();
            _second = new Operand();
            _operator = null;
        }

        public string Compute()
        {
            double res = ComputeInner();
            Clear();
            return res.ToString();
        }

        public List<String> Point()
        {
            if (_operator == null)
            {
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

        public List<string> Percent()
        {
            if(_operator == null)
            {
                _first.Percent();
            }
            else
            {
                _second.Percent();
            }
            return new List<string>() { _first.Typeset(), _second.Typeset() };
        }
    }
}
