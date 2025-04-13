public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public override string ToString()
    {
        return $"{Id};{Nombre}";
    }

    public static Usuario FromString(string linea)
    {
        var datos = linea.Split(';');
        return new Usuario
        {
            Id = int.Parse(datos[0]),
            Nombre = datos[1]
        };
    }
}
