using System;

abstract class Figura {
    public abstract double CalcularArea();
}

class Circulo : Figura {
    public double Radio { get; set; }

    public override double CalcularArea() {
        return Math.PI * Radio * Radio;
    }
}

class Rectangulo : Figura {
    public double Ancho { get; set; }
    public double Alto { get; set; }

    public override double CalcularArea() {
        return Ancho * Alto;
    }
}

class Program {
    static void Main() {
        Figura miCirculo = new Circulo { Radio = 5 };
        Figura miRectangulo = new Rectangulo { Ancho = 4, Alto = 6 };

        Console.WriteLine($"Área del círculo: {miCirculo.CalcularArea()}");
        Console.WriteLine($"Área del rectángulo: {miRectangulo.CalcularArea()}");
    }
}
