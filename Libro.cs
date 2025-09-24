using System;

namespace Biblioteca
{
    /// <summary>
    /// Clase Libro que representa un libro en la biblioteca
    /// Cada libro tiene título, autor, ISBN y estado de disponibilidad
    /// </summary>
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public bool Disponible { get; set; }

        /// <summary>
        /// Constructor de la clase Libro
        /// </summary>
        /// <param name="titulo">Título del libro</param>
        /// <param name="autor">Autor del libro</param>
        /// <param name="isbn">ISBN del libro</param>
        public Libro(string titulo, string autor, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            Disponible = true; // Por defecto, el libro está disponible
        }

        /// <summary>
        /// Compara dos libros por título
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>true si tienen el mismo título, false en caso contrario</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Libro libro = (Libro)obj;
            return Titulo == libro.Titulo;
        }

        /// <summary>
        /// Genera hash code basado en el título
        /// </summary>
        /// <returns>Hash code del libro</returns>
        public override int GetHashCode()
        {
            return Titulo?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Representación en string del libro
        /// </summary>
        /// <returns>String con información del libro</returns>
        public override string ToString()
        {
            return $"Libro{{Titulo='{Titulo}', Autor='{Autor}', Isbn='{Isbn}', Disponible={Disponible}}}";
        }
    }
}
