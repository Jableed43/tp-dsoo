# Sistema de Gestión de Biblioteca

## 📚 Descripción del Proyecto

Este sistema de gestión bibliotecaria implementa las operaciones fundamentales de una biblioteca digital, permitiendo la administración de usuarios, catálogo de libros y control de préstamos. El sistema está diseñado para gestionar de manera eficiente el flujo de libros entre la biblioteca y sus usuarios registrados.

## 🎯 Propósito Académico

Este trabajo práctico tiene como objetivo principal la aplicación práctica de los conceptos fundamentales de la Programación Orientada a Objetos (POO). A través del desarrollo de este sistema, se implementan principios como encapsulación, herencia, polimorfismo y relaciones entre clases, proporcionando una base sólida para el entendimiento de la arquitectura de software orientada a objetos.

## ⚙️ Funcionalidades Implementadas

### Gestión de Usuarios
- **Registro de Lectores**: Incorporación de nuevos usuarios al sistema con validación de duplicados
- **Validación de Identidad**: Verificación mediante DNI para evitar registros duplicados

### Administración de Libros
- **Catálogo de Libros**: Incorporación de nuevos títulos con información completa
- **Control de Inventario**: Gestión del stock disponible en la biblioteca
- **Búsqueda y Consulta**: Localización rápida de libros por título

### Sistema de Préstamos
- **Préstamo de Libros**: Asignación de libros a lectores registrados
- **Devolución de Libros**: Sistema completo de devolución con validaciones
- **Historial de Préstamos**: Registro completo de todos los libros prestados por cada lector
- **Control de Límites**: Restricción máxima de 3 libros por lector simultáneamente
- **Validaciones de Seguridad**: Verificación de existencia de libros y lectores

## 🏗️ Arquitectura del Sistema

### Clases Principales

#### `Libro`
Representa la entidad libro con sus características fundamentales:
- **Título**: Nombre del libro
- **Autor**: Nombre del autor
- **Editorial**: Casa editorial

#### `Lector`
Modela a los usuarios del sistema:
- **Nombre**: Nombre completo del lector
- **DNI**: Identificación única
- **Libros Prestados**: Control de préstamos activos
- **Historial de Préstamos**: Registro de todos los libros prestados históricamente

#### `Biblioteca`
Clase principal que orquesta todas las operaciones:
- **Gestión de Libros**: Administración del catálogo
- **Gestión de Lectores**: Control de usuarios
- **Operaciones de Préstamo**: Lógica de negocio para préstamos

## 🔧 Requisitos Técnicos

- **.NET** (versión compatible)
- **Visual Studio 2022** (recomendado) o cualquier IDE compatible con C#
- **Sistema operativo**: Windows, macOS o Linux

## 🚀 Instalación y Ejecución

### Prerrequisitos
1. Instalar .NET SDK
2. Clonar o descargar el repositorio
3. Abrir el proyecto en Visual Studio 2022

### Compilación
```bash
cd codigo
dotnet build
```

### Ejecución
```bash
cd codigo
dotnet run
```

## 📋 Casos de Uso

### Registro de Usuario
```
Entrada: Nombre: "María García", DNI: "87654321"
Resultado: Usuario registrado exitosamente
```

### Préstamo Exitoso
```
Entrada: Libro: "El Quijote", DNI: "87654321"
Resultado: Préstamo realizado correctamente
```

### Validaciones del Sistema
- **Usuario Inexistente**: "LECTOR INEXISTENTE"
- **Libro No Disponible**: "LIBRO INEXISTENTE"
- **Límite Alcanzado**: "TOPE DE PRESTAMO ALCANZADO"

## 🖥️ Sistema Interactivo

El sistema incluye una interfaz de usuario completa con menú interactivo que permite:
- ✅ **Gestión Completa**: Agregar libros, registrar lectores, realizar préstamos y devoluciones
- ✅ **Consultas Avanzadas**: Listar libros disponibles, prestados, lectores con sus préstamos
- ✅ **Historial de Préstamos**: Consultar el historial completo de préstamos de cualquier lector
- ✅ **Estadísticas del Sistema**: Información en tiempo real del estado de la biblioteca
- ✅ **Datos de Ejemplo**: Carga automática de libros y lectores de prueba para demostración

## 🧪 Pruebas del Sistema

El sistema incluye casos de prueba manuales que demuestran:
- ✅ Registro de usuarios con validación
- ✅ Gestión de libros en el catálogo
- ✅ Sistema de préstamos con restricciones
- ✅ Sistema de devoluciones con validaciones
- ✅ Consulta de historial de préstamos por lector
- ✅ Manejo de casos de error
- ✅ Control de límites de préstamo

**Nota**: Los casos de prueba se ejecutan automáticamente al iniciar el programa y demuestran todas las funcionalidades del sistema.

## 🛠️ Tecnologías Utilizadas

- **C#**: Lenguaje de programación principal
- **.NET**: Framework de desarrollo
- **Visual Studio 2022**: Entorno de desarrollo integrado
- **Programación Orientada a Objetos**: Paradigma de diseño

## 📊 Estructura del Proyecto

```
tp-DSOO/
├── codigo/                     # Código fuente del sistema
│   ├── Biblioteca.sln         # Archivo de solución
│   ├── Biblioteca.csproj      # Configuración del proyecto
│   ├── Biblioteca.cs          # Clase principal del sistema
│   ├── Lector.cs             # Modelo de usuario
│   ├── Libro.cs              # Modelo de libro
│   └── Program.cs            # Punto de entrada
├── uml/                      # Documentación UML
│   ├── diagrama_uml_biblioteca.md    # Documentación UML
│   └── diagrama_uml_biblioteca.jpg   # Diagrama UML
├── README.md                # Documentación principal
├── LICENSE                   # Licencia MIT
├── .gitignore               # Configuración de Git
└── .editorconfig            # Configuración del editor
```

## 🎓 Objetivos de Aprendizaje

A través de este proyecto se logra:
- **Comprensión de POO**: Aplicación práctica de conceptos fundamentales
- **Diseño de Clases**: Creación de entidades bien estructuradas
- **Relaciones entre Objetos**: Implementación de asociaciones
- **Manejo de Excepciones**: Gestión de casos de error
- **Arquitectura de Software**: Organización de código modular

## 📝 Notas de Desarrollo

Este sistema fue desarrollado como parte de un trabajo práctico académico, enfocándose en la aplicación de principios de programación orientada a objetos. El código está diseñado para ser educativo y fácil de entender, priorizando la claridad sobre la optimización de rendimiento.

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 👥 Contribuciones

Este es un proyecto académico. Para sugerencias o mejoras, por favor contactar al desarrollador.

---