using System;
using System.Collections.Generic;

namespace Calculadora
{
    public static class SepararParentesis
    {
        public static string ParseText(string input, List<char> caracteresAceptados)
        {
            // Remove any empty characters from the input string
            // Remove any empty characters from the input string
            input = input.Replace(" ", "");
            input = input.Replace("\t", "");
            input = input.Replace("\n", "");
            input = input.Replace("\r", "");
            Console.WriteLine($"Ejercicio sin espacios: {input}\n");

            // We can use LINQ to filter out any characters that are not in the caracteresAceptados list
            string output = new string(input.Where(c => caracteresAceptados.Contains(c)).ToArray());

            if (output == "")
            {
                throw new Exception("La input contiene carácteres vacíos ó no contiene caracteres aceptados.");
            }

            return output;
        }
        // Creamos una función para revisar que la variable ejercicio no contenga:
        // más de 1 asterisco enseguida a otro, mas de 1 diagonal enseguida de otra, 
        // mas de 1 punto enseguida de otro, más de 1 exponente enseguida de otro, 
        // mas de 1, si no hay un cero enseguida de una diagonal(para que no se divida entre cero) 
        // y que cuide que no se mezcle ninguno de estos símbolos directamente entre sí
        public static bool RevisarEjercicio(string ejercicio)
        {
            // Creamos una lista con los símbolos que no deben mezclarse directamente entre sí
            List<string> simbolosNoMezclables = new List<string> { "*", "/", "^" };

            // Creamos una lista con los símbolos que no deben aparecer más de una vez seguida de otra
            List<string> simbolosNoRepetibles = new List<string> { "*", "/", ".", "^", "," };

            // Creamos una variable para almacenar el último símbolo revisado
            string ultimoSimbolo = "";

            // Creamos una variable para almacenar la cantidad de veces que se ha repetido el último símbolo
            int cantidadRepetida = 0;

            // Recorremos cada símbolo del ejercicio
            foreach (var simbolo in ejercicio)
            {
                // Si el símbolo es una diagonal y el último símbolo revisado fue un cero
                if (simbolo == '/' && ultimoSimbolo.Equals("0"))
                {
                    Console.WriteLine("El ejercicio contiene una división entre cero.");
                    return false;
                }

                // Si el símbolo es uno de los símbolos no mezclables y el último símbolo revisado también lo era
                if (simbolosNoMezclables.Contains(simbolo.ToString()) && simbolosNoMezclables.Contains(ultimoSimbolo))
                {
                    Console.WriteLine("El ejercicio contiene símbolos no mezclables directamente entre sí.");
                    return false;
                }

                // Si el símbolo es igual al último revisado
                if (simbolo.ToString() == ultimoSimbolo)
                {
                    // Si el símbolo es un paréntesis y el último símbolo también es un paréntesis, continuar la iteración
                    if ((simbolo == ')' && ultimoSimbolo == "(") || (simbolo == '(' && ultimoSimbolo == ")") || (simbolo == '(' && ultimoSimbolo == "(") || (simbolo == ')' && ultimoSimbolo == ")"))
                    {
                        continue;
                    }

                    cantidadRepetida++;

                    // Si la cantidad de veces que se ha repetido el símbolo es mayor a 1 y el símbolo no es un punto o una coma
                    if (cantidadRepetida > 1 && !simbolosNoRepetibles.Contains(simbolo.ToString()))
                    {
                        Console.WriteLine($"El ejercicio contiene más de 1 símbolo {simbolo} seguido de otro.");
                        return false;
                    }
                }
                else
                {
                    // Si el símbolo es diferente al último revisado, actualizamos las variables
                    ultimoSimbolo = simbolo.ToString();
                    cantidadRepetida = 1;
                }
            }

            // Si no se encontró ningún problema, el ejercicio es válido
            return true;
        }


        public static void Main()
        {
            // Example usage:
            // List of accepted characters
            List<char> caracteresAceptados = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '(', ')', '^', '.' };


            // Input string
            string ejercicio;
            do
            {
                Console.Write("Ingrese el ejercicio: ");
                ejercicio = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(ejercicio));


            // Call the ParseText function
            ejercicio = ParseText(ejercicio, caracteresAceptados);


            if (SepararParentesis.RevisarEjercicio(ejercicio) == false)
            {
                return;
            }


            // Output should be "abcde"
            Console.WriteLine(ejercicio);

            Console.WriteLine($"Ejercicio inicial: {ejercicio}\n");

            // Creamos una nueva lista para almacenar los pasos del proceso
            var listaSubEjercicios = new List<string>();

            //Revisamos que el ejercicio tenga misma cantidad de paréntesis izquierdos y derechos
            int countParentesisIzq = 0;
            int countParentesisDer = 0;
            foreach (var caracter in ejercicio)
            {
                if (caracter == '(')
                {
                    countParentesisIzq++;
                }
                else if (caracter == ')')
                {
                    countParentesisDer++;
                }
            }

            if (countParentesisIzq != countParentesisDer)
            {
                Console.WriteLine("La cantidad de paréntesis izquierdos y derechos no es la misma.");
                return;
            }

            //Que el ejercicio no tenga más de 6 pares de parentesis
            if (countParentesisIzq > 12)
            {
                Console.WriteLine("El ejercicio tiene más de 6 pares de paréntesis.");
                return;
            }

            foreach (var caracter in ejercicio)
            {
                // Se revisan todos los paréntesis izquierdos y derechos de la cadena, si cada par de paréntesis no tiene un operador a la izquierda del paréntesis izquierdo ni uno a la derecha del paréntesis derecho, se inserta un asterisco a la izquierda del paréntesis izquierdo
                if (caracter == '(')
                {
                    int index = ejercicio.IndexOf(caracter);
                    if (index > 0)
                    {
                        if (ejercicio[index - 1] != '+' && ejercicio[index - 1] != '-' && ejercicio[index - 1] != '*' && ejercicio[index - 1] != '/' && ejercicio[index - 1] != '^' && ejercicio[index - 1] != '(')
                        {
                            ejercicio = ejercicio.Insert(index, "*");
                        }
                    }
                }
                else if (caracter == ')')
                {
                    int index = ejercicio.IndexOf(caracter);
                    if (index < ejercicio.Length - 1)
                    {
                        if (ejercicio[index + 1] != '+' && ejercicio[index + 1] != '-' && ejercicio[index + 1] != '*' && ejercicio[index + 1] != '/' && ejercicio[index + 1] != '^' && ejercicio[index + 1] != ')')
                        {
                            ejercicio = ejercicio.Insert(index + 1, "*");
                        }
                    }
                }
                
            }

            // Mientras el ejercicio contenga paréntesis
            while (ejercicio.Contains("("))
            {
                // Se busca el último paréntesis izquierdo en el ejercicio
                int inicio = ejercicio.LastIndexOf("(");

                // Se busca el paréntesis derecho más cercano al paréntesis izquierdo anterior
                int fin = ejercicio.IndexOf(")", inicio);

                // Se extrae el string que se encuentra dentro de los paréntesis
                string dentroParentesis = ejercicio.Substring(inicio + 1, fin - inicio - 1);

                // Agregamos el string dentroParentesis a la lista de pasos
                listaSubEjercicios.Add(dentroParentesis);

                // Se reemplaza el contenido de los paréntesis por dentroParentesis en el string del ejercicio
                ejercicio = ejercicio.Remove(inicio, fin - inicio + 1);
                // Se agrega la letra correspondiente del alfabeto donde se removió el contenido de los paréntesis en el string del ejercicio
                char letra = (char)('a' + listaSubEjercicios.Count);
                ejercicio = ejercicio.Insert(inicio, letra.ToString());


                Console.WriteLine($"Se removió el siguiente string: {dentroParentesis}");
                Console.WriteLine($"Ejercicio actual: {ejercicio}\n");
            }

            //Imprimimos la lista de sub ejercicios
            Console.WriteLine("Lista de sub ejercicios:");
            foreach (var subEjercicio in listaSubEjercicios)
            {
                Console.WriteLine(subEjercicio);
                // Revisar si la letra en el subejercicio tiene un operador antes o después, si no lo tiene, agregar un asterisco
            }
            // Finalmente, imprimimos el resultado final del proceso
            Console.WriteLine($"Resultado final: {ejercicio}");

        //     Stack<double> pilaValores = new Stack<double>(); // Pila para almacenar los valores de los subejercicios
        //     Stack<char> pilaOperadores = new Stack<char>(); // Pila para almacenar los operadores de los subejercicios

        //     foreach (string subejercicio in listaSubEjercicios)
        //     {
        //         for (int i = 0; i < subejercicio.Length; i++)
        //         {
        //             char c = subejercicio[i];

        //             if (char.IsDigit(c))
        //             {
        //                 // Si el caracter es un dígito, se agrega a la pila de valores
        //                 string numeroString = c.ToString();
        //                 int j = i + 1;
        //                 while (j < subejercicio.Length && (char.IsDigit(subejercicio[j]) || subejercicio[j] == '.'))
        //                 {
        //                     numeroString += subejercicio[j];
        //                     j++;
        //                 }
        //                 i = j - 1;
        //                 double numero = double.Parse(numeroString);
        //                 pilaValores.Push(numero);
        //             }
        //             else if (c == '(')
        //             {
        //                 // Si el caracter es un paréntesis de apertura, se agrega a la pila de operadores
        //                 pilaOperadores.Push(c);
        //             }
        //             else if (c == ')')
        //             {
        //                 // Si el caracter es un paréntesis de cierre, se realizan las operaciones pendientes
        //                 while (pilaOperadores.Peek() != '(')
        //                 {
        //                     double valor2 = pilaValores.Pop();
        //                     double valor1 = pilaValores.Pop();
        //                     char operador = pilaOperadores.Pop();
        //                     double resultado = RealizarOperacion(valor1, valor2, operador);
        //                     pilaValores.Push(resultado);
        //                 }
        //                 pilaOperadores.Pop(); // Se elimina el paréntesis de apertura de la pila de operadores
        //             }
        //             else if (EsOperador(c))
        //             {
        //                 // Si el caracter es un operador, se realizan las operaciones pendientes en la pila de operadores
        //                 while (pilaOperadores.Count > 0 && PrioridadOperador(pilaOperadores.Peek()) >= PrioridadOperador(c))
        //                 {
        //                     double valor2 = pilaValores.Pop();
        //                     double valor1 = pilaValores.Pop();
        //                     char operador = pilaOperadores.Pop();
        //                     double resultado = RealizarOperacion(valor1, valor2, operador);
        //                     pilaValores.Push(resultado);
        //                 }
        //                 pilaOperadores.Push(c);
        //             }
        //         }

        //         // Se realizan las operaciones pendientes en la pila de operadores
        //         while (pilaOperadores.Count > 0)
        //         {
        //             double valor2 = pilaValores.Pop();
        //             double valor1 = pilaValores.Pop();
        //             char operador = pilaOperadores.Pop();
        //             double resultado = RealizarOperacion(valor1, valor2, operador);
        //             pilaValores.Push(resultado);
        //         }

        //         // Se muestra el resultado del subejercicio
        //         Console.WriteLine($"El resultado de '{subejercicio}' es: {pilaValores.Pop()}");
        //     }
        // }
        // // Función para determinar si un caracter es un operador
        // private static bool EsOperador(char c)
        // {
        //     return c == '+' || c == '-' || c == '*' || c == '/';
        // }

        // // Función para determinar la prioridad de un operador
        // private static int PrioridadOperador(char c)
        // {
        //     switch (c)
        //     {
        //         case '+':
        //         case '-':
        //             return 1;
        //         case '*':
        //         case '/':
        //             return 2;
        //         default:
        //             return 0;
        //     }
        // }

        // // Función para realizar una operación entre dos valores con un operador dado
        // private static double RealizarOperacion(double valor1, double valor2, char operador)
        // {
        //     switch (operador)
        //     {
        //         case '+':
        //             return valor1 + valor2;
        //         case '-':
        //             return valor1 - valor2;
        //         case '*':
        //             return valor1 * valor2;
        //         case '/':
        //             return valor1 / valor2;
        //         default:
        //             return 0;
        //     }
        }

    }
}