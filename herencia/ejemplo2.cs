//Polimorfismo
//El polimorfismo es una característica de la programación orientada a objetos que permite a los objetos de diferentes clases responder al mismo mensaje de manera distinta.
using System; 

class Animal {
    public virtual void HacerSonido() {
        Console.WriteLine("Sonido genérico de un animal.");
    }
}

class Perro : Animal {
    public override void HacerSonido() {
        Console.WriteLine("El perro ladra: ¡Guau guau!");
    }
}

class Program {
    static void Main() {
        Animal miAnimal = new Perro();
        miAnimal.HacerSonido();
    }
}
