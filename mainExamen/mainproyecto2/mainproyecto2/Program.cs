using System;
using calculadorapemdas;

public class Program
{
    public static void Main(string[] args)
    {
        PEMDAS calculadora = new PEMDAS();

        // Ejercicio a poner (1+2(3/4)+3+(5*1)2+1(4)2)
        double resultadoEjercicio = calculadora.PemdasCalcular();

        Console.WriteLine("-------------------------------");
        Console.WriteLine("FUERA DE LA FUNCIÓN, DE REGRESO EN EL MAIN.");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Ejercicio: (1+2(3/4)+3+(5*1)2+1(4)2)");
        Console.WriteLine("Resultado: "+resultadoEjercicio);

    }
}