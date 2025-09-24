using System;
using System.Collections.Generic;
using System.Linq;

namespace Colecciones
{
    /// <summary>
    /// Clase Biblioteca que gestiona lectores y libros
    /// Versión simplificada basada en el proyecto de ejemplo
    /// </summary>
    public class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;

        /// <summary>
        /// Constructor de la clase Biblioteca
        /// </summary>
        public Biblioteca()
        {
            libros = new List<Libro>();
            lectores = new List<Lector>();
        }

        // MÉTODOS PRIVADOS DE BÚSQUEDA

        /// <summary>
        /// Busca un libro por título
        /// </summary>
        /// <param name="titulo">Título del libro a buscar</param>
        /// <returns>Libro encontrado o null si no existe</returns>
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

        /// <summary>
        /// Busca un libro por ISBN
        /// </summary>
        /// <param name="isbn">ISBN del libro a buscar</param>
        /// <returns>Libro encontrado o null si no existe</returns>
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

        /// <summary>
        /// Busca un lector por DNI
        /// </summary>
        /// <param name="dni">DNI del lector a buscar</param>
        /// <returns>Lector encontrado o null si no existe</returns>
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

        // MÉTODOS PÚBLICOS PRINCIPALES

        /// <summary>
        /// Agrega un libro a la biblioteca
        /// </summary>
        /// <param name="titulo">Título del libro</param>
        /// <param name="autor">Autor del libro</param>
        /// <param name="editorial">Editorial del libro</param>
        /// <param name="isbn">ISBN del libro</param>
        /// <returns>true si se agregó exitosamente, false si ya existía</returns>
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

        /// <summary>
        /// Lista todos los libros de la biblioteca
        /// </summary>
        public void listarLibros()
        {
            Console.WriteLine("=== LIBROS EN LA BIBLIOTECA ===");
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
            }
            else
            {
                for (int i = 0; i < libros.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {libros[i]}");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Lista los libros disponibles (no prestados)
        /// </summary>
        /// <returns>Lista de libros disponibles</returns>
        public List<Libro> listarDisponibles()
        {
            return new List<Libro>(libros);
        }

        /// <summary>
        /// Lista los libros prestados
        /// </summary>
        /// <returns>Lista de libros prestados</returns>
        public List<Libro> listarPrestados()
        {
            List<Libro> librosPrestados = new List<Libro>();
            
            foreach (Lector lector in lectores)
            {
                librosPrestados.AddRange(lector.LibrosPrestados);
            }
            
            return librosPrestados;
        }

        /// <summary>
        /// Busca un libro por ISBN
        /// </summary>
        /// <param name="isbn">ISBN del libro a buscar</param>
        /// <returns>Libro encontrado o null si no existe</returns>
        public Libro buscarLibro(string isbn)
        {
            return buscarLibroPorISBN(isbn);
        }

        /// <summary>
        /// Elimina un libro de la biblioteca por ISBN
        /// </summary>
        /// <param name="isbn">ISBN del libro a eliminar</param>
        /// <returns>true si se eliminó exitosamente, false en caso contrario</returns>
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

        /// <summary>
        /// Da de alta un nuevo lector en la biblioteca
        /// </summary>
        /// <param name="nombre">Nombre del lector</param>
        /// <param name="dni">DNI del lector</param>
        /// <returns>true si se registró exitosamente, false si ya existía</returns>
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
            libros.Remove(libro);
            lector.setLibrosPrestados(libro);

            return "PRESTAMO EXITOSO";
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