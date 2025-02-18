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

        int maxPrimo = numeros.Where(EsPrimo).DefaultIfEmpty(int.MinValue).Max();
        int maxPrimoIndex = Array.IndexOf(numeros, maxPrimo);

        Console.WriteLine(maxPrimo == int.MinValue ? "No hay números primos." : $"El mayor número primo está en la posición: {maxPrimoIndex}");
    }

    static bool EsPrimo(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
            if (num % i == 0) return false;
        return true;
    }
}
