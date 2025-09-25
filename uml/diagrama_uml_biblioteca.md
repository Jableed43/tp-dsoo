# Diagrama UML - Sistema de Biblioteca (C#)

## Clases del Sistema

### Clase Libro
```
+-------------------+
|      Libro        |
+-------------------+
| + Titulo: string  |
| + Autor: string   |
| + Editorial: string |
| + ISBN: string    |
+-------------------+
| + getTitulo(): string     |
| + ToString(): string      |
+-------------------+
```

### Clase Lector
```
+-------------------+
|      Lector       |
+-------------------+
| + Dni: string     |
| + Nombre: string  |
| + NumeroSocio: string |
| + Telefono: string |
| + LibrosPrestados: List<Libro> |
| + HistorialPrestados: List<Libro> |
+-------------------+
| + getDni(): string                |
| + getLibrosPrestados(): int      |
| + setLibrosPrestados(Libro): void |
| + getHistorialPrestados(): List<Libro> |
| + agregarAlHistorial(Libro): void |
| + ToString(): string              |
+-------------------+
```

### Clase Biblioteca
```
+-------------------+
|    Biblioteca     |
+-------------------+
| - libros: List<Libro> |
| - lectores: List<Lector> |
+-------------------+
| + agregarLibro(titulo: string, autor: string, editorial: string, isbn: string): bool |
| + listarLibros(): void |
| + listarDisponibles(): List<Libro> |
| + listarPrestados(): List<Libro> |
| + buscarLibro(isbn: string): Libro |
| + eliminarLibro(isbn: string): bool |
| + altaLector(nombre: string, dni: string): bool |
| + prestarLibro(titulo: string, dni: string): string |
| + devolverLibro(titulo: string, dni: string): string |
| + listarLectores(): void |
| + listarLectoresConLibros(): void |
| + listarHistorialLector(dni: string): void |
| + getInformacion(): string |
| - buscarLibroPorTitulo(titulo: string): Libro |
| - buscarLibroPorISBN(isbn: string): Libro |
| - buscarLector(dni: string): Lector |
+-------------------+
```

## Relaciones

- **Biblioteca** 1..* **Lector** (composición)
- **Biblioteca** 1..* **Libro** (composición)
- **Lector** 0..3 **Libro** (asociación - préstamos activos)
- **Lector** 0..* **Libro** (asociación - historial de préstamos)

## Diagrama de Clases Completo

```
Biblioteca
├── - libros: List<Libro>
├── - lectores: List<Lector>
│
├── + agregarLibro(titulo: string, autor: string, editorial: string, isbn: string): bool
├── + listarLibros(): void
├── + listarDisponibles(): List<Libro>
├── + listarPrestados(): List<Libro>
├── + buscarLibro(isbn: string): Libro
├── + eliminarLibro(isbn: string): bool
├── + altaLector(nombre: string, dni: string): bool
├── + prestarLibro(titulo: string, dni: string): string
├── + devolverLibro(titulo: string, dni: string): string
├── + listarLectores(): void
├── + listarLectoresConLibros(): void
├── + listarHistorialLector(dni: string): void
├── + getInformacion(): string
├── - buscarLibroPorTitulo(titulo: string): Libro
├── - buscarLibroPorISBN(isbn: string): Libro
└── - buscarLector(dni: string): Lector

Lector
├── + Dni: string
├── + Nombre: string
├── + NumeroSocio: string
├── + Telefono: string
├── + LibrosPrestados: List<Libro> [0..3]
├── + HistorialPrestados: List<Libro>
│
├── + getDni(): string
├── + getLibrosPrestados(): int
├── + setLibrosPrestados(Libro): void
├── + getHistorialPrestados(): List<Libro>
├── + agregarAlHistorial(Libro): void
└── + ToString(): string

Libro
├── + Titulo: string
├── + Autor: string
├── + Editorial: string
├── + ISBN: string
│
├── + getTitulo(): string
└── + ToString(): string
```

## Flujo de Préstamo

1. **Verificar Lector**: Comprobar si el DNI existe en la lista de lectores
2. **Verificar Libro**: Comprobar si el título existe en la biblioteca
3. **Verificar Límite**: Comprobar que el lector tenga menos de 3 préstamos activos
4. **Realizar Préstamo**: 
   - Remover el libro de la biblioteca
   - Asignar el libro al lector
   - Agregar el libro al historial del lector
   - Retornar "PRESTAMO EXITOSO"

## Posibles Respuestas del Método prestarLibro()

- `"PRESTAMO EXITOSO"`: El préstamo se realizó correctamente
- `"LIBRO INEXISTENTE"`: El libro no existe en la biblioteca
- `"TOPE DE PRESTAMO ALCANZADO"`: El lector ya tiene 3 préstamos activos
- `"LECTOR INEXISTENTE"`: El DNI no está registrado en la biblioteca

## Posibles Respuestas del Método altaLector()

- `true`: El lector se registró correctamente
- `false`: Ya existe un lector con ese DNI

## Posibles Respuestas del Método devolverLibro()

- `"DEVOLUCION EXITOSA"`: La devolución se realizó correctamente
- `"LECTOR INEXISTENTE"`: El DNI no está registrado en la biblioteca
- `"LIBRO NO PRESTADO POR ESTE LECTOR"`: El lector no tiene ese libro prestado

## Restricciones del Sistema

- **Máximo 3 libros por lector**: Un lector no puede tener más de 3 libros prestados simultáneamente
- **ISBN único**: Cada libro se identifica por su ISBN único
- **DNI único**: Cada lector se identifica por su DNI único
- **Libros se remueven de biblioteca**: Al prestar un libro, se remueve de la biblioteca y se asigna al lector
- **Devolución restaura libro**: Al devolver un libro, se regresa a la biblioteca y se remueve del lector
- **Historial permanente**: Todos los préstamos se registran en el historial del lector de forma permanente
