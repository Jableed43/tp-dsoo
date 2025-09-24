# Instrucciones de Instalación - Sistema de Biblioteca C#

## Requisitos Previos

### 1. Instalar .NET SDK

#### Opción A: Usando Snap (Recomendado)
```bash
sudo snap install dotnet-sdk --classic
```

#### Opción B: Usando apt (Ubuntu/Debian)
```bash
sudo apt update
sudo apt install dotnet-sdk-6.0
```

#### Opción C: Instalación Manual
1. Visita https://dotnet.microsoft.com/download
2. Descarga .NET 6.0 SDK para Linux
3. Sigue las instrucciones de instalación

### 2. Verificar Instalación
```bash
dotnet --version
```

## Compilación y Ejecución

### Método 1: Usando el script automático
```bash
./run.sh
```

### Método 2: Comandos manuales
```bash
# Restaurar dependencias
dotnet restore

# Compilar el proyecto
dotnet build

# Ejecutar la aplicación
dotnet run
```

## Estructura del Proyecto

```
tp-DSOO/
├── Lector.cs                     # Clase Lector
├── Libro.cs                      # Clase Libro  
├── Prestamo.cs                   # Clase Prestamo
├── Biblioteca.cs                 # Clase principal
├── PruebaBiblioteca.cs           # Aplicación de prueba
├── Biblioteca.csproj             # Archivo de proyecto
├── run.sh                        # Script de ejecución
├── INSTALACION.md               # Este archivo
└── README.md                     # Documentación principal
```

## Características del Sistema

- ✅ **Registro de lectores** con validación de duplicados
- ✅ **Gestión de préstamos** con límite de 3 por lector
- ✅ **Validaciones completas** para todos los casos de error
- ✅ **Interfaz de consola** para pruebas y demostración
- ✅ **Código bien documentado** con comentarios XML

## Casos de Prueba Incluidos

El sistema incluye casos de prueba para:
- Registro exitoso de lectores
- Prevención de registros duplicados
- Préstamos exitosos
- Validación de límite de préstamos (máximo 3)
- Manejo de lectores inexistentes
- Manejo de libros inexistentes
- Devolución de libros
- Préstamos después de devolución

## Salida Esperada

Al ejecutar la aplicación, verás:
```
=== SISTEMA DE BIBLIOTECA ===
Biblioteca - Libros: 0, Lectores: 0, Préstamos activos: 0

Libros agregados a la biblioteca:
- El Quijote por Miguel de Cervantes
- Cien años de soledad por Gabriel García Márquez
...

=== PRUEBA DE ALTA DE LECTORES ===
Alta de Juan Pérez (12345678): EXITOSO
...

=== PRUEBA DE PRÉSTAMOS ===
Préstamo de 'El Quijote' a Juan Pérez: PRESTAMO EXITOSO
...
```

## Solución de Problemas

### Error: "dotnet: command not found"
- Instala .NET SDK siguiendo las instrucciones arriba

### Error de compilación
- Verifica que todos los archivos .cs estén en el directorio
- Asegúrate de tener .NET 6.0 o superior instalado

### Error de permisos en run.sh
```bash
chmod +x run.sh
```

