using System;
using System.Collections.Generic;

// Abstract Expression
interface IExpression
{
    int Interpret();
}

// Terminal Expression
class NumberExpression : IExpression
{
    private int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public int Interpret()
    {  return _number;
    }
      
}

// Non-terminal Expression
class AddExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret()
    {
        return _left.Interpret() + _right.Interpret();
    }
}

class Program
{
    static void Main2(string[] args)
    {
        // Creating terminal expressions
        IExpression number1 = new NumberExpression(5);
        IExpression number2 = new NumberExpression(10);

        // Creating non-terminal expression
        IExpression addExpression = new AddExpression(number1, number2);

        // Interpreting the expression
        int result = addExpression.Interpret();
        Console.WriteLine("Result: " + result); // Output: Result: 15
    }
}

//The Program class creates instances of terminal and non-terminal expressions and
//then interprets the expression by invoking the Interpret method. The result is printed to the console.