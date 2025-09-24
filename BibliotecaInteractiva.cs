using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Biblioteca
{
    /// <summary>
    /// Aplicación interactiva para probar el sistema de biblioteca
    /// Permite probar todas las funcionalidades con inputs del usuario
    /// </summary>
    class BibliotecaInteractiva
    {
        private Biblioteca biblioteca;
        private string archivoDatos = "datos_biblioteca.json";

        public BibliotecaInteractiva()
        {
            biblioteca = new Biblioteca();
            CargarDatos();
        }

        static void Main(string[] args)
        {
            BibliotecaInteractiva app = new BibliotecaInteractiva();
            app.MostrarMenu();
        }

        /// <summary>
        /// Muestra el menú principal y maneja la navegación
        /// </summary>
        public void MostrarMenu()
        {
            bool continuar = true;
            
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                    SISTEMA DE BIBLIOTECA                     ║");
                Console.WriteLine("║                        (C# .NET 8.0)                         ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine($"📊 Estado actual: {biblioteca.GetInformacion()}");
                Console.WriteLine();
                Console.WriteLine("📋 MENÚ PRINCIPAL:");
                Console.WriteLine("┌─────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│ 1. 👤 Gestionar Lectores                                   │");
                Console.WriteLine("│ 2. 📚 Gestionar Libros                                     │");
                Console.WriteLine("│ 3. 📖 Gestionar Préstamos                                  │");
                Console.WriteLine("│ 4. 📊 Ver Estadísticas                                     │");
                Console.WriteLine("│ 5. 🧪 Ejecutar Casos de Prueba                            │");
                Console.WriteLine("│ 6. 💾 Guardar Datos                                         │");
                Console.WriteLine("│ 7. 🔄 Cargar Datos                                           │");
                Console.WriteLine("│ 0. 🚪 Salir                                                │");
                Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
                Console.WriteLine();

                Console.Write("Seleccione una opción (0-7): ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        GestionarLectores();
                        break;
                    case "2":
                        GestionarLibros();
                        break;
                    case "3":
                        GestionarPrestamos();
                        break;
                    case "4":
                        MostrarEstadisticas();
                        break;
                    case "5":
                        EjecutarCasosPrueba();
                        break;
                    case "6":
                        GuardarDatos();
                        break;
                    case "7":
                        CargarDatos();
                        break;
                    case "0":
                        continuar = false;
                        Console.WriteLine("\n👋 ¡Gracias por usar el Sistema de Biblioteca!");
                        break;
                    default:
                        Console.WriteLine("\n❌ Opción inválida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        /// <summary>
        /// Gestiona las operaciones con lectores
        /// </summary>
        private void GestionarLectores()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                    GESTIÓN DE LECTORES                      ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine("1. 📝 Registrar nuevo lector");
                Console.WriteLine("2. 👥 Ver todos los lectores");
                Console.WriteLine("3. 🔍 Buscar lector por DNI");
                Console.WriteLine("4. 📋 Ver préstamos de un lector");
                Console.WriteLine("0. ⬅️ Volver al menú principal");
                Console.WriteLine();

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        RegistrarLector();
                        break;
                    case "2":
                        MostrarLectores();
                        break;
                    case "3":
                        BuscarLector();
                        break;
                    case "4":
                        VerPrestamosLector();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\n❌ Opción inválida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        /// <summary>
        /// Registra un nuevo lector
        /// </summary>
        private void RegistrarLector()
        {
            Console.WriteLine("\n📝 REGISTRAR NUEVO LECTOR");
            Console.WriteLine("═══════════════════════════");
            
            Console.Write("Ingrese el nombre del lector: ");
            string nombre = Console.ReadLine() ?? "";
            
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("❌ El nombre no puede estar vacío.");
                Pausar();
                return;
            }

            Console.Write("Ingrese el DNI del lector: ");
            string dni = Console.ReadLine() ?? "";
            
            if (string.IsNullOrWhiteSpace(dni))
            {
                Console.WriteLine("❌ El DNI no puede estar vacío.");
                Pausar();
                return;
            }

            bool resultado = biblioteca.AltaLector(nombre, dni);
            
            if (resultado)
            {
                Console.WriteLine($"✅ Lector '{nombre}' registrado exitosamente con DNI: {dni}");
            }
            else
            {
                Console.WriteLine($"❌ Error: Ya existe un lector con el DNI {dni}");
            }
            
            Pausar();
        }

        /// <summary>
        /// Muestra todos los lectores registrados
        /// </summary>
        private void MostrarLectores()
        {
            Console.WriteLine("\n👥 LECTORES REGISTRADOS");
            Console.WriteLine("═══════════════════════");
            
            if (biblioteca.Lectores.Count == 0)
            {
                Console.WriteLine("📭 No hay lectores registrados.");
            }
            else
            {
                for (int i = 0; i < biblioteca.Lectores.Count; i++)
                {
                    var lector = biblioteca.Lectores[i];
                    var prestamosActivos = biblioteca.GetPrestamosActivos(lector.Dni);
                    Console.WriteLine($"{i + 1}. {lector.Nombre} (DNI: {lector.Dni}) - Préstamos activos: {prestamosActivos.Count}");
                }
            }
            
            Pausar();
        }

        /// <summary>
        /// Busca un lector por DNI
        /// </summary>
        private void BuscarLector()
        {
            Console.WriteLine("\n🔍 BUSCAR LECTOR");
            Console.WriteLine("═════════════════");
            
            Console.Write("Ingrese el DNI del lector: ");
            string dni = Console.ReadLine() ?? "";
            
            var lector = biblioteca.Lectores.Find(l => l.Dni == dni);
            
            if (lector != null)
            {
                var prestamosActivos = biblioteca.GetPrestamosActivos(lector.Dni);
                Console.WriteLine($"\n✅ Lector encontrado:");
                Console.WriteLine($"   Nombre: {lector.Nombre}");
                Console.WriteLine($"   DNI: {lector.Dni}");
                Console.WriteLine($"   Préstamos activos: {prestamosActivos.Count}");
                
                if (prestamosActivos.Count > 0)
                {
                    Console.WriteLine("   Libros prestados:");
                    foreach (var prestamo in prestamosActivos)
                    {
                        Console.WriteLine($"     - {prestamo.Libro.Titulo} (vence: {prestamo.FechaVencimiento:yyyy-MM-dd})");
                    }
                }
            }
            else
            {
                Console.WriteLine($"❌ No se encontró un lector con DNI: {dni}");
            }
            
            Pausar();
        }

        /// <summary>
        /// Muestra los préstamos de un lector específico
        /// </summary>
        private void VerPrestamosLector()
        {
            Console.WriteLine("\n📋 PRÉSTAMOS DE LECTOR");
            Console.WriteLine("═══════════════════════");
            
            Console.Write("Ingrese el DNI del lector: ");
            string dni = Console.ReadLine() ?? "";
            
            var prestamosActivos = biblioteca.GetPrestamosActivos(dni);
            
            if (prestamosActivos.Count == 0)
            {
                Console.WriteLine("📭 Este lector no tiene préstamos activos.");
            }
            else
            {
                Console.WriteLine($"\n📚 Préstamos activos ({prestamosActivos.Count}):");
                foreach (var prestamo in prestamosActivos)
                {
                    Console.WriteLine($"   • {prestamo.Libro.Titulo}");
                    Console.WriteLine($"     Autor: {prestamo.Libro.Autor}");
                    Console.WriteLine($"     Prestado: {prestamo.FechaPrestamo:yyyy-MM-dd}");
                    Console.WriteLine($"     Vence: {prestamo.FechaVencimiento:yyyy-MM-dd}");
                    Console.WriteLine($"     Estado: {prestamo.Estado}");
                    Console.WriteLine();
                }
            }
            
            Pausar();
        }

        /// <summary>
        /// Gestiona las operaciones con libros
        /// </summary>
        private void GestionarLibros()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                     GESTIÓN DE LIBROS                       ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine("1. 📚 Agregar nuevo libro");
                Console.WriteLine("2. 📖 Ver todos los libros");
                Console.WriteLine("3. 🔍 Buscar libro por título");
                Console.WriteLine("4. 📊 Ver libros disponibles");
                Console.WriteLine("5. 📋 Ver libros prestados");
                Console.WriteLine("0. ⬅️ Volver al menú principal");
                Console.WriteLine();

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        AgregarLibro();
                        break;
                    case "2":
                        MostrarLibros();
                        break;
                    case "3":
                        BuscarLibro();
                        break;
                    case "4":
                        MostrarLibrosDisponibles();
                        break;
                    case "5":
                        MostrarLibrosPrestados();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\n❌ Opción inválida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        /// <summary>
        /// Agrega un nuevo libro a la biblioteca
        /// </summary>
        private void AgregarLibro()
        {
            Console.WriteLine("\n📚 AGREGAR NUEVO LIBRO");
            Console.WriteLine("═══════════════════════");
            
            Console.Write("Ingrese el título del libro: ");
            string titulo = Console.ReadLine() ?? "";
            
            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("❌ El título no puede estar vacío.");
                Pausar();
                return;
            }

            Console.Write("Ingrese el autor del libro: ");
            string autor = Console.ReadLine() ?? "";
            
            Console.Write("Ingrese el ISBN del libro: ");
            string isbn = Console.ReadLine() ?? "";

            Libro nuevoLibro = new Libro(titulo, autor, isbn);
            biblioteca.AgregarLibro(nuevoLibro);
            
            Console.WriteLine($"✅ Libro '{titulo}' agregado exitosamente a la biblioteca.");
            
            Pausar();
        }

        /// <summary>
        /// Muestra todos los libros de la biblioteca
        /// </summary>
        private void MostrarLibros()
        {
            Console.WriteLine("\n📖 LIBROS EN LA BIBLIOTECA");
            Console.WriteLine("═══════════════════════════");
            
            if (biblioteca.Libros.Count == 0)
            {
                Console.WriteLine("📭 No hay libros en la biblioteca.");
            }
            else
            {
                for (int i = 0; i < biblioteca.Libros.Count; i++)
                {
                    var libro = biblioteca.Libros[i];
                    string estado = libro.Disponible ? "✅ Disponible" : "❌ Prestado";
                    Console.WriteLine($"{i + 1}. {libro.Titulo}");
                    Console.WriteLine($"   Autor: {libro.Autor}");
                    Console.WriteLine($"   ISBN: {libro.Isbn}");
                    Console.WriteLine($"   Estado: {estado}");
                    Console.WriteLine();
                }
            }
            
            Pausar();
        }

        /// <summary>
        /// Busca un libro por título
        /// </summary>
        private void BuscarLibro()
        {
            Console.WriteLine("\n🔍 BUSCAR LIBRO");
            Console.WriteLine("═══════════════");
            
            Console.Write("Ingrese el título del libro: ");
            string titulo = Console.ReadLine() ?? "";
            
            var libro = biblioteca.Libros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            
            if (libro != null)
            {
                string estado = libro.Disponible ? "✅ Disponible" : "❌ Prestado";
                Console.WriteLine($"\n✅ Libro encontrado:");
                Console.WriteLine($"   Título: {libro.Titulo}");
                Console.WriteLine($"   Autor: {libro.Autor}");
                Console.WriteLine($"   ISBN: {libro.Isbn}");
                Console.WriteLine($"   Estado: {estado}");
            }
            else
            {
                Console.WriteLine($"❌ No se encontró un libro con título: {titulo}");
            }
            
            Pausar();
        }

        /// <summary>
        /// Muestra solo los libros disponibles
        /// </summary>
        private void MostrarLibrosDisponibles()
        {
            Console.WriteLine("\n✅ LIBROS DISPONIBLES");
            Console.WriteLine("═══════════════════════");
            
            var librosDisponibles = biblioteca.Libros.FindAll(l => l.Disponible);
            
            if (librosDisponibles.Count == 0)
            {
                Console.WriteLine("📭 No hay libros disponibles en este momento.");
            }
            else
            {
                for (int i = 0; i < librosDisponibles.Count; i++)
                {
                    var libro = librosDisponibles[i];
                    Console.WriteLine($"{i + 1}. {libro.Titulo} - {libro.Autor}");
                }
            }
            
            Pausar();
        }

        /// <summary>
        /// Muestra los libros que están prestados
        /// </summary>
        private void MostrarLibrosPrestados()
        {
            Console.WriteLine("\n📚 LIBROS PRESTADOS");
            Console.WriteLine("═══════════════════════");
            
            var librosPrestados = biblioteca.Libros.FindAll(l => !l.Disponible);
            
            if (librosPrestados.Count == 0)
            {
                Console.WriteLine("📭 No hay libros prestados en este momento.");
            }
            else
            {
                for (int i = 0; i < librosPrestados.Count; i++)
                {
                    var libro = librosPrestados[i];
                    Console.WriteLine($"{i + 1}. {libro.Titulo} - {libro.Autor}");
                }
            }
            
            Pausar();
        }

        /// <summary>
        /// Gestiona las operaciones con préstamos
        /// </summary>
        private void GestionarPrestamos()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                   GESTIÓN DE PRÉSTAMOS                       ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine("1. 📖 Prestar libro");
                Console.WriteLine("2. 📚 Devolver libro");
                Console.WriteLine("3. 📋 Ver todos los préstamos");
                Console.WriteLine("4. 🔍 Buscar préstamos por lector");
                Console.WriteLine("5. ⏰ Ver préstamos vencidos");
                Console.WriteLine("0. ⬅️ Volver al menú principal");
                Console.WriteLine();

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        PrestarLibro();
                        break;
                    case "2":
                        DevolverLibro();
                        break;
                    case "3":
                        MostrarPrestamos();
                        break;
                    case "4":
                        BuscarPrestamosLector();
                        break;
                    case "5":
                        MostrarPrestamosVencidos();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\n❌ Opción inválida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        /// <summary>
        /// Realiza un préstamo de libro
        /// </summary>
        private void PrestarLibro()
        {
            Console.WriteLine("\n📖 PRESTAR LIBRO");
            Console.WriteLine("═════════════════");
            
            Console.Write("Ingrese el título del libro: ");
            string titulo = Console.ReadLine() ?? "";
            
            Console.Write("Ingrese el DNI del lector: ");
            string dni = Console.ReadLine() ?? "";
            
            string resultado = biblioteca.PrestarLibro(titulo, dni);
            
            Console.WriteLine($"\n📋 Resultado: {resultado}");
            
            switch (resultado)
            {
                case "PRESTAMO EXITOSO":
                    Console.WriteLine("✅ ¡Préstamo realizado exitosamente!");
                    break;
                case "LIBRO INEXISTENTE":
                    Console.WriteLine("❌ El libro no existe en la biblioteca o no está disponible.");
                    break;
                case "TOPE DE PRESTAMO ALCANZADO":
                    Console.WriteLine("❌ El lector ya tiene el máximo de 3 préstamos activos.");
                    break;
                case "LECTOR INEXISTENTE":
                    Console.WriteLine("❌ El lector no está registrado en la biblioteca.");
                    break;
            }
            
            Pausar();
        }

        /// <summary>
        /// Devuelve un libro prestado
        /// </summary>
        private void DevolverLibro()
        {
            Console.WriteLine("\n📚 DEVOLVER LIBRO");
            Console.WriteLine("═══════════════════");
            
            Console.Write("Ingrese el título del libro: ");
            string titulo = Console.ReadLine() ?? "";
            
            Console.Write("Ingrese el DNI del lector: ");
            string dni = Console.ReadLine() ?? "";
            
            bool resultado = biblioteca.DevolverLibro(titulo, dni);
            
            if (resultado)
            {
                Console.WriteLine("✅ ¡Libro devuelto exitosamente!");
            }
            else
            {
                Console.WriteLine("❌ No se pudo devolver el libro. Verifique el título y el DNI.");
            }
            
            Pausar();
        }

        /// <summary>
        /// Muestra todos los préstamos activos
        /// </summary>
        private void MostrarPrestamos()
        {
            Console.WriteLine("\n📋 PRÉSTAMOS ACTIVOS");
            Console.WriteLine("═══════════════════════");
            
            var prestamosActivos = biblioteca.Prestamos.FindAll(p => p.IsActivo());
            
            if (prestamosActivos.Count == 0)
            {
                Console.WriteLine("📭 No hay préstamos activos en este momento.");
            }
            else
            {
                for (int i = 0; i < prestamosActivos.Count; i++)
                {
                    var prestamo = prestamosActivos[i];
                    Console.WriteLine($"{i + 1}. {prestamo.Lector.Nombre} ({prestamo.Lector.Dni})");
                    Console.WriteLine($"   Libro: {prestamo.Libro.Titulo}");
                    Console.WriteLine($"   Prestado: {prestamo.FechaPrestamo:yyyy-MM-dd}");
                    Console.WriteLine($"   Vence: {prestamo.FechaVencimiento:yyyy-MM-dd}");
                    Console.WriteLine($"   Estado: {prestamo.Estado}");
                    Console.WriteLine();
                }
            }
            
            Pausar();
        }

        /// <summary>
        /// Busca préstamos de un lector específico
        /// </summary>
        private void BuscarPrestamosLector()
        {
            Console.WriteLine("\n🔍 PRÉSTAMOS POR LECTOR");
            Console.WriteLine("═════════════════════════");
            
            Console.Write("Ingrese el DNI del lector: ");
            string dni = Console.ReadLine() ?? "";
            
            var prestamosActivos = biblioteca.GetPrestamosActivos(dni);
            
            if (prestamosActivos.Count == 0)
            {
                Console.WriteLine("📭 Este lector no tiene préstamos activos.");
            }
            else
            {
                Console.WriteLine($"\n📚 Préstamos activos de {prestamosActivos[0].Lector.Nombre}:");
                foreach (var prestamo in prestamosActivos)
                {
                    Console.WriteLine($"   • {prestamo.Libro.Titulo}");
                    Console.WriteLine($"     Prestado: {prestamo.FechaPrestamo:yyyy-MM-dd}");
                    Console.WriteLine($"     Vence: {prestamo.FechaVencimiento:yyyy-MM-dd}");
                    Console.WriteLine();
                }
            }
            
            Pausar();
        }

        /// <summary>
        /// Muestra los préstamos que están vencidos
        /// </summary>
        private void MostrarPrestamosVencidos()
        {
            Console.WriteLine("\n⏰ PRÉSTAMOS VENCIDOS");
            Console.WriteLine("═══════════════════════");
            
            var prestamosVencidos = biblioteca.Prestamos.FindAll(p => p.IsVencido());
            
            if (prestamosVencidos.Count == 0)
            {
                Console.WriteLine("✅ No hay préstamos vencidos en este momento.");
            }
            else
            {
                Console.WriteLine($"⚠️ Se encontraron {prestamosVencidos.Count} préstamos vencidos:");
                foreach (var prestamo in prestamosVencidos)
                {
                    Console.WriteLine($"   • {prestamo.Lector.Nombre} - {prestamo.Libro.Titulo}");
                    Console.WriteLine($"     Vencido desde: {prestamo.FechaVencimiento:yyyy-MM-dd}");
                    Console.WriteLine();
                }
            }
            
            Pausar();
        }

        /// <summary>
        /// Muestra estadísticas del sistema
        /// </summary>
        private void MostrarEstadisticas()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      ESTADÍSTICAS                             ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            Console.WriteLine($"📊 {biblioteca.GetInformacion()}");
            Console.WriteLine();
            
            // Estadísticas de lectores
            Console.WriteLine("👥 LECTORES:");
            Console.WriteLine($"   Total registrados: {biblioteca.Lectores.Count}");
            
            var lectoresConPrestamos = biblioteca.Lectores.Count(l => biblioteca.GetPrestamosActivos(l.Dni).Count > 0);
            Console.WriteLine($"   Con préstamos activos: {lectoresConPrestamos}");
            Console.WriteLine();
            
            // Estadísticas de libros
            Console.WriteLine("📚 LIBROS:");
            Console.WriteLine($"   Total en biblioteca: {biblioteca.Libros.Count}");
            Console.WriteLine($"   Disponibles: {biblioteca.Libros.Count(l => l.Disponible)}");
            Console.WriteLine($"   Prestados: {biblioteca.Libros.Count(l => !l.Disponible)}");
            Console.WriteLine();
            
            // Estadísticas de préstamos
            var prestamosActivos = biblioteca.Prestamos.FindAll(p => p.IsActivo());
            var prestamosVencidos = biblioteca.Prestamos.FindAll(p => p.IsVencido());
            
            Console.WriteLine("📖 PRÉSTAMOS:");
            Console.WriteLine($"   Activos: {prestamosActivos.Count}");
            Console.WriteLine($"   Vencidos: {prestamosVencidos.Count}");
            Console.WriteLine($"   Total realizados: {biblioteca.Prestamos.Count}");
            Console.WriteLine();
            
            // Top lectores
            if (biblioteca.Lectores.Count > 0)
            {
                Console.WriteLine("🏆 TOP LECTORES (por cantidad de préstamos activos):");
                var lectoresOrdenados = biblioteca.Lectores
                    .OrderByDescending(l => biblioteca.GetPrestamosActivos(l.Dni).Count)
                    .Take(3);
                
                foreach (var lector in lectoresOrdenados)
                {
                    var prestamos = biblioteca.GetPrestamosActivos(lector.Dni);
                    if (prestamos.Count > 0)
                    {
                        Console.WriteLine($"   • {lector.Nombre}: {prestamos.Count} préstamos");
                    }
                }
            }
            
            Pausar();
        }

        /// <summary>
        /// Ejecuta casos de prueba predefinidos
        /// </summary>
        private void EjecutarCasosPrueba()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    CASOS DE PRUEBA                          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            Console.WriteLine("🧪 Ejecutando casos de prueba del sistema...");
            Console.WriteLine();
            
            // Caso 1: Agregar libros de prueba
            Console.WriteLine("📚 Agregando libros de prueba...");
            biblioteca.AgregarLibro(new Libro("El Quijote", "Miguel de Cervantes", "978-84-376-0494-7"));
            biblioteca.AgregarLibro(new Libro("Cien años de soledad", "Gabriel García Márquez", "978-84-376-0494-8"));
            biblioteca.AgregarLibro(new Libro("Don Juan Tenorio", "José Zorrilla", "978-84-376-0494-9"));
            biblioteca.AgregarLibro(new Libro("La Celestina", "Fernando de Rojas", "978-84-376-0495-0"));
            biblioteca.AgregarLibro(new Libro("Lazarillo de Tormes", "Anónimo", "978-84-376-0495-1"));
            Console.WriteLine("✅ 5 libros agregados");
            
            // Caso 2: Registrar lectores
            Console.WriteLine("\n👥 Registrando lectores de prueba...");
            biblioteca.AltaLector("Juan Pérez", "12345678");
            biblioteca.AltaLector("María García", "87654321");
            biblioteca.AltaLector("Carlos López", "11223344");
            Console.WriteLine("✅ 3 lectores registrados");
            
            // Caso 3: Préstamos exitosos
            Console.WriteLine("\n📖 Realizando préstamos de prueba...");
            string resultado1 = biblioteca.PrestarLibro("El Quijote", "12345678");
            string resultado2 = biblioteca.PrestarLibro("Cien años de soledad", "12345678");
            string resultado3 = biblioteca.PrestarLibro("Don Juan Tenorio", "12345678");
            string resultado4 = biblioteca.PrestarLibro("La Celestina", "87654321");
            
            Console.WriteLine($"   Préstamo 1: {resultado1}");
            Console.WriteLine($"   Préstamo 2: {resultado2}");
            Console.WriteLine($"   Préstamo 3: {resultado3}");
            Console.WriteLine($"   Préstamo 4: {resultado4}");
            
            // Caso 4: Prueba de límite
            Console.WriteLine("\n🚫 Probando límite de préstamos...");
            string resultado5 = biblioteca.PrestarLibro("Lazarillo de Tormes", "12345678");
            Console.WriteLine($"   Préstamo 5 (debería fallar): {resultado5}");
            
            // Caso 5: Prueba de lector inexistente
            Console.WriteLine("\n❌ Probando lector inexistente...");
            string resultado6 = biblioteca.PrestarLibro("El Quijote", "99999999");
            Console.WriteLine($"   Préstamo a lector inexistente: {resultado6}");
            
            // Caso 6: Prueba de libro inexistente
            Console.WriteLine("\n❌ Probando libro inexistente...");
            string resultado7 = biblioteca.PrestarLibro("Libro Inexistente", "87654321");
            Console.WriteLine($"   Préstamo de libro inexistente: {resultado7}");
            
            // Caso 7: Devolución
            Console.WriteLine("\n📚 Probando devolución...");
            bool devolucion = biblioteca.DevolverLibro("El Quijote", "12345678");
            Console.WriteLine($"   Devolución: {(devolucion ? "EXITOSA" : "FALLIDA")}");
            
            // Caso 8: Préstamo después de devolución
            Console.WriteLine("\n🔄 Probando préstamo después de devolución...");
            string resultado8 = biblioteca.PrestarLibro("Lazarillo de Tormes", "12345678");
            Console.WriteLine($"   Nuevo préstamo: {resultado8}");
            
            Console.WriteLine("\n✅ Casos de prueba completados exitosamente!");
            Console.WriteLine($"📊 Estado final: {biblioteca.GetInformacion()}");
            
            Pausar();
        }

        /// <summary>
        /// Guarda los datos en un archivo JSON
        /// </summary>
        private void GuardarDatos()
        {
            try
            {
                var datos = new
                {
                    Lectores = biblioteca.Lectores,
                    Libros = biblioteca.Libros,
                    Prestamos = biblioteca.Prestamos,
                    FechaGuardado = DateTime.Now
                };
                
                string json = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(archivoDatos, json);
                
                Console.WriteLine($"✅ Datos guardados exitosamente en {archivoDatos}");
                Console.WriteLine($"📅 Fecha de guardado: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al guardar datos: {ex.Message}");
            }
            
            Pausar();
        }

        /// <summary>
        /// Carga los datos desde un archivo JSON
        /// </summary>
        private void CargarDatos()
        {
            try
            {
                if (File.Exists(archivoDatos))
                {
                    string json = File.ReadAllText(archivoDatos);
                    var datos = JsonSerializer.Deserialize<DatosBiblioteca>(json);
                    
                    if (datos != null)
                    {
                        // Limpiar datos actuales
                        biblioteca.Lectores.Clear();
                        biblioteca.Libros.Clear();
                        biblioteca.Prestamos.Clear();
                        
                        // Cargar datos guardados
                        biblioteca.Lectores.AddRange(datos.Lectores);
                        biblioteca.Libros.AddRange(datos.Libros);
                        biblioteca.Prestamos.AddRange(datos.Prestamos);
                        
                        Console.WriteLine($"✅ Datos cargados exitosamente desde {archivoDatos}");
                        Console.WriteLine($"📅 Fecha de guardado: {datos.FechaGuardado:yyyy-MM-dd HH:mm:ss}");
                    }
                }
                else
                {
                    Console.WriteLine("📭 No se encontró archivo de datos. Iniciando con biblioteca vacía.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al cargar datos: {ex.Message}");
                Console.WriteLine("📭 Iniciando con biblioteca vacía.");
            }
        }

        /// <summary>
        /// Pausa la ejecución hasta que el usuario presione Enter
        /// </summary>
        private void Pausar()
        {
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Clase para serializar/deserializar los datos de la biblioteca
    /// </summary>
    public class DatosBiblioteca
    {
        public List<Lector> Lectores { get; set; } = new List<Lector>();
        public List<Libro> Libros { get; set; } = new List<Libro>();
        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public DateTime FechaGuardado { get; set; }
    }
}

