
using System;
using System.Collections;

namespace ShuntingYardAlgorithm;


public class Program
{
    static void Main(string[] args)
    {
        //String exp = "12 + 34 + × 1 2 + 3 4 + ×";
        String exp = "3 4 × 5 6 × +";
        var items = getInfix(exp.Replace(" ", ""));
        string infixNotation = string.Empty;

        if (items.Count >= 1)
        {
            var i = items.ToArray();

            infixNotation = string.Join("", i);

        }
        Console.WriteLine(infixNotation);
    }

    static bool isOperand(char x)
    {
        int n;
        return int.TryParse(x.ToString(), out n);
    }


    static Stack getInfix(string exp)
    {
        Stack s = new Stack();

        for (int i = 0; i < exp.Length; i++)
        {
            // Push operands
            if (isOperand(exp[i]))
            {
                s.Push(exp[i] + "");
            }

            // We assume that input is
            // a valid postfix and expect
            // an operator.
            else
            {
                var item = exp[i];
                string op1 = (string)s.Peek();
                s.Pop();
                string op2 = (string)s.Peek();
                s.Pop();
                s.Push("(" + op2 + exp[i] +
                        op1 + ")");
            }
        }



        return s;
    }

}