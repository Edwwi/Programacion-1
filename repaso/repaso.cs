using System;
using System.Collections.Generic;

class Bus
{
    public string Nombre { get; set; }
    public int Capacidad { get; set; }
    public int Pasajeros { get; set; }
    public int Precio { get; set; }

    public Bus(string nombre, int capacidad, int precio)
    {
        Nombre = nombre;
        Capacidad = capacidad;
        Precio = precio;
        Pasajeros = 0;
    }

    public void VenderPasaje(int cantidad)
    {
        if (Pasajeros + cantidad <= Capacidad)
        {
            Pasajeros += cantidad;
        }
        else
        {
            Console.WriteLine($"No hay suficientes asientos disponibles en el {Nombre}.");
        }
    }

    public int CalcularVentas()
    {
        return Pasajeros * Precio;
    }

    public int AsientosDisponibles()
    {
        return Capacidad - Pasajeros;
    }

    public void MostrarResumen()
    {
        Console.WriteLine($"Auto Bus {Nombre} {Pasajeros} Pasajeros Ventas {CalcularVentas()}, quedan {AsientosDisponibles()} asientos disponibles");
    }
}

class Programa
{
    static void Main()
    {
        Bus bus1 = new Bus("Plantinum", 22, 1000);
        Bus bus2 = new Bus("Gold", 15, 1333);

        bus1.VenderPasaje(5);  // Ejemplo: 5 pasajeros
        bus2.VenderPasaje(3);  // Ejemplo: 3 pasajeros

        Console.WriteLine("\n--- Resultado ---");
        bus1.MostrarResumen();
        bus2.MostrarResumen();
    }
}
