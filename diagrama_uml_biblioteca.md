# Diagrama UML - Sistema de Biblioteca (C#)

## Clases del Sistema

### Clase Lector
```
+-------------------+
|      Lector       |
+-------------------+
| - Nombre: string  |
| - Dni: string     |
+-------------------+
| + Nombre {get;set;} |
| + Dni {get;set;}    |
| + Equals()         |
| + GetHashCode()    |
| + ToString()       |
+-------------------+
```

### Clase Libro
```
+-------------------+
|      Libro        |
+-------------------+
| - Titulo: string  |
| - Autor: string   |
| - Isbn: string    |
| - Disponible: bool |
+-------------------+
| + Titulo {get;set;}    |
| + Autor {get;set;}     |
| + Isbn {get;set;}      |
| + Disponible {get;set;} |
| + Equals()             |
| + GetHashCode()        |
| + ToString()           |
+-------------------+
```

### Clase Prestamo
```
+-------------------+
|     Prestamo      |
+-------------------+
| - Lector: Lector  |
| - Libro: Libro     |
| - FechaPrestamo: DateTime |
| - FechaVencimiento: DateTime |
| - FechaDevolucion: DateTime? |
| - Estado: string  |
+-------------------+
| + Lector {get;set;}           |
| + Libro {get;set;}            |
| + FechaPrestamo {get;set;}    |
| + FechaVencimiento {get;set;} |
| + FechaDevolucion {get;set;}  |
| + Estado {get;set;}           |
| + Devolver()                  |
| + IsActivo()                  |
| + IsVencido()                 |
| + ToString()                  |
+-------------------+
```

### Clase Biblioteca
```
+-------------------+
|    Biblioteca     |
+-------------------+
| - libros: List<Libro> |
| - lectores: List<Lector> |
| - prestamos: List<Prestamo> |
+-------------------+
| + Libros {get;}           |
| + Lectores {get;}         |
| + Prestamos {get;}        |
| + AltaLector()           |
| + PrestarLibro()         |
| + DevolverLibro()        |
| + AgregarLibro()         |
| + GetPrestamosActivos()  |
| + GetInformacion()       |
+-------------------+
```

## Relaciones

- **Biblioteca** 1..* **Lector** (composición)
- **Biblioteca** 1..* **Libro** (composición)
- **Biblioteca** 1..* **Prestamo** (composición)
- **Lector** 1..3 **Prestamo** (asociación)
- **Libro** 0..1 **Prestamo** (asociación)

## Diagrama de Clases Completo

```
Biblioteca
├── List<Libro> libros
├── List<Lector> lectores
├── List<Prestamo> prestamos
│
├── + Libros {get;}
├── + Lectores {get;}
├── + Prestamos {get;}
├── + AltaLector(nombre: string, dni: string): bool
├── + PrestarLibro(titulo: string, dni: string): string
├── + DevolverLibro(titulo: string, dni: string): bool
├── + AgregarLibro(libro: Libro): void
├── + GetPrestamosActivos(dni: string): List<Prestamo>
└── + GetInformacion(): string

Lector
├── - Nombre: string
├── - Dni: string
│
├── + Nombre {get; set;}
├── + Dni {get; set;}
├── + Equals(obj: object?): bool
├── + GetHashCode(): int
└── + ToString(): string

Libro
├── - Titulo: string
├── - Autor: string
├── - Isbn: string
├── - Disponible: bool
│
├── + Titulo {get; set;}
├── + Autor {get; set;}
├── + Isbn {get; set;}
├── + Disponible {get; set;}
├── + Equals(obj: object?): bool
├── + GetHashCode(): int
└── + ToString(): string

Prestamo
├── - Lector: Lector
├── - Libro: Libro
├── - FechaPrestamo: DateTime
├── - FechaVencimiento: DateTime
├── - FechaDevolucion: DateTime?
├── - Estado: string
│
├── + Lector {get; set;}
├── + Libro {get; set;}
├── + FechaPrestamo {get; set;}
├── + FechaVencimiento {get; set;}
├── + FechaDevolucion {get; set;}
├── + Estado {get; set;}
├── + Devolver(): void
├── + IsActivo(): bool
├── + IsVencido(): bool
└── + ToString(): string
```

## Flujo de Préstamo

1. **Verificar Lector**: Comprobar si el DNI existe en la lista de lectores
2. **Verificar Libro**: Comprobar si el título existe y está disponible
3. **Verificar Límite**: Comprobar que el lector tenga menos de 3 préstamos activos
4. **Realizar Préstamo**: 
   - Crear nuevo préstamo
   - Marcar libro como no disponible
   - Asignar préstamo al lector

## Posibles Respuestas del Método prestarLibro()

- `"PRESTAMO EXITOSO"`: El préstamo se realizó correctamente
- `"LIBRO INEXISTENTE"`: El libro no existe en la biblioteca
- `"TOPE DE PRESTAMO ALCANZADO"`: El lector ya tiene 3 préstamos activos
- `"LECTOR INEXISTENTE"`: El DNI no está registrado en la biblioteca
