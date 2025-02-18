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

        int maxPar = numeros.Where(n => n % 2 == 0).DefaultIfEmpty(int.MinValue).Max();
        int maxParIndex = Array.IndexOf(numeros, maxPar);

        Console.WriteLine(maxPar == int.MinValue ? "No hay números pares." : $"El mayor número par está en la posición: {maxParIndex}");
    }
}
