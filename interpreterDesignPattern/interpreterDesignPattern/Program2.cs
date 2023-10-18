using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpreterDesignPattern
{
    interface IExpression2
    {
        string Interpret();
    }

    class StringExpression : IExpression2
    {
        private string _value;

        public StringExpression(string value)
        {
            _value = value;
        }

        public string Interpret()
        {
            return _value;
        }
    }

    class AddExpression : IExpression2
    {
        private IExpression2 _left;
        private IExpression2 _right;
        public AddExpression(IExpression2 left, IExpression2 right)
        {
            _left = left;
            _right = right;
        }

        public string Interpret()
        {
            return _left.Interpret() + _right.Interpret();
        } 
    }

    class Program2
    {
        static void Main(string[] args)
        {
            IExpression2 str1 = new StringExpression("Pranav ");
            IExpression2 str2 = new StringExpression("Kulkarni");

            IExpression2 addStr = new AddExpression(str1, str2);

            string result = addStr.Interpret();
            Console.WriteLine(result);
        }
    }
}
