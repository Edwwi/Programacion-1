using System;

interface IVolar {
    void Volar();
}

interface INadar {
    void Nadar();
}

class Pato : IVolar, INadar {
    public void Volar() {
        Console.WriteLine("El pato está volando.");
    }

    public void Nadar() {
        Console.WriteLine("El pato está nadando.");
    }
}

class Program {
    static void Main() {
        Pato miPato = new Pato();
        miPato.Volar();
        miPato.Nadar();
    }
}
