// Herencia Si
using System;

class Vehiculo {
    public string Marca { get; set; }
    public int Año { get; set; }

    public void MostrarInfo() {
        Console.WriteLine($"Marca: {Marca}, Año: {Año}");
    }
}

class Coche : Vehiculo {
    public int Puertas { get; set; }

    public void MostrarCoche() {
        MostrarInfo();
        Console.WriteLine($"Número de puertas: {Puertas}");
    }
}

class Program {
    static void Main() {
        Coche miCoche = new Coche { Marca = "Toyota", Año = 2022, Puertas = 4 };
        miCoche.MostrarCoche();
    }
}
