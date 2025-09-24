using System;

namespace Biblioteca
{
    /// <summary>
    /// Clase Prestamo que representa un préstamo de libro a un lector
    /// Cada préstamo tiene fechas de préstamo, vencimiento y devolución, además del estado
    /// </summary>
    public class Prestamo
    {
        public Lector Lector { get; set; }
        public Libro Libro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; } // "ACTIVO", "DEVUELTO", "VENCIDO"

        /// <summary>
        /// Constructor de la clase Prestamo
        /// </summary>
        /// <param name="lector">Lector que solicita el préstamo</param>
        /// <param name="libro">Libro que se presta</param>
        public Prestamo(Lector lector, Libro libro)
        {
            Lector = lector;
            Libro = libro;
            FechaPrestamo = DateTime.Now;
            FechaVencimiento = DateTime.Now.AddDays(15); // 15 días de préstamo
            Estado = "ACTIVO";
            FechaDevolucion = null;
        }

        /// <summary>
        /// Marca el préstamo como devuelto
        /// </summary>
        public void Devolver()
        {
            Estado = "DEVUELTO";
            FechaDevolucion = DateTime.Now;
        }

        /// <summary>
        /// Verifica si el préstamo está activo
        /// </summary>
        /// <returns>true si está activo, false en caso contrario</returns>
        public bool IsActivo()
        {
            return Estado == "ACTIVO";
        }

        /// <summary>
        /// Verifica si el préstamo está vencido
        /// </summary>
        /// <returns>true si está vencido, false en caso contrario</returns>
        public bool IsVencido()
        {
            return DateTime.Now > FechaVencimiento && IsActivo();
        }

        /// <summary>
        /// Representación en string del préstamo
        /// </summary>
        /// <returns>String con información del préstamo</returns>
        public override string ToString()
        {
            return $"Prestamo{{Lector={Lector.Nombre} ({Lector.Dni}), " +
                   $"Libro={Libro.Titulo}, FechaPrestamo={FechaPrestamo:yyyy-MM-dd}, " +
                   $"FechaVencimiento={FechaVencimiento:yyyy-MM-dd}, " +
                   $"FechaDevolucion={FechaDevolucion?.ToString("yyyy-MM-dd") ?? "N/A"}, " +
                   $"Estado='{Estado}'}}";
        }
    }
}

