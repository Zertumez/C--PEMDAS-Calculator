using System;
using System.Collections.Generic;

namespace Calculadora
{
    public static class SepararParentesis
    {
        public static void Main()
        {
            string ejercicio = "4-2*((12-4)+3+1)";
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
            if (countParentesisIzq > 6)
            {
                Console.WriteLine("El ejercicio tiene más de 6 pares de paréntesis.");
                return;
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
                
                Console.WriteLine($"Se removió el siguiente string: {dentroParentesis}");
                Console.WriteLine($"Ejercicio actual: {ejercicio}\n");
            }

            //Imprimimos la lista de sub ejercicios
            Console.WriteLine("Lista de sub ejercicios:");
            foreach (var subEjercicio in listaSubEjercicios)
            {
                Console.WriteLine(subEjercicio);
            }
            // Finalmente, imprimimos el resultado final del proceso
            Console.WriteLine($"Resultado final: {ejercicio}");
        }
    }
}