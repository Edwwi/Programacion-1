using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numeros = new int[10];
        Console.WriteLine("Ingrese 10 números enteros:");

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        int maxIndex = Array.IndexOf(numeros, numeros.Max());
        Console.WriteLine($"El mayor número está en la posición: {maxIndex}");
    }
}
