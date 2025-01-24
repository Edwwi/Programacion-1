using System;

class Program
{
    public static void Main(string[] args)
    {
        int year;
        year = Convert.ToInt32(Console.ReadLine());

        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
        {
            Console.WriteLine("Es bisiesto");
        }
        else
        {
            Console.WriteLine("No es bisiesto");
        }

        Console.ReadKey();
    }
}
