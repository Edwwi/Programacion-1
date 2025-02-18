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

        int[] digitosPrimos = { 2, 3, 5, 7 };
        int conteoDigitoPrimo = numeros.Count(n => digitosPrimos.Contains(Math.Abs(n).ToString()[0] - '0'));

        Console.WriteLine($"Cantidad de números que comienzan con un dígito primo: {conteoDigitoPrimo}");
    }
}
