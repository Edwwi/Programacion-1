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

        var primos = numeros.Where(EsPrimo).ToList();
        int maxDigitosPares = primos.Select(n => ContarDigitosPares(n)).DefaultIfEmpty(-1).Max();
        int numPrimoMaxDigPares = primos.FirstOrDefault(n => ContarDigitosPares(n) == maxDigitosPares);
        int posPrimoMaxDigPares = Array.IndexOf(numeros, numPrimoMaxDigPares);

        Console.WriteLine(numPrimoMaxDigPares == 0 ? "No hay números primos con dígitos pares." : $"El número primo con más dígitos pares está en la posición: {posPrimoMaxDigPares}");
    }

    static bool EsPrimo(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
            if (num % i == 0) return false;
        return true;
    }

    static int ContarDigitosPares(int num)
    {
        return Math.Abs(num).ToString().Count(d => (d - '0') % 2 == 0);
    }
}
