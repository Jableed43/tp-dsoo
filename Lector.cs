using System;
using System.Collections.Generic;

namespace Colecciones
{
    /// <summary>
    /// Clase Lector que representa a un lector registrado en la biblioteca
    /// Versión simplificada con funcionalidades básicas
    /// </summary>
    public class Lector
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string NumeroSocio { get; set; }
        public string Telefono { get; set; }
        public List<Libro> LibrosPrestados { get; set; }

        /// <summary>
        /// Constructor de la clase Lector
        /// </summary>
        /// <param name="nombre">Nombre del lector</param>
        /// <param name="dni">DNI del lector (debe ser único)</param>
        public Lector(string nombre, string dni)
        {
            Nombre = nombre;
            Dni = dni;
            NumeroSocio = "";
            Telefono = "";
            LibrosPrestados = new List<Libro>();
        }

        /// <summary>
        /// Obtiene el DNI del lector
        /// </summary>
        /// <returns>DNI del lector</returns>
        public string getDni()
        {
            return Dni;
        }

        /// <summary>
        /// Obtiene la cantidad de libros prestados
        /// </summary>
        /// <returns>Cantidad de libros prestados</returns>
        public int getLibrosPrestados()
        {
            return LibrosPrestados.Count;
        }

        /// <summary>
        /// Agrega un libro a la lista de prestados
        /// </summary>
        /// <param name="libro">Libro a agregar</param>
        public void setLibrosPrestados(Libro libro)
        {
            if (LibrosPrestados.Count < 3)
            {
                LibrosPrestados.Add(libro);
            }
        }

        /// <summary>
        /// Representación en string del lector
        /// </summary>
        /// <returns>String con información del lector</returns>
        public override string ToString()
        {
            return $"{Nombre} (DNI: {Dni}) - Libros prestados: {LibrosPrestados.Count}";
        }
    }
}