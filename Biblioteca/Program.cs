using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static string archivoLibros = "libros.txt";
    static string archivoUsuarios = "usuarios.txt";
    static string archivoPrestamos = "prestamos.txt";

    static List<Libro> libros = new List<Libro>();
    static List<Usuario> usuarios = new List<Usuario>();
    static List<Prestamo> prestamos = new List<Prestamo>();

    static void Main()
    {
        CargarDatos();

        int opcion;
        do
        {
            Console.WriteLine("\n--- SISTEMA DE BIBLIOTECA ---");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Registrar usuario");
            Console.WriteLine("3. Listar libros");
            Console.WriteLine("4. Prestar libro");
            Console.WriteLine("5. Devolver libro");
            Console.WriteLine("6. Ver préstamos");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: RegistrarLibro(); break;
                case 2: RegistrarUsuario(); break;
                case 3: ListarLibros(); break;
                case 4: PrestarLibro(); break;
                case 5: DevolverLibro(); break;
                case 6: VerPrestamos(); break;
            }

        } while (opcion != 0);

        GuardarDatos();
    }

    static void RegistrarLibro()
    {
        Console.Write("Título del libro: ");
        string titulo = Console.ReadLine();
        Console.Write("Autor: ");
        string autor = Console.ReadLine();

        int id = libros.Any() ? libros.Max(l => l.Id) + 1 : 1;
        libros.Add(new Libro { Id = id, Titulo = titulo, Autor = autor, Disponible = true });
        Console.WriteLine("Libro registrado con éxito.");
    }

    static void RegistrarUsuario()
    {
        Console.Write("Nombre del usuario: ");
        string nombre = Console.ReadLine();

        int id = usuarios.Any() ? usuarios.Max(u => u.Id) + 1 : 1;
        usuarios.Add(new Usuario { Id = id, Nombre = nombre });
        Console.WriteLine("Usuario registrado con éxito.");
    }

    static void ListarLibros()
    {
        Console.WriteLine("\n--- LISTA DE LIBROS ---");
        foreach (var libro in libros)
        {
            string estado = libro.Disponible ? "Disponible" : "Prestado";
            Console.WriteLine($"[{libro.Id}] {libro.Titulo} - {libro.Autor} ({estado})");
        }
    }

    static void PrestarLibro()
    {
        ListarLibros();
        Console.Write("ID del libro a prestar: ");
        int libroId = int.Parse(Console.ReadLine());

        var libro = libros.FirstOrDefault(l => l.Id == libroId && l.Disponible);
        if (libro == null)
        {
            Console.WriteLine("Libro no disponible.");
            return;
        }

        Console.WriteLine("\n--- LISTA DE USUARIOS ---");
        foreach (var u in usuarios)
            Console.WriteLine($"[{u.Id}] {u.Nombre}");

        Console.Write("ID del usuario: ");
        int usuarioId = int.Parse(Console.ReadLine());

        var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioId);
        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        prestamos.Add(new Prestamo { LibroId = libro.Id, UsuarioId = usuario.Id, FechaPrestamo = DateTime.Now });
        libro.Disponible = false;
        Console.WriteLine("Libro prestado con éxito.");
    }

    static void DevolverLibro()
    {
        Console.Write("ID del libro a devolver: ");
        int libroId = int.Parse(Console.ReadLine());

        var libro = libros.FirstOrDefault(l => l.Id == libroId);
        var prestamo = prestamos.FirstOrDefault(p => p.LibroId == libroId);

        if (libro != null && prestamo != null)
        {
            prestamos.Remove(prestamo);
            libro.Disponible = true;
            Console.WriteLine("Libro devuelto con éxito.");
        }
        else
        {
            Console.WriteLine("No se encontró préstamo para ese libro.");
        }
    }

    static void VerPrestamos()
    {
        Console.WriteLine("\n--- PRÉSTAMOS ACTIVOS ---");
        foreach (var p in prestamos)
        {
            var libro = libros.FirstOrDefault(l => l.Id == p.LibroId);
            var usuario = usuarios.FirstOrDefault(u => u.Id == p.UsuarioId);
            Console.WriteLine($"Libro: {libro?.Titulo} - Usuario: {usuario?.Nombre} - Fecha: {p.FechaPrestamo}");
        }
    }

    static void CargarDatos()
    {
        if (File.Exists(archivoLibros))
            libros = File.ReadAllLines(archivoLibros).Select(Libro.FromString).ToList();

        if (File.Exists(archivoUsuarios))
            usuarios = File.ReadAllLines(archivoUsuarios).Select(Usuario.FromString).ToList();

        if (File.Exists(archivoPrestamos))
            prestamos = File.ReadAllLines(archivoPrestamos).Select(Prestamo.FromString).ToList();
    }

    static void GuardarDatos()
    {
        File.WriteAllLines(archivoLibros, libros.Select(l => l.ToString()));
        File.WriteAllLines(archivoUsuarios, usuarios.Select(u => u.ToString()));
        File.WriteAllLines(archivoPrestamos, prestamos.Select(p => p.ToString()));
    }
}
