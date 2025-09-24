using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    /// <summary>
    /// Clase Biblioteca que gestiona lectores, libros y préstamos
    /// Implementa los métodos AltaLector y PrestarLibro según los requerimientos
    /// </summary>
    public class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;
        private List<Prestamo> prestamos;

        /// <summary>
        /// Constructor de la clase Biblioteca
        /// </summary>
        public Biblioteca()
        {
            libros = new List<Libro>();
            lectores = new List<Lector>();
            prestamos = new List<Prestamo>();
        }

        /// <summary>
        /// Obtiene la lista de libros
        /// </summary>
        public List<Libro> Libros => libros;

        /// <summary>
        /// Obtiene la lista de lectores
        /// </summary>
        public List<Lector> Lectores => lectores;

        /// <summary>
        /// Obtiene la lista de préstamos
        /// </summary>
        public List<Prestamo> Prestamos => prestamos;

        /// <summary>
        /// Da de alta un nuevo lector en la biblioteca
        /// </summary>
        /// <param name="nombre">Nombre del lector</param>
        /// <param name="dni">DNI del lector</param>
        /// <returns>true si se registró exitosamente, false si ya existía</returns>
        public bool AltaLector(string nombre, string dni)
        {
            // Verificar si el lector ya existe
            if (lectores.Any(l => l.Dni == dni))
            {
                return false; // El lector ya existe
            }

            // Crear y agregar el nuevo lector
            Lector nuevoLector = new Lector(nombre, dni);
            lectores.Add(nuevoLector);
            return true; // Lector registrado exitosamente
        }

        /// <summary>
        /// Presta un libro a un lector
        /// </summary>
        /// <param name="tituloLibro">Título del libro a prestar</param>
        /// <param name="dniLector">DNI del lector que solicita el préstamo</param>
        /// <returns>String con el resultado del préstamo:
        /// - "PRESTAMO EXITOSO": El préstamo se realizó correctamente
        /// - "LIBRO INEXISTENTE": El libro no existe en la biblioteca
        /// - "TOPE DE PRESTAMO ALCANZADO": El lector ya tiene 3 préstamos activos
        /// - "LECTOR INEXISTENTE": El lector no está registrado</returns>
        public string PrestarLibro(string tituloLibro, string dniLector)
        {
            // 1. Verificar si el lector existe
            Lector lector = BuscarLector(dniLector);
            if (lector == null)
            {
                return "LECTOR INEXISTENTE";
            }

            // 2. Verificar si el libro existe y está disponible
            Libro libro = BuscarLibro(tituloLibro);
            if (libro == null)
            {
                return "LIBRO INEXISTENTE";
            }

            if (!libro.Disponible)
            {
                return "LIBRO INEXISTENTE"; // El libro existe pero no está disponible
            }

            // 3. Verificar que el lector no tenga más de 3 préstamos activos
            int prestamosActivos = ContarPrestamosActivos(lector);
            if (prestamosActivos >= 3)
            {
                return "TOPE DE PRESTAMO ALCANZADO";
            }

            // 4. Realizar el préstamo
            // Marcar el libro como no disponible
            libro.Disponible = false;

            // Crear el préstamo
            Prestamo prestamo = new Prestamo(lector, libro);
            prestamos.Add(prestamo);

            return "PRESTAMO EXITOSO";
        }

        /// <summary>
        /// Devuelve un libro prestado
        /// </summary>
        /// <param name="tituloLibro">Título del libro a devolver</param>
        /// <param name="dniLector">DNI del lector que devuelve el libro</param>
        /// <returns>true si se devolvió exitosamente, false en caso contrario</returns>
        public bool DevolverLibro(string tituloLibro, string dniLector)
        {
            // Buscar el préstamo activo
            Prestamo prestamo = prestamos.FirstOrDefault(p => 
                p.IsActivo() && 
                p.Lector.Dni == dniLector &&
                p.Libro.Titulo == tituloLibro);

            if (prestamo == null)
            {
                return false; // No se encontró el préstamo
            }

            // Marcar el préstamo como devuelto
            prestamo.Devolver();

            // Marcar el libro como disponible
            prestamo.Libro.Disponible = true;

            return true;
        }

        /// <summary>
        /// Busca un lector por DNI
        /// </summary>
        /// <param name="dni">DNI del lector a buscar</param>
        /// <returns>Lector encontrado o null si no existe</returns>
        private Lector? BuscarLector(string dni)
        {
            return lectores.FirstOrDefault(l => l.Dni == dni);
        }

        /// <summary>
        /// Busca un libro por título
        /// </summary>
        /// <param name="titulo">Título del libro a buscar</param>
        /// <returns>Libro encontrado o null si no existe</returns>
        private Libro? BuscarLibro(string titulo)
        {
            return libros.FirstOrDefault(l => l.Titulo == titulo);
        }

        /// <summary>
        /// Cuenta los préstamos activos de un lector
        /// </summary>
        /// <param name="lector">Lector del cual contar préstamos</param>
        /// <returns>Número de préstamos activos</returns>
        private int ContarPrestamosActivos(Lector lector)
        {
            return prestamos.Count(p => p.IsActivo() && p.Lector.Equals(lector));
        }

        /// <summary>
        /// Agrega un libro a la biblioteca
        /// </summary>
        /// <param name="libro">Libro a agregar</param>
        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        /// <summary>
        /// Obtiene los préstamos activos de un lector
        /// </summary>
        /// <param name="dniLector">DNI del lector</param>
        /// <returns>Lista de préstamos activos del lector</returns>
        public List<Prestamo> GetPrestamosActivos(string dniLector)
        {
            return prestamos.Where(p => p.IsActivo() && p.Lector.Dni == dniLector).ToList();
        }

        /// <summary>
        /// Obtiene información de la biblioteca
        /// </summary>
        /// <returns>String con estadísticas de la biblioteca</returns>
        public string GetInformacion()
        {
            int prestamosActivos = prestamos.Count(p => p.IsActivo());
            return $"Biblioteca - Libros: {libros.Count}, Lectores: {lectores.Count}, Préstamos activos: {prestamosActivos}";
        }
    }
}
