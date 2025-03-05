using System;

class Persona {
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public void Presentarse() {
        Console.WriteLine($"Hola, mi nombre es {Nombre} y tengo {Edad} años.");
    }
}

class Estudiante : Persona {
    public string Carrera { get; set; }

    public void Estudiar() {
        Console.WriteLine($"{Nombre} está estudiando {Carrera}.");
    }
}

class Profesor : Persona {
    public string Materia { get; set; }

    public void Enseñar() {
        Console.WriteLine($"{Nombre} enseña {Materia}.");
    }
}

class Program {
    static void Main() {
        Estudiante estudiante = new Estudiante { Nombre = "Ana", Edad = 20, Carrera = "Ingeniería" };
        Profesor profesor = new Profesor { Nombre = "Carlos", Edad = 45, Materia = "Matemáticas" };

        estudiante.Presentarse();
        estudiante.Estudiar();

        profesor.Presentarse();
        profesor.Enseñar();
    }
}
