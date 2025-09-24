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
| + getISBN(): string       |
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
| - historialPrestados: List<Libro> |
+-------------------+
| + getDni(): string                |
| + getLibrosPrestados(): List<Libro> |
| + setLibrosPrestados(List<Libro>): void |
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
| + Libros: List<Libro> |
| + Lectores: List<Lector> |
+-------------------+
| + PrestarLibro(titulo: string, dni: string): string |
| + AltaLector(nombre: string, dni: string): string |
| + AgregarLibro(titulo: string, autor: string, editorial: string, isbn: string): Libro |
| + EliminarLibro(isbn: string): bool |
| + ListarLibros(): List<Libro> |
| + ListarPrestados(): List<Libro> |
| + BuscarLibro(isbn: string): Libro |
| + ListarDisponibles(): List<Libro> |
| + DevolverLibro(isbn: string, dni: string): bool |
| - buscarLectorPorDni(dni: string): Lector |
| - buscarLibro(isbn: string): Libro |
| - buscarLibroPorTitulo(titulo: string): Libro |
| - estaLibroPrestado(libro: Libro): bool |
| - generarNumeroSocio(): string |
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
├── + Libros: List<Libro>
├── + Lectores: List<Lector>
│
├── + PrestarLibro(titulo: string, dni: string): string
├── + AltaLector(nombre: string, dni: string): string
├── + AgregarLibro(titulo: string, autor: string, editorial: string, isbn: string): Libro
├── + EliminarLibro(isbn: string): bool
├── + ListarLibros(): List<Libro>
├── + ListarPrestados(): List<Libro>
├── + BuscarLibro(isbn: string): Libro
├── + ListarDisponibles(): List<Libro>
├── + DevolverLibro(isbn: string, dni: string): bool
├── - buscarLectorPorDni(dni: string): Lector
├── - buscarLibro(isbn: string): Libro
├── - buscarLibroPorTitulo(titulo: string): Libro
├── - estaLibroPrestado(libro: Libro): bool
└── - generarNumeroSocio(): string

Lector
├── + Dni: string
├── + Nombre: string
├── + NumeroSocio: string
├── + Telefono: string
├── + LibrosPrestados: List<Libro> [0..3]
├── - historialPrestados: List<Libro>
│
├── + getDni(): string
├── + getLibrosPrestados(): List<Libro>
├── + setLibrosPrestados(List<Libro>): void
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
├── + getISBN(): string
└── + ToString(): string
```

## Flujo de Préstamo

1. **Verificar Lector**: Comprobar si el DNI existe en la lista de lectores
2. **Verificar Libro**: Comprobar si el título existe en la biblioteca
3. **Verificar Disponibilidad**: Comprobar que el libro no esté prestado
4. **Verificar Límite**: Comprobar que el lector tenga menos de 3 préstamos activos
5. **Realizar Préstamo**: 
   - Agregar libro a la lista de préstamos del lector
   - Retornar "PRESTAMO EXITOSO"

## Posibles Respuestas del Método PrestarLibro()

- `"PRESTAMO EXITOSO"`: El préstamo se realizó correctamente
- `"LIBRO INEXISTENTE"`: El libro no existe en la biblioteca
- `"LIBRO NO DISPONIBLE"`: El libro existe pero está prestado
- `"TOPE DE PRESTAMO ALCANZADO"`: El lector ya tiene 3 préstamos activos
- `"LECTOR INEXISTENTE"`: El DNI no está registrado en la biblioteca

## Posibles Respuestas del Método AltaLector()

- `"ALTA EXITOSA"`: El lector se registró correctamente
- `"LECTOR YA EXISTE"`: Ya existe un lector con ese DNI

## Restricciones del Sistema

- **Máximo 3 libros por lector**: Un lector no puede tener más de 3 libros prestados simultáneamente
- **ISBN único**: Cada libro se identifica por su ISBN único
- **DNI único**: Cada lector se identifica por su DNI único
- **Número de socio automático**: Se genera automáticamente al dar de alta un lector
