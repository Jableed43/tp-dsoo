using System;

namespace Biblioteca
{
    /// <summary>
    /// Clase Lector que representa a un lector registrado en la biblioteca
    /// Cada lector tiene un nombre y un DNI único
    /// </summary>
    public class Lector
    {
        public string Nombre { get; set; }
        public string Dni { get; set; }

        /// <summary>
        /// Constructor de la clase Lector
        /// </summary>
        /// <param name="nombre">Nombre del lector</param>
        /// <param name="dni">DNI del lector (debe ser único)</param>
        public Lector(string nombre, string dni)
        {
            Nombre = nombre;
            Dni = dni;
        }

        /// <summary>
        /// Compara dos lectores por DNI
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>true si tienen el mismo DNI, false en caso contrario</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Lector lector = (Lector)obj;
            return Dni == lector.Dni;
        }

        /// <summary>
        /// Genera hash code basado en el DNI
        /// </summary>
        /// <returns>Hash code del lector</returns>
        public override int GetHashCode()
        {
            return Dni?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Representación en string del lector
        /// </summary>
        /// <returns>String con nombre y DNI del lector</returns>
        public override string ToString()
        {
            return $"Lector{{Nombre='{Nombre}', Dni='{Dni}'}}";
        }
    }
}
