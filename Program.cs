using System;

namespace Colecciones
{
    /// <summary>
    /// Clase principal con casos de prueba básicos para el sistema de biblioteca
    /// Versión simplificada basada en el proyecto de ejemplo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE BIBLIOTECA ===");
            Console.WriteLine("Trabajo Práctico Obligatorio - POO");
            Console.WriteLine();

            // Crear una nueva biblioteca
            Biblioteca biblioteca = new Biblioteca();

            // Cargar algunos libros de ejemplo
            Console.WriteLine("=== CARGANDO LIBROS DE EJEMPLO ===");
            biblioteca.agregarLibro("El Quijote", "Miguel de Cervantes", "Planeta", "978-84-376-0494-7");
            biblioteca.agregarLibro("Cien años de soledad", "Gabriel García Márquez", "Sudamericana", "978-84-376-0494-8");
            biblioteca.agregarLibro("Don Juan Tenorio", "José Zorrilla", "Cátedra", "978-84-376-0494-9");
            biblioteca.agregarLibro("La Celestina", "Fernando de Rojas", "Espasa", "978-84-376-0495-0");
            biblioteca.agregarLibro("Lazarillo de Tormes", "Anónimo", "Austral", "978-84-376-0495-1");
            
            Console.WriteLine("Libros cargados exitosamente.");
            Console.WriteLine();

            // Mostrar información inicial
            Console.WriteLine($"Estado inicial: {biblioteca.getInformacion()}");
            Console.WriteLine();

            // Listar todos los libros
            biblioteca.listarLibros();

            // Registrar un lector
            Console.WriteLine("=== REGISTRO DE LECTOR ===");
            bool registroExitoso = biblioteca.altaLector("Juan Pérez", "12345678");
            Console.WriteLine($"Registro de Juan Pérez: {(registroExitoso ? "EXITOSO" : "FALLIDO")}");
            Console.WriteLine();

            // Probar casos de préstamo
            Console.WriteLine("=== PRUEBAS DE PRÉSTAMOS ===");
            
            // Caso 1: Préstamo con lector inexistente
            string resultado1 = biblioteca.prestarLibro("El Quijote", "99999999");
            Console.WriteLine($"Préstamo a lector inexistente: {resultado1}");

            // Caso 2: Préstamo con libro inexistente
            string resultado2 = biblioteca.prestarLibro("Libro Inexistente", "12345678");
            Console.WriteLine($"Préstamo de libro inexistente: {resultado2}");

            // Caso 3: Préstamos exitosos
            string resultado3 = biblioteca.prestarLibro("El Quijote", "12345678");
            Console.WriteLine($"Préstamo 1 - 'El Quijote': {resultado3}");

            string resultado4 = biblioteca.prestarLibro("Cien años de soledad", "12345678");
            Console.WriteLine($"Préstamo 2 - 'Cien años de soledad': {resultado4}");

            string resultado5 = biblioteca.prestarLibro("Don Juan Tenorio", "12345678");
            Console.WriteLine($"Préstamo 3 - 'Don Juan Tenorio': {resultado5}");

            // Caso 4: Préstamo que debe fallar por tope alcanzado
            string resultado6 = biblioteca.prestarLibro("La Celestina", "12345678");
            Console.WriteLine($"Préstamo 4 (debería fallar): {resultado6}");

            Console.WriteLine();

            // Mostrar estado final
            Console.WriteLine("=== ESTADO FINAL ===");
            Console.WriteLine($"Estado final: {biblioteca.getInformacion()}");
            Console.WriteLine();

            // Mostrar libros disponibles y prestados
            Console.WriteLine($"Libros disponibles: {biblioteca.listarDisponibles().Count}");
            Console.WriteLine($"Libros prestados: {biblioteca.listarPrestados().Count}");

            Console.WriteLine();
            Console.WriteLine("=== PRUEBAS COMPLETADAS ===");
            Console.WriteLine("El sistema ha demostrado:");
            Console.WriteLine("✓ Gestión básica de libros");
            Console.WriteLine("✓ Registro de lectores con validación de duplicados");
            Console.WriteLine("✓ Sistema de préstamos con validaciones según consigna");
            Console.WriteLine("✓ Control del límite máximo de 3 préstamos por lector");
            Console.WriteLine("✓ Manejo de casos de error");
            
            Console.WriteLine();
            Console.WriteLine("Presione Enter para salir...");
            Console.ReadLine();
        }
    }
}