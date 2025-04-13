public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public bool Disponible { get; set; }

    public override string ToString()
    {
        return $"{Id};{Titulo};{Autor};{Disponible}";
    }

    public static Libro FromString(string linea)
    {
        var datos = linea.Split(';');
        return new Libro
        {
            Id = int.Parse(datos[0]),
            Titulo = datos[1],
            Autor = datos[2],
            Disponible = bool.Parse(datos[3])
        };
    }
}
