using System.Globalization;

namespace Calculadora
{
    public static class PEMDAS
    {
        public static string CalcularExpresion(string expresion)
        {
            // Mientras que la expresión contenga "^", se seguirá ejecutando el código
            while (expresion.Contains("^"))
            {
                // Se obtiene el índice de la primera ocurrencia de "^"
                int indice = expresion.IndexOf("^");

                // Se obtiene el índice del primer número a la izquierda de "^"
                int indiceNumeroIzquierda = indice - 1;
                while (indiceNumeroIzquierda >= 0 && (char.IsDigit(expresion[indiceNumeroIzquierda]) || expresion[indiceNumeroIzquierda] == '.'))
                {
                    indiceNumeroIzquierda--;
                }
                indiceNumeroIzquierda++;

                // Se obtiene el índice del primer número a la derecha de "^"
                int indiceNumeroDerecha = indice + 1;
                while (indiceNumeroDerecha < expresion.Length && (char.IsDigit(expresion[indiceNumeroDerecha]) || expresion[indiceNumeroDerecha] == '.'))
                {
                    indiceNumeroDerecha++;
                }
                indiceNumeroDerecha--;

                // Se usan los índices para obtener los números a la izquierda y derecha de "^"
                double numeroIzquierda;
                if (!double.TryParse(expresion.Substring(indiceNumeroIzquierda, indice - indiceNumeroIzquierda), NumberStyles.Float, CultureInfo.InvariantCulture, out numeroIzquierda))
                {

                    Console.WriteLine("La expresión es muy grande para calcular o es negativa. Intenta de nuevo con un número más pequeño o expresión diferente.");

                    // Cerrar el programa
                    Environment.Exit(1);
                }
                double numeroDerecha;
                if (!double.TryParse(expresion.Substring(indice + 1, indiceNumeroDerecha - indice), NumberStyles.Float, CultureInfo.InvariantCulture, out numeroDerecha))
                {

                    Console.WriteLine("La expresión es muy grande para calcular o es negativa. Intenta de nuevo con un número más pequeño o expresión diferente.");
                    // Cerrar el programa
                    Environment.Exit(1);
                }

                // Se calcula el resultado de la operación
                double resultado = Math.Pow(numeroIzquierda, numeroDerecha);

                // Se reemplaza la operación por el resultado en la expresión
                expresion = expresion.Replace($"{numeroIzquierda}^{numeroDerecha}", resultado.ToString(CultureInfo.InvariantCulture));
            }

            // Mientras que la expresión contenga "*", se seguirá ejecutando el código
            while (expresion.Contains("*"))
            {
                // Se obtiene el índice de la primera ocurrencia de "*"
                int indice = expresion.IndexOf("*");

                // Se obtiene el índice del primer número a la izquierda de "*"
                int indiceNumeroIzquierda = indice - 1;
                while (indiceNumeroIzquierda >= 0 && (char.IsDigit(expresion[indiceNumeroIzquierda]) || expresion[indiceNumeroIzquierda] == '.'))
                {
                    indiceNumeroIzquierda--;
                }
                indiceNumeroIzquierda++;

                // Se obtiene el índice del primer número a la derecha de "*"
                int indiceNumeroDerecha = indice + 1;
                while (indiceNumeroDerecha < expresion.Length && (char.IsDigit(expresion[indiceNumeroDerecha]) || expresion[indiceNumeroDerecha] == '.'))
                {
                    indiceNumeroDerecha++;
                }
                indiceNumeroDerecha--;

                // Se usan los índices para obtener los números a la izquierda y derecha de "*"
                double numeroIzquierda;
                if (!double.TryParse(expresion.Substring(indiceNumeroIzquierda, indice - indiceNumeroIzquierda), NumberStyles.Float, CultureInfo.InvariantCulture, out numeroIzquierda))
                {

                    Console.WriteLine("La expresión es muy grande para calcular o es negativa. Intenta de nuevo con un número más pequeño o expresión diferente.");

                    // Cerrar el programa
                    Environment.Exit(1);
                }
                double numeroDerecha;
                if (!double.TryParse(expresion.Substring(indice + 1, indiceNumeroDerecha - indice), NumberStyles.Float, CultureInfo.InvariantCulture, out numeroDerecha))
                {

                    Console.WriteLine("La expresión es muy grande para calcular o es negativa. Intenta de nuevo con un número más pequeño o expresión diferente.");
                    // Cerrar el programa
                    Environment.Exit(1);
                }

                // Se calcula el resultado de la operación
                double resultado = numeroIzquierda * numeroDerecha;

                // Se reemplaza la operación por el resultado en la expresión
                expresion = expresion.Replace($"{numeroIzquierda}*{numeroDerecha}", resultado.ToString(CultureInfo.InvariantCulture));
            }
            // Mientras que la expresión contenga "/", se seguirá ejecutando el código
            while (expresion.Contains("/"))
            {
                // Se obtiene el índice de la primera ocurrencia de "/"
                int indice = expresion.IndexOf("/");

                // Se obtiene el índice del primer número a la izquierda de "/"
                int indiceNumeroIzquierda = indice - 1;
                while (indiceNumeroIzquierda >= 0 && (char.IsDigit(expresion[indiceNumeroIzquierda]) || expresion[indiceNumeroIzquierda] == '.'))
                {
                    indiceNumeroIzquierda--;
                }
                indiceNumeroIzquierda++;

                // Se obtiene el índice del primer número a la derecha de "/"
                int indiceNumeroDerecha = indice + 1;
                while (indiceNumeroDerecha < expresion.Length && (char.IsDigit(expresion[indiceNumeroDerecha]) || expresion[indiceNumeroDerecha] == '.'))
                {
                    indiceNumeroDerecha++;
                }
                indiceNumeroDerecha--;

                // Se usan los índices para obtener los números a la izquierda y derecha de "/"
                double numeroIzquierda;
                if (!double.TryParse(expresion.Substring(indiceNumeroIzquierda, indice - indiceNumeroIzquierda), NumberStyles.Float, CultureInfo.InvariantCulture, out numeroIzquierda))
                {

                    Console.WriteLine("La expresión es muy grande para calcular o es negativa. Intenta de nuevo con un número más pequeño o expresión diferente.");

                    // Cerrar el programa
                    Environment.Exit(1);
                }
                double numeroDerecha;
                if (!double.TryParse(expresion.Substring(indice + 1, indiceNumeroDerecha - indice), NumberStyles.Float, CultureInfo.InvariantCulture, out numeroDerecha))
                {

                    Console.WriteLine("La expresión es muy grande para calcular o es negativa. Intenta de nuevo con un número más pequeño o expresión diferente.");
                    // Cerrar el programa
                    Environment.Exit(1);
                }

                // Se calcula el resultado de la operación
                double resultado = numeroIzquierda / numeroDerecha;

                // Se reemplaza la operación por el resultado en la expresión
                expresion = expresion.Replace($"{numeroIzquierda}/{numeroDerecha}", resultado.ToString(CultureInfo.InvariantCulture));
            }
            // Mientras que la expresión contenga "+", se seguirá ejecutando el código
            while (expresion.Contains("+"))
            {
                // Se obtiene el índice de la primera ocurrencia de "+"
                int indice = expresion.IndexOf("+");

                // Se obtiene el índice del primer número a la izquierda de "+"
                int indiceNumeroIzquierda = indice - 1;
                while (indiceNumeroIzquierda >= 0 && (char.IsDigit(expresion[indiceNumeroIzquierda]) || expresion[indiceNumeroIzquierda] == '.'))
                {
                    indiceNumeroIzquierda--;
                }
                indiceNumeroIzquierda++;

                // Se obtiene el índice del primer número a la derecha de "+"
                int indiceNumeroDerecha = indice + 1;
                while (indiceNumeroDerecha < expresion.Length && (char.IsDigit(expresion[indiceNumeroDerecha]) || expresion[indiceNumeroDerecha] == '.'))
                {
                    indiceNumeroDerecha++;
                }
                indiceNumeroDerecha--;

                // Se usan los índices para obtener los números a la izquierda y derecha de "+"
                double numeroIzquierda;
                if (!double.TryParse(expresion.Substring(indiceNumeroIzquierda, indice - indiceNumeroIzquierda), NumberStyles.Float, CultureInfo.InvariantCulture, out numeroIzquierda))
                {

                    Console.WriteLine("La expresión es muy grande para calcular o es negativa. Intenta de nuevo con un número más pequeño o expresión diferente.");

                    // Cerrar el programa
                    Environment.Exit(1);
                }
                double numeroDerecha;
                if (!double.TryParse(expresion.Substring(indice + 1, indiceNumeroDerecha - indice), NumberStyles.Float, CultureInfo.InvariantCulture, out numeroDerecha))
                {

                    Console.WriteLine("La expresión es muy grande para calcular o es negativa. Intenta de nuevo con un número más pequeño o expresión diferente.");
                    // Cerrar el programa
                    Environment.Exit(1);
                }
                // Se calcula el resultado de la operación
                double resultado = numeroIzquierda + numeroDerecha;

                // Se reemplaza la operación por el resultado en la expresión
                expresion = expresion.Replace($"{numeroIzquierda}+{numeroDerecha}", resultado.ToString(CultureInfo.InvariantCulture));
            }
            // Mientras que la expresión contenga "-", se seguirá ejecutando el código
            while (expresion.Contains("-"))
            {
                // Se obtiene el índice de la primera ocurrencia de "-"
                int indice = expresion.IndexOf("-");

                // Se obtiene el índice del primer número a la izquierda de "-"
                int indiceNumeroIzquierda = indice - 1;
                while (indiceNumeroIzquierda >= 0 && (char.IsDigit(expresion[indiceNumeroIzquierda]) || expresion[indiceNumeroIzquierda] == '.'))
                {
                    indiceNumeroIzquierda--;
                }
                indiceNumeroIzquierda++;

                // Se obtiene el índice del primer número a la derecha de "-"
                int indiceNumeroDerecha = indice + 1;
                while (indiceNumeroDerecha < expresion.Length && (char.IsDigit(expresion[indiceNumeroDerecha]) || expresion[indiceNumeroDerecha] == '.'))
                {
                    indiceNumeroDerecha++;
                }
                indiceNumeroDerecha--;

                // Se usan los índices para obtener los números a la izquierda y derecha de "-"
                double numeroIzquierda;
                if (!double.TryParse(expresion.Substring(indiceNumeroIzquierda, indice - indiceNumeroIzquierda), NumberStyles.Float, CultureInfo.InvariantCulture, out numeroIzquierda))
                {

                    Console.WriteLine("La expresión es muy grande para calcular o es negativa. Intenta de nuevo con un número más pequeño o expresión diferente.");

                    // Cerrar el programa
                    Environment.Exit(1);
                }
                double numeroDerecha;
                if (!double.TryParse(expresion.Substring(indice + 1, indiceNumeroDerecha - indice), NumberStyles.Float, CultureInfo.InvariantCulture, out numeroDerecha))
                {

                    Console.WriteLine("La expresión es muy grande para calcular o es negativa. Intenta de nuevo con un número más pequeño o expresión diferente.");
                    // Cerrar el programa
                    Environment.Exit(1);
                }

                // Se calcula el resultado de la operación
                double resultado = numeroIzquierda - numeroDerecha;

                // Se reemplaza la operación por el resultado en la expresión
                expresion = expresion.Replace($"{numeroIzquierda}-{numeroDerecha}", resultado.ToString(CultureInfo.InvariantCulture));
            }
            // Se regresa el resultado de la expresión
            return expresion;
        }
        // Función para revisar que la variable ejercicio no contenga caracteres vacíos y que solo contenga caracteres aceptados
        public static string ParseText(string input, List<char> caracteresAceptados)
        {
            // Se eliminan los espacios, tabuladores, saltos de línea y retorno de carro
            input = input.Replace(" ", "");
            input = input.Replace("\t", "");
            input = input.Replace("\n", "");
            input = input.Replace("\r", "");
            Console.WriteLine($"Ejercicio sin espacios: {input}\n");

            // Se eliminan los caracteres que no estén en la lista de caracteres aceptados
            string output = new string(input.Where(c => caracteresAceptados.Contains(c)).ToArray());

            if (output == "")
            {
                throw new Exception("La input contiene carácteres vacíos ó no contiene caracteres aceptados.");
            }

            return output;
        }

        // Función para revisar que la variable ejercicio no contenga:
        // más de 1 asterisco enseguida a otro, mas de 1 diagonal enseguida de otra, 
        // mas de 1 punto enseguida de otro, más de 1 exponente enseguida de otro, 
        // mas de 1, si no hay un cero enseguida de una diagonal(para que no se divida entre cero) 
        // y que cuide que no se mezcle ninguno de estos símbolos directamente entre sí
        public static bool RevisarEjercicio(string ejercicio)
        {
            // Creamos una lista con los símbolos que no deben mezclarse directamente entre sí
            List<string> simbolosNoMezclables = new List<string> { "*", "/", "^" };

            // Creamos una lista con los símbolos que no deben aparecer más de una vez seguida de otra
            List<string> simbolosNoRepetibles = new List<string> { "*", "/", ".", "^" };

            // Creamos una variable para almacenar el último símbolo revisado
            string ultimoSimbolo = "";

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

                // Si el símbolo es diferente al último revisado, actualizamos las variables
                if (simbolo.ToString() != ultimoSimbolo)
                {
                    // Si el símbolo no es uno de los símbolos previamente establecidos, lo saltamos y continuamos la iteración
                    if (!simbolosNoRepetibles.Contains(simbolo.ToString()))
                    {
                        ultimoSimbolo = simbolo.ToString();
                        continue;
                    }
                    ultimoSimbolo = simbolo.ToString();
                }
                else
                {
                    // Si el símbolo es igual al último revisado y es un paréntesis, continuar la iteración
                    if (simbolo == ')' || simbolo == '(')
                    {
                        continue;
                    }
                    // Si el símbolo es igual al último revisado y no es uno de los símbolos previamente establecidos, lo saltamos y continuamos la iteración
                    if (!simbolosNoRepetibles.Contains(simbolo.ToString()))
                    {
                        continue;
                    }
                    Console.WriteLine($"El ejercicio contiene más de 1 símbolo {simbolo} seguido de otro.");
                    return false;
                }
            }
            // Si no se encontró ningún problema, el ejercicio es válido
            return true;
        }

        // Función para corregir la regla de signos en el ejercicio
        public static string CorregirReglaDeSignos(string ejercicio)
        {
            bool hayRepetidos = true;
            // Mientras haya símbolos repetidos, seguir corrigiendo
            while (hayRepetidos)
            {
                hayRepetidos = false;
                int indice = 0;
                while (indice < ejercicio.Length - 1)
                {
                    if ((ejercicio[indice] == '-' && ejercicio[indice + 1] == '-') ||
                        (ejercicio[indice] == '+' && ejercicio[indice + 1] == '+'))
                    {
                        ejercicio = ejercicio.Remove(indice, 2);
                        ejercicio = ejercicio.Insert(indice, "+");
                        hayRepetidos = true;
                    }
                    else if (ejercicio[indice] == '-' && ejercicio[indice + 1] == '+')
                    {
                        ejercicio = ejercicio.Remove(indice, 2);
                        ejercicio = ejercicio.Insert(indice, "-");
                        hayRepetidos = true;
                    }
                    else if (ejercicio[indice] == '+' && ejercicio[indice + 1] == '-')
                    {
                        ejercicio = ejercicio.Remove(indice, 2);
                        ejercicio = ejercicio.Insert(indice, "-");
                        hayRepetidos = true;
                    }
                    indice++;
                }
            }
            return ejercicio;
        }

        // Main del programa
        public static void Main()
        {
            Console.WriteLine("Te damos la bienvenida a la calculadora de PEMDAS. Cuide de no ingresar expresiones con resultados complejos y/o negativos.");
            Console.WriteLine("-----------------------------");

            // Lista de caracteres aceptados
            List<char> caracteresAceptados = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '(', ')', '^', '.' };

            // Pedimos el ejercicio al usuario y nos aseguramos que no esté vacío
            string ejercicio;
            do
            {
                Console.Write("Ingrese el ejercicio: ");
                ejercicio = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(ejercicio));

            Console.WriteLine("-----------------------------");


            // Revisamos que el ejercicio no contenga caracteres no aceptados y lo corregimos
            ejercicio = ParseText(ejercicio, caracteresAceptados);
            Console.WriteLine("-----------------------------");

            // Corregimos de acuerdo a la regla de signos
            ejercicio = PEMDAS.CorregirReglaDeSignos(ejercicio);
            Console.WriteLine($"Ejercicio corregido de acuerdo a la regla de signos: {ejercicio}\n");

            // Revisamos que el ejercicio sea válido
            if (PEMDAS.RevisarEjercicio(ejercicio) == false)
            {
                return;
            }

            Console.WriteLine("-----------------------------");
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
                Console.WriteLine("La cantidad de paréntesis izquierdos y derechos no es la misma. Corrija el ejercicio e intente de nuevo.");
                return;
            }

            //Que el ejercicio no tenga más de 6 pares de parentesis
            if (countParentesisIzq > 12)
            {
                Console.WriteLine("El ejercicio tiene más de 6 pares de paréntesis. Corrija el ejercicio e intente de nuevo.");
                return;
            }

            // Eliminar paréntesis al principio y al final
            if (ejercicio[0] == '(' && ejercicio[ejercicio.Length - 1] == ')')
            {
                ejercicio = ejercicio.Substring(1, ejercicio.Length - 2);
            }

            // Se modifica la expresión para que no haya paréntesis junto a números
            string result = "";
            for (int i = 0; i < ejercicio.Length; i++)
            {
                char c = ejercicio[i];
                if (c == '(' && i > 0 && char.IsLetterOrDigit(ejercicio[i - 1]))
                {
                    result += "*" + c;
                }
                else if (c == ')' && i < ejercicio.Length - 1 && char.IsLetterOrDigit(ejercicio[i + 1]))
                {
                    result += c + "*";
                }
                else
                {
                    result += c;
                }
            }

            ejercicio = result;
            Console.WriteLine("Expresión con asteriscos añadidos: " + ejercicio);
            Console.WriteLine("-----------------------------");

            // Mientras el ejercicio contenga paréntesis
            Dictionary<char, string> diccionarioSubEjercicios = new Dictionary<char, string>();
            char letra = 'a';
            // Se repite el proceso mientras el ejercicio contenga paréntesis
            while (ejercicio.Contains("("))
            {
                // Se busca el último paréntesis izquierdo en el ejercicio
                int inicio = ejercicio.LastIndexOf("(");

                // Se busca el paréntesis derecho más cercano al paréntesis izquierdo anterior
                int fin = ejercicio.IndexOf(")", inicio);

                // Se extrae el string que se encuentra dentro de los paréntesis
                string dentroParentesis = ejercicio.Substring(inicio + 1, fin - inicio - 1);

                // Se agrega el subejercicio al diccionario con la letra indicadora actual
                diccionarioSubEjercicios.Add(letra, dentroParentesis);

                // Se reemplaza el contenido de los paréntesis por dentroParentesis en el string del ejercicio
                ejercicio = ejercicio.Remove(inicio, fin - inicio + 1);

                // Se agrega la letra correspondiente del alfabeto donde se removió el contenido de los paréntesis en el string del ejercicio
                ejercicio = ejercicio.Insert(inicio, letra.ToString());

                // Incrementa la letra para el siguiente subejercicio
                letra = (char)(letra + 1);

                Console.WriteLine($"Se removió el siguiente subejercicio: {dentroParentesis}");
                Console.WriteLine($"Ejercicio actualizado: {ejercicio}\n");
                Console.WriteLine("-----------------------------");
            }

            // Imprimir el diccionario en pantalla
            Console.WriteLine("Diccionario de subejercicios:");
            foreach (KeyValuePair<char, string> subEjercicio in diccionarioSubEjercicios)
            {
                Console.WriteLine($"{subEjercicio.Key}: {subEjercicio.Value}");
                // Se reemplaza el contenido del subejercicio por el resultado de la operación
                ejercicio = ejercicio.Replace(subEjercicio.Key.ToString(), PEMDAS.CalcularExpresion(subEjercicio.Value));
            }

            Console.WriteLine("-----------------------------");

            // Imprimir la expresión corregida
            Console.WriteLine($"Ejercicio final: {ejercicio}");

            // Se revisa que el ejercicio sea válido
            if (RevisarEjercicio(ejercicio) == false)
            {
                return;
            }

            // Se imprime el resultado final
            Console.WriteLine("Resultado:" + PEMDAS.CalcularExpresion(ejercicio));
        }

    }
}