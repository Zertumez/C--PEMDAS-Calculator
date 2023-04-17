using System;
using System.Text.RegularExpressions;
using System.Data;

public class Program
{
    public static void Main()
    {
        // Se inicializan las variables
        string input;
        string separador = "--------------------------------------------------------------------";
        bool esValido = false;

        // Expresión regular para verificar que la entrada solo contiene números y operadores matemáticos
        string pattern = @"^[0-9+\-*/\s]+$";

        // Expresión regular para buscar doble '/' o '*'
        string doubleOpPattern = @"[/|*]{2}";

        // Expresión regular para buscar si hay un operador al principio o final del string
        string opStartEndPattern = @"^[/|*+\-]|[*/+-]$";

        // El programa se repetirá hasta que la operación cumpla con los requerimientos
        while (esValido == false)
        {
            // Se pide la input como string
            Console.WriteLine("Introduce tu operación a calcular:");
            Console.WriteLine(separador);
            input = Console.ReadLine();

            if (Regex.IsMatch(input, pattern))
            {
                // Comprueba si la entrada tiene * enseguida de un /, o viceversa (*/ ó /*)
                if (input.Contains("*/") || input.Contains("/*"))
                {
                    Console.WriteLine("No puede haber un / junto a un *, ni un * junto a un /. Intente de nuevo.");
                }
                // Comprueba si la entrada tiene dobles operadores matemáticos juntos(como "//" o "**")
                else if (Regex.IsMatch(input, doubleOpPattern))
                {
                    Console.WriteLine("La entrada contiene doble operador matemático. Intente de nuevo.");
                    Console.WriteLine(separador);
                }
                // Comprueba si la entrada tiene operadores matemáticos al principio o al final
                else if (Regex.IsMatch(input, opStartEndPattern))
                {
                    Console.WriteLine("La entrada contiene un operador al principio o final del string. Intente de nuevo.");
                    Console.WriteLine(separador);
                }
                // Comprueba si la entrada tiene espacios
                else if (input.Contains(" "))
                {
                    Console.WriteLine("No puede contener espacios. Intente de nuevo.");
                }
                // Comprueba si la entrada tiene divisiones entre 0
                else if (input.Contains("/0"))
                {
                    Console.WriteLine("No se puede dividir entre cero. Intente de nuevo.");
                }
                // Si cumple todos los requisitos, se hace la operación
                else
                {
                    string value = new DataTable().Compute(input, null).ToString();
                    Console.WriteLine("El resultado es: " + value);
                    esValido = true;
                }
            }
            // Comprueba si la entrada tiene solo los carácteres permitidos
            else
            {
                Console.WriteLine("La entrada contiene caracteres no permitidos. Intente de nuevo.");
                Console.WriteLine(separador);
            }
        }
    }
}
