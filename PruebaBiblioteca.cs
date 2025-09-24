using System;
using System.Collections.Generic;

namespace Biblioteca
{
    /// <summary>
    /// Clase de prueba para demostrar el funcionamiento del sistema de biblioteca
    /// Incluye ejemplos de uso de los métodos AltaLector y PrestarLibro
    /// </summary>
    class PruebaBiblioteca
    {
        static void Main(string[] args)
        {
            // Crear una nueva biblioteca
            Biblioteca biblioteca = new Biblioteca();

            Console.WriteLine("=== SISTEMA DE BIBLIOTECA ===");
            Console.WriteLine(biblioteca.GetInformacion());
            Console.WriteLine();

            // Agregar algunos libros a la biblioteca
            biblioteca.AgregarLibro(new Libro("El Quijote", "Miguel de Cervantes", "978-84-376-0494-7"));
            biblioteca.AgregarLibro(new Libro("Cien años de soledad", "Gabriel García Márquez", "978-84-376-0494-8"));
            biblioteca.AgregarLibro(new Libro("Don Juan Tenorio", "José Zorrilla", "978-84-376-0494-9"));
            biblioteca.AgregarLibro(new Libro("La Celestina", "Fernando de Rojas", "978-84-376-0495-0"));
            biblioteca.AgregarLibro(new Libro("Lazarillo de Tormes", "Anónimo", "978-84-376-0495-1"));

            Console.WriteLine("Libros agregados a la biblioteca:");
            foreach (Libro libro in biblioteca.Libros)
            {
                Console.WriteLine($"- {libro.Titulo} por {libro.Autor}");
            }
            Console.WriteLine();

            // Probar el método AltaLector
            Console.WriteLine("=== PRUEBA DE ALTA DE LECTORES ===");

            // Registrar lectores
            bool resultado1 = biblioteca.AltaLector("Juan Pérez", "12345678");
            Console.WriteLine($"Alta de Juan Pérez (12345678): {(resultado1 ? "EXITOSO" : "FALLIDO")}");

            bool resultado2 = biblioteca.AltaLector("María García", "87654321");
            Console.WriteLine($"Alta de María García (87654321): {(resultado2 ? "EXITOSO" : "FALLIDO")}");

            bool resultado3 = biblioteca.AltaLector("Carlos López", "11223344");
            Console.WriteLine($"Alta de Carlos López (11223344): {(resultado3 ? "EXITOSO" : "FALLIDO")}");

            // Intentar registrar un lector duplicado
            bool resultado4 = biblioteca.AltaLector("Juan Pérez", "12345678");
            Console.WriteLine($"Alta duplicada de Juan Pérez: {(resultado4 ? "EXITOSO" : "FALLIDO (esperado)")}");

            Console.WriteLine();
            Console.WriteLine("Lectores registrados:");
            foreach (Lector lector in biblioteca.Lectores)
            {
                Console.WriteLine($"- {lector.Nombre} (DNI: {lector.Dni})");
            }
            Console.WriteLine();

            // Probar el método PrestarLibro
            Console.WriteLine("=== PRUEBA DE PRÉSTAMOS ===");

            // Préstamo exitoso
            string resultadoPrestamo1 = biblioteca.PrestarLibro("El Quijote", "12345678");
            Console.WriteLine($"Préstamo de 'El Quijote' a Juan Pérez: {resultadoPrestamo1}");

            // Segundo préstamo exitoso
            string resultadoPrestamo2 = biblioteca.PrestarLibro("Cien años de soledad", "12345678");
            Console.WriteLine($"Préstamo de 'Cien años de soledad' a Juan Pérez: {resultadoPrestamo2}");

            // Tercer préstamo exitoso
            string resultadoPrestamo3 = biblioteca.PrestarLibro("Don Juan Tenorio", "12345678");
            Console.WriteLine($"Préstamo de 'Don Juan Tenorio' a Juan Pérez: {resultadoPrestamo3}");

            // Cuarto préstamo (debería fallar por tope alcanzado)
            string resultadoPrestamo4 = biblioteca.PrestarLibro("La Celestina", "12345678");
            Console.WriteLine($"Préstamo de 'La Celestina' a Juan Pérez: {resultadoPrestamo4}");

            // Préstamo a lector inexistente
            string resultadoPrestamo5 = biblioteca.PrestarLibro("Lazarillo de Tormes", "99999999");
            Console.WriteLine($"Préstamo de 'Lazarillo de Tormes' a lector inexistente: {resultadoPrestamo5}");

            // Préstamo de libro inexistente
            string resultadoPrestamo6 = biblioteca.PrestarLibro("Libro Inexistente", "87654321");
            Console.WriteLine($"Préstamo de libro inexistente a María García: {resultadoPrestamo6}");

            // Préstamo exitoso a otro lector
            string resultadoPrestamo7 = biblioteca.PrestarLibro("La Celestina", "87654321");
            Console.WriteLine($"Préstamo de 'La Celestina' a María García: {resultadoPrestamo7}");

            Console.WriteLine();

            // Mostrar préstamos activos
            Console.WriteLine("=== PRÉSTAMOS ACTIVOS ===");
            foreach (Lector lector in biblioteca.Lectores)
            {
                Console.WriteLine($"Préstamos de {lector.Nombre}:");
                List<Prestamo> prestamosActivos = biblioteca.GetPrestamosActivos(lector.Dni);
                foreach (Prestamo prestamo in prestamosActivos)
                {
                    Console.WriteLine($"  - {prestamo.Libro.Titulo} " +
                                    $"(prestado el {prestamo.FechaPrestamo:yyyy-MM-dd} " +
                                    $", vence el {prestamo.FechaVencimiento:yyyy-MM-dd})");
                }
            }

            Console.WriteLine();
            Console.WriteLine("=== INFORMACIÓN FINAL ===");
            Console.WriteLine(biblioteca.GetInformacion());

            // Probar devolución
            Console.WriteLine();
            Console.WriteLine("=== PRUEBA DE DEVOLUCIÓN ===");
            bool devolucion = biblioteca.DevolverLibro("El Quijote", "12345678");
            Console.WriteLine($"Devolución de 'El Quijote' por Juan Pérez: {(devolucion ? "EXITOSA" : "FALLIDA")}");

            // Intentar préstamo después de devolución
            string resultadoPrestamo8 = biblioteca.PrestarLibro("Lazarillo de Tormes", "12345678");
            Console.WriteLine($"Préstamo de 'Lazarillo de Tormes' a Juan Pérez después de devolución: {resultadoPrestamo8}");

            Console.WriteLine();
            Console.WriteLine("=== ESTADO FINAL ===");
            Console.WriteLine(biblioteca.GetInformacion());

            Console.WriteLine();
            Console.WriteLine("=== APLICACIÓN FINALIZADA ===");
        }
    }
}
