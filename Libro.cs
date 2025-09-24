using System;

namespace Colecciones
{
    /// <summary>
    /// Clase Libro que representa un libro en la biblioteca
    /// Versión simplificada con funcionalidades básicas
    /// </summary>
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string ISBN { get; set; }

        /// <summary>
        /// Constructor de la clase Libro
        /// </summary>
        /// <param name="titulo">Título del libro</param>
        /// <param name="autor">Autor del libro</param>
        /// <param name="editorial">Editorial del libro</param>
        /// <param name="isbn">ISBN del libro</param>
        public Libro(string titulo, string autor, string editorial, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            ISBN = isbn;
        }

        /// <summary>
        /// Obtiene el título del libro
        /// </summary>
        /// <returns>Título del libro</returns>
        public string getTitulo()
        {
            return Titulo;
        }

        /// <summary>
        /// Representación en string del libro
        /// </summary>
        /// <returns>String con información del libro</returns>
        public override string ToString()
        {
            return $"{Titulo} - {Autor} ({Editorial})";
        }
    }
}