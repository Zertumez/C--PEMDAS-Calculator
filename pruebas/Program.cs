using System;
using System.Collections.Generic;

class Program
{
    static double EvaluateExpression(string expression)
    {
        double result = 0;
        string[] tokens = expression.Split(' ');
        
        double currentNumber = 0;
        string currentOperator = "+";
        
        for (int i = 0; i < tokens.Length; i++)
        {
            string token = tokens[i];
            
            if (double.TryParse(token, out currentNumber))
            {
                switch (currentOperator)
                {
                    case "+":
                        result += currentNumber;
                        break;
                    case "-":
                        result -= currentNumber;
                        break;
                    case "*":
                        result *= currentNumber;
                        break;
                    case "/":
                        result /= currentNumber;
                        break;
                    case "^":
                        result = Math.Pow(result, currentNumber);
                        break;
                }
            }
            else
            {
                currentOperator = token;
            }
        }
        
        return result;
    }
    
    static void Main(string[] args)
    {
        Console.Write("Ingrese el ejercicio: ");
        string input = Console.ReadLine();

        // Eliminar espacios y convertir a lista de caracteres
        List<char> expression = new List<char>(input.Replace(" ", ""));

        // Stack para manejar los paréntesis
        Stack<int> stack = new Stack<int>();

        // Recorrer la expresión
        for (int i = 0; i < expression.Count; i++)
        {
            char c = expression[i];

            if (c == '(')
            {
                stack.Push(i);
            }
            else if (c == ')')
            {
                int startIndex = stack.Pop();
                int endIndex = i;

                // Obtener subexpresión entre los paréntesis
                List<char> subExpression = expression.GetRange(startIndex + 1, endIndex - startIndex - 1);

                // Evaluar la subexpresión y reemplazar por el resultado
                double subResult = EvaluateExpression(string.Join("", subExpression));
                expression.RemoveRange(startIndex, endIndex - startIndex + 1);
                expression.InsertRange(startIndex, subResult.ToString().ToCharArray());
                i = startIndex + subResult.ToString().Length - 1;
            }
        }

        // Convertir lista de caracteres a string
        string finalExpression = string.Join("", expression);

        // Evaluar la expresión completa y mostrar resultado
        double finalResult = EvaluateExpression(finalExpression);
        Console.WriteLine("Resultado final: " + finalResult);
    }
}
