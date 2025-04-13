public class Prestamo
{
    public int LibroId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaPrestamo { get; set; }

    public override string ToString()
    {
        return $"{LibroId};{UsuarioId};{FechaPrestamo}";
    }

    public static Prestamo FromString(string linea)
    {
        var datos = linea.Split(';');
        return new Prestamo
        {
            LibroId = int.Parse(datos[0]),
            UsuarioId = int.Parse(datos[1]),
            FechaPrestamo = DateTime.Parse(datos[2])
        };
    }
}
