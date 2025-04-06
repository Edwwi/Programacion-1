using System;
using System.Collections.Generic;

class Hamburguesa
{
    protected string tipoPan;
    protected string tipoCarne;
    protected double precioBase;
    protected List<(string Nombre, double Precio)> ingredientes;

    protected int maxIngredientes = 4;

    public Hamburguesa(string pan, string carne, double precio)
    {
        tipoPan = pan;
        tipoCarne = carne;
        precioBase = precio;
        ingredientes = new List<(string, double)>();
    }

    public virtual bool AgregarIngrediente(string nombre, double precio)
    {
        if (ingredientes.Count < maxIngredientes)
        {
            ingredientes.Add((nombre, precio));
            return true;
        }
        Console.WriteLine("No se pueden agregar más ingredientes.");
        return false;
    }

    public virtual void MostrarDetalle()
    {
        Console.WriteLine($"\n🍔 Hamburguesa Clásica:");
        Console.WriteLine($"Pan: {tipoPan} | Carne: {tipoCarne} | Precio Base: ${precioBase}");

        double total = precioBase;
        foreach (var ing in ingredientes)
        {
            Console.WriteLine($" + {ing.Nombre}: ${ing.Precio}");
            total += ing.Precio;
        }
        Console.WriteLine($"Total: ${total}\n");
    }
}
class HamburguesaSaludable : Hamburguesa
{
    private List<(string Nombre, double Precio)> ingredientesExtras;

    public HamburguesaSaludable(string carne, double precioBase)
        : base("Integral", carne, precioBase)
    {
        ingredientesExtras = new List<(string, double)>();
        maxIngredientes = 6; 
    }

    public override bool AgregarIngrediente(string nombre, double precio)
    {
        if (ingredientes.Count + ingredientesExtras.Count < maxIngredientes)
        {
            ingredientesExtras.Add((nombre, precio));
            return true;
        }
        Console.WriteLine("No se pueden agregar más ingredientes saludables.");
        return false;
    }

    public override void MostrarDetalle()
    {
        Console.WriteLine($"\n🥗 Hamburguesa Saludable:");
        Console.WriteLine($"Pan: {tipoPan} | Carne: {tipoCarne} | Precio Base: ${precioBase}");

        double total = precioBase;
        foreach (var ing in ingredientesExtras)
        {
            Console.WriteLine($" + {ing.Nombre}: ${ing.Precio}");
            total += ing.Precio;
        }
        Console.WriteLine($"Total: ${total}\n");
    }
}

class HamburguesaPremium : Hamburguesa
{
    public HamburguesaPremium(string pan, string carne, double precioBase)
        : base(pan, carne, precioBase)
    {
        ingredientes.Add(("Papas", 3.00));
        ingredientes.Add(("Bebida", 2.00));
        maxIngredientes = 0; // no se permite agregar más
    }

    public override bool AgregarIngrediente(string nombre, double precio)
    {
        Console.WriteLine("No se permiten ingredientes adicionales en la hamburguesa premium.");
        return false;
    }

    public override void MostrarDetalle()
    {
        Console.WriteLine($"\n🍟 Hamburguesa Premium:");
        Console.WriteLine($"Pan: {tipoPan} | Carne: {tipoCarne} | Precio Base: ${precioBase}");

        double total = precioBase;
        foreach (var ing in ingredientes)
        {
            Console.WriteLine($" + {ing.Nombre}: ${ing.Precio}");
            total += ing.Precio;
        }
        Console.WriteLine($"Total: ${total}\n");
    }
}

class Programa
{
    static void Main()
    {
        // Hamburguesa Clásica
        var clasica = new Hamburguesa("Blanco", "Res", 5.00);
        clasica.AgregarIngrediente("Lechuga", 0.50);
        clasica.AgregarIngrediente("Tomate", 0.50);
        clasica.AgregarIngrediente("Bacon", 1.00);
        clasica.AgregarIngrediente("Pepinillo", 0.50);
        clasica.MostrarDetalle();

        // Hamburguesa Saludable
        var saludable = new HamburguesaSaludable("Pollo", 6.00);
        saludable.AgregarIngrediente("Aguacate", 1.50);
        saludable.AgregarIngrediente("Espinaca", 0.75);
        saludable.AgregarIngrediente("Tofu", 1.00);
        saludable.MostrarDetalle();

        // Hamburguesa Premium
        var premium = new HamburguesaPremium("Brioche", "Angus", 8.00);
        premium.AgregarIngrediente("Cebolla caramelizada", 0.75); // No se permite
        premium.MostrarDetalle();
    }
}
