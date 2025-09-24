using System;
using System.Collections.Generic;
using System.Linq;

namespace Colecciones
{
    // Clase principal que maneja toda la lógica de la biblioteca
    public class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;

        // Constructor que inicializa las listas
        public Biblioteca()
        {
            libros = new List<Libro>();
            lectores = new List<Lector>();
        }

        // Métodos privados para buscar libros y lectores

        // Busca un libro por su título (ignora mayúsculas/minúsculas)
        private Libro buscarLibroPorTitulo(string titulo)
        {
            foreach (Libro libro in libros)
            {
                if (libro.getTitulo().Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return libro;
                }
            }
            return null;
        }

        // Busca un libro por su ISBN
        private Libro buscarLibroPorISBN(string isbn)
        {
            foreach (Libro libro in libros)
            {
                if (libro.ISBN == isbn)
                {
                    return libro;
                }
            }
            return null;
        }

        // Busca un lector por su DNI
        private Lector buscarLector(string dni)
        {
            foreach (Lector lector in lectores)
            {
                if (lector.getDni() == dni)
                {
                    return lector;
                }
            }
            return null;
        }

        // Métodos principales para gestionar libros y lectores

        // Agrega un nuevo libro a la biblioteca
        public bool agregarLibro(string titulo, string autor, string editorial, string isbn)
        {
            // Verificar si el libro ya existe
            if (buscarLibroPorISBN(isbn) != null)
            {
                return false; // El libro ya existe
            }

            Libro nuevoLibro = new Libro(titulo, autor, editorial, isbn);
            libros.Add(nuevoLibro);
            return true;
        }

        // Muestra todos los libros (disponibles y prestados)
        public void listarLibros()
        {
            Console.WriteLine("=== TODOS LOS LIBROS (DISPONIBLES Y PRESTADOS) ===");
            
            // Obtener todos los libros prestados
            List<Libro> librosPrestados = listarPrestados();
            
            // Mostrar libros disponibles
            Console.WriteLine("\n📚 LIBROS DISPONIBLES:");
            if (libros.Count == 0)
            {
                Console.WriteLine("   No hay libros disponibles en la biblioteca.");
            }
            else
            {
                for (int i = 0; i < libros.Count; i++)
                {
                    Console.WriteLine($"   {i + 1}. {libros[i]}");
                }
            }
            
            // Mostrar libros prestados
            Console.WriteLine("\n📤 LIBROS PRESTADOS:");
            if (librosPrestados.Count == 0)
            {
                Console.WriteLine("   No hay libros prestados.");
            }
            else
            {
                for (int i = 0; i < librosPrestados.Count; i++)
                {
                    Console.WriteLine($"   {i + 1}. {librosPrestados[i]}");
                }
            }
            
            Console.WriteLine($"\n📊 Total: {libros.Count + librosPrestados.Count} libros ({libros.Count} disponibles, {librosPrestados.Count} prestados)");
            Console.WriteLine();
        }

        // Devuelve la lista de libros disponibles
        public List<Libro> listarDisponibles()
        {
            return new List<Libro>(libros);
        }

        // Devuelve la lista de libros prestados
        public List<Libro> listarPrestados()
        {
            List<Libro> librosPrestados = new List<Libro>();
            
            foreach (Lector lector in lectores)
            {
                librosPrestados.AddRange(lector.LibrosPrestados);
            }
            
            return librosPrestados;
        }

        // Busca un libro por ISBN (método público)
        public Libro buscarLibro(string isbn)
        {
            return buscarLibroPorISBN(isbn);
        }

        // Elimina un libro de la biblioteca
        public bool eliminarLibro(string isbn)
        {
            Libro libro = buscarLibroPorISBN(isbn);
            if (libro != null)
            {
                libros.Remove(libro);
                return true;
            }
            return false;
        }

        // Registra un nuevo lector en la biblioteca
        public bool altaLector(string nombre, string dni)
        {
            // Verificar si el lector ya existe
            if (buscarLector(dni) != null)
            {
                return false; // El lector ya existe
            }

            // Crear y agregar el nuevo lector
            Lector nuevoLector = new Lector(nombre, dni);
            lectores.Add(nuevoLector);
            return true;
        }

        /// <summary>
        /// Presta un libro a un lector
        /// CUMPLE CON LA CONSIGNA: Remueve el libro de la biblioteca y lo asigna al lector
        /// </summary>
        /// <param name="titulo">Título del libro a prestar</param>
        /// <param name="dni">DNI del lector que solicita el préstamo</param>
        /// <returns>String con el resultado del préstamo</returns>
        public string prestarLibro(string titulo, string dni)
        {
            // 1. Verificar si el lector existe
            Lector lector = buscarLector(dni);
            if (lector == null)
            {
                return "LECTOR INEXISTENTE";
            }

            // 2. Buscar el libro por título EN LA BIBLIOTECA
            Libro libro = buscarLibroPorTitulo(titulo);
            if (libro == null)
            {
                return "LIBRO INEXISTENTE";
            }

            // 3. Verificar que el lector no tenga más de 3 préstamos activos
            if (lector.getLibrosPrestados() >= 3)
            {
                return "TOPE DE PRESTAMO ALCANZADO";
            }

            // 4. Realizar el préstamo según consigna:
            // - Retirar el libro de la biblioteca
            // - Asignárselo al lector
            // - Agregar al historial del lector
            libros.Remove(libro);
            lector.setLibrosPrestados(libro);
            lector.agregarAlHistorial(libro);

            return "PRESTAMO EXITOSO";
        }

        /// <summary>
        /// Devuelve un libro prestado a la biblioteca
        /// </summary>
        /// <param name="titulo">Título del libro a devolver</param>
        /// <param name="dni">DNI del lector que devuelve el libro</param>
        /// <returns>String con el resultado de la devolución</returns>
        public string devolverLibro(string titulo, string dni)
        {
            // 1. Verificar si el lector existe
            Lector lector = buscarLector(dni);
            if (lector == null)
            {
                return "LECTOR INEXISTENTE";
            }

            // 2. Buscar el libro en los libros prestados del lector
            Libro libroPrestado = null;
            foreach (Libro libro in lector.LibrosPrestados)
            {
                if (libro.getTitulo().Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    libroPrestado = libro;
                    break;
                }
            }

            if (libroPrestado == null)
            {
                return "LIBRO NO PRESTADO POR ESTE LECTOR";
            }

            // 3. Realizar la devolución:
            // - Remover el libro de los prestados del lector
            // - Agregarlo de vuelta a la biblioteca
            lector.LibrosPrestados.Remove(libroPrestado);
            libros.Add(libroPrestado);

            return "DEVOLUCION EXITOSA";
        }

        /// <summary>
        /// Lista todos los lectores registrados
        /// </summary>
        public void listarLectores()
        {
            Console.WriteLine("=== LECTORES REGISTRADOS ===");
            if (lectores.Count == 0)
            {
                Console.WriteLine("No hay lectores registrados.");
            }
            else
            {
                for (int i = 0; i < lectores.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {lectores[i]}");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Lista los lectores con sus libros prestados
        /// </summary>
        public void listarLectoresConLibros()
        {
            Console.WriteLine("=== LECTORES Y SUS LIBROS PRESTADOS ===");
            if (lectores.Count == 0)
            {
                Console.WriteLine("No hay lectores registrados.");
            }
            else
            {
                foreach (Lector lector in lectores)
                {
                    Console.WriteLine($"\n👤 {lector.Nombre} (DNI: {lector.Dni})");
                    if (lector.LibrosPrestados.Count == 0)
                    {
                        Console.WriteLine("   📚 No tiene libros prestados");
                    }
                    else
                    {
                        Console.WriteLine($"   📚 Libros prestados ({lector.LibrosPrestados.Count}):");
                        for (int i = 0; i < lector.LibrosPrestados.Count; i++)
                        {
                            Console.WriteLine($"      {i + 1}. {lector.LibrosPrestados[i]}");
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Lista el historial de préstamos de un lector específico
        /// </summary>
        /// <param name="dni">DNI del lector</param>
        public void listarHistorialLector(string dni)
        {
            Lector lector = buscarLector(dni);
            if (lector == null)
            {
                Console.WriteLine("❌ Lector no encontrado.");
                return;
            }

            Console.WriteLine($"=== HISTORIAL DE PRÉSTAMOS - {lector.Nombre} ===");
            if (lector.getHistorialPrestados().Count == 0)
            {
                Console.WriteLine("No hay libros en el historial de préstamos.");
            }
            else
            {
                for (int i = 0; i < lector.getHistorialPrestados().Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {lector.getHistorialPrestados()[i]}");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Obtiene información básica de la biblioteca
        /// </summary>
        /// <returns>String con estadísticas básicas</returns>
        public string getInformacion()
        {
            int totalPrestados = 0;
            foreach (Lector lector in lectores)
            {
                totalPrestados += lector.getLibrosPrestados();
            }
            
            return $"Libros en biblioteca: {libros.Count}, Lectores: {lectores.Count}, Préstamos activos: {totalPrestados}";
        }
    }
}