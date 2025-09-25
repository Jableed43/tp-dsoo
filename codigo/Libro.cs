using System;

namespace Colecciones
{
    // Clase que maneja la información de los libros
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string ISBN { get; set; }

        // Constructor para crear un nuevo libro
        public Libro(string titulo, string autor, string editorial, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            ISBN = isbn;
        }

        // Devuelve el título del libro
        public string getTitulo()
        {
            return Titulo;
        }

        // Formato para mostrar el libro
        public override string ToString()
        {
            return $"{Titulo} - {Autor} ({Editorial})";
        }
    }
}