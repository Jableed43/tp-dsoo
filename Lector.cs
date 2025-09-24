using System;
using System.Collections.Generic;

namespace Colecciones
{
    // Clase para manejar los lectores de la biblioteca
    public class Lector
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string NumeroSocio { get; set; }
        public string Telefono { get; set; }
        public List<Libro> LibrosPrestados { get; set; }
        public List<Libro> HistorialPrestados { get; set; }

        // Constructor para crear un nuevo lector
        public Lector(string nombre, string dni)
        {
            Nombre = nombre;
            Dni = dni;
            NumeroSocio = "";
            Telefono = "";
            LibrosPrestados = new List<Libro>();
            HistorialPrestados = new List<Libro>();
        }

        // Devuelve el DNI del lector
        public string getDni()
        {
            return Dni;
        }

        // Cuenta cuántos libros tiene prestados
        public int getLibrosPrestados()
        {
            return LibrosPrestados.Count;
        }

        // Agrega un libro a la lista de prestados (máximo 3)
        public void setLibrosPrestados(Libro libro)
        {
            if (LibrosPrestados.Count < 3)
            {
                LibrosPrestados.Add(libro);
            }
        }

        // Obtiene el historial de libros prestados
        public List<Libro> getHistorialPrestados()
        {
            return HistorialPrestados;
        }

        // Agrega un libro al historial cuando se presta
        public void agregarAlHistorial(Libro libro)
        {
            HistorialPrestados.Add(libro);
        }

        // Formato para mostrar el lector
        public override string ToString()
        {
            return $"{Nombre} (DNI: {Dni}) - Libros prestados: {LibrosPrestados.Count}";
        }
    }
}