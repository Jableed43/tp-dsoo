using System;

namespace Colecciones
{
    /// <summary>
    /// Sistema de Biblioteca Interactivo
    /// Permite al usuario interactuar libremente con el sistema
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE BIBLIOTECA INTERACTIVO ===");
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

            // Mostrar menú interactivo
            MostrarMenu();
            
            bool continuar = true;
            while (continuar)
            {
                Console.Write("\nSeleccione una opción (1-8): ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarLibro(biblioteca);
                        break;
                    case "2":
                        ListarLibros(biblioteca);
                        break;
                    case "3":
                        RegistrarLector(biblioteca);
                        break;
                    case "4":
                        PrestarLibro(biblioteca);
                        break;
                    case "5":
                        ListarDisponibles(biblioteca);
                        break;
                    case "6":
                        ListarPrestados(biblioteca);
                        break;
                    case "7":
                        MostrarEstado(biblioteca);
                        break;
                    case "8":
                        continuar = false;
                        Console.WriteLine("\n¡Gracias por usar el Sistema de Biblioteca!");
                        break;
                    default:
                        Console.WriteLine("❌ Opción inválida. Por favor, seleccione 1-8.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. 📚 Agregar Libro");
            Console.WriteLine("2. 📋 Listar Todos los Libros");
            Console.WriteLine("3. 👤 Registrar Lector");
            Console.WriteLine("4. 📖 Prestar Libro");
            Console.WriteLine("5. ✅ Listar Libros Disponibles");
            Console.WriteLine("6. 📤 Listar Libros Prestados");
            Console.WriteLine("7. 📊 Mostrar Estado del Sistema");
            Console.WriteLine("8. 🚪 Salir");
        }

        static void AgregarLibro(Biblioteca biblioteca)
        {
            Console.WriteLine("\n=== AGREGAR NUEVO LIBRO ===");
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Editorial: ");
            string editorial = Console.ReadLine();
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            bool resultado = biblioteca.agregarLibro(titulo, autor, editorial, isbn);
            Console.WriteLine(resultado ? "✅ Libro agregado exitosamente" : "❌ Error: El libro ya existe");
        }

        static void ListarLibros(Biblioteca biblioteca)
        {
            Console.WriteLine("\n=== TODOS LOS LIBROS ===");
            biblioteca.listarLibros();
        }

        static void RegistrarLector(Biblioteca biblioteca)
        {
            Console.WriteLine("\n=== REGISTRAR NUEVO LECTOR ===");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("DNI: ");
            string dni = Console.ReadLine();

            bool resultado = biblioteca.altaLector(nombre, dni);
            Console.WriteLine(resultado ? "✅ Lector registrado exitosamente" : "❌ Error: El lector ya existe");
        }

        static void PrestarLibro(Biblioteca biblioteca)
        {
            Console.WriteLine("\n=== PRESTAR LIBRO ===");
            Console.Write("Título del libro: ");
            string titulo = Console.ReadLine();
            Console.Write("DNI del lector: ");
            string dni = Console.ReadLine();

            string resultado = biblioteca.prestarLibro(titulo, dni);
            Console.WriteLine($"Resultado: {resultado}");
        }

        static void ListarDisponibles(Biblioteca biblioteca)
        {
            Console.WriteLine("\n=== LIBROS DISPONIBLES ===");
            var disponibles = biblioteca.listarDisponibles();
            if (disponibles.Count == 0)
            {
                Console.WriteLine("No hay libros disponibles");
            }
            else
            {
                foreach (var libro in disponibles)
                {
                    Console.WriteLine($"• {libro}");
                }
            }
        }

        static void ListarPrestados(Biblioteca biblioteca)
        {
            Console.WriteLine("\n=== LIBROS PRESTADOS ===");
            var prestados = biblioteca.listarPrestados();
            if (prestados.Count == 0)
            {
                Console.WriteLine("No hay libros prestados");
            }
            else
            {
                foreach (var libro in prestados)
                {
                    Console.WriteLine($"• {libro}");
                }
            }
        }

        static void MostrarEstado(Biblioteca biblioteca)
        {
            Console.WriteLine("\n=== ESTADO DEL SISTEMA ===");
            Console.WriteLine($"📊 {biblioteca.getInformacion()}");
            Console.WriteLine($"📚 Libros disponibles: {biblioteca.listarDisponibles().Count}");
            Console.WriteLine($"📤 Libros prestados: {biblioteca.listarPrestados().Count}");
        }
    }
}