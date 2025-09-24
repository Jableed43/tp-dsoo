# Guía de la Aplicación Interactiva - Sistema de Biblioteca

## 🚀 Cómo Ejecutar la Aplicación Interactiva

### Opción 1: Script Automático (Recomendado)
```bash
./run_interactivo.sh
```

### Opción 2: Comandos Manuales
```bash
dotnet build
dotnet run
```

## 📋 Funcionalidades de la Aplicación Interactiva

### 🎯 **Menú Principal**
La aplicación presenta un menú interactivo con las siguientes opciones:

1. **👤 Gestionar Lectores** - Registro y consulta de lectores
2. **📚 Gestionar Libros** - Agregar y consultar libros
3. **📖 Gestionar Préstamos** - Realizar préstamos y devoluciones
4. **📊 Ver Estadísticas** - Información detallada del sistema
5. **🧪 Ejecutar Casos de Prueba** - Pruebas automáticas del sistema
6. **💾 Guardar Datos** - Persistencia en archivo JSON
7. **🔄 Cargar Datos** - Recuperar datos guardados
0. **🚪 Salir** - Finalizar la aplicación

### 👤 **Gestión de Lectores**

#### 📝 Registrar Nuevo Lector
- Ingrese nombre y DNI del lector
- Validación automática de duplicados
- Confirmación de registro exitoso

#### 👥 Ver Todos los Lectores
- Lista completa de lectores registrados
- Muestra cantidad de préstamos activos por lector
- Información detallada de cada lector

#### 🔍 Buscar Lector por DNI
- Búsqueda rápida por DNI
- Muestra información completa del lector
- Lista de préstamos activos del lector

#### 📋 Ver Préstamos de un Lector
- Consulta específica de préstamos por DNI
- Detalles de cada préstamo (fechas, estado)
- Información del libro prestado

### 📚 **Gestión de Libros**

#### 📚 Agregar Nuevo Libro
- Ingrese título, autor e ISBN
- Validación de campos obligatorios
- Confirmación de agregado exitoso

#### 📖 Ver Todos los Libros
- Lista completa de libros en la biblioteca
- Estado de disponibilidad de cada libro
- Información completa (título, autor, ISBN)

#### 🔍 Buscar Libro por Título
- Búsqueda por título exacto
- Muestra información completa del libro
- Estado de disponibilidad actual

#### 📊 Ver Libros Disponibles
- Solo libros que pueden ser prestados
- Lista filtrada por disponibilidad
- Información básica (título y autor)

#### 📋 Ver Libros Prestados
- Solo libros que están en préstamo
- Lista de libros no disponibles
- Información básica (título y autor)

### 📖 **Gestión de Préstamos**

#### 📖 Prestar Libro
- Ingrese título del libro y DNI del lector
- Validaciones automáticas:
  - ✅ Lector existe
  - ✅ Libro existe y está disponible
  - ✅ Lector no excede límite de 3 préstamos
- Mensajes de resultado detallados

#### 📚 Devolver Libro
- Ingrese título del libro y DNI del lector
- Validación de préstamo activo
- Confirmación de devolución exitosa

#### 📋 Ver Todos los Préstamos
- Lista de préstamos activos
- Información del lector y libro
- Fechas de préstamo y vencimiento
- Estado actual del préstamo

#### 🔍 Buscar Préstamos por Lector
- Consulta por DNI del lector
- Lista de préstamos activos del lector
- Detalles de cada préstamo

#### ⏰ Ver Préstamos Vencidos
- Identificación de préstamos vencidos
- Lista de préstamos que requieren atención
- Fechas de vencimiento

### 📊 **Estadísticas del Sistema**

#### 📈 Información General
- Total de lectores registrados
- Total de libros en biblioteca
- Libros disponibles vs prestados
- Préstamos activos y vencidos

#### 🏆 Top Lectores
- Ranking de lectores por préstamos activos
- Identificación de usuarios más activos
- Estadísticas de uso

### 🧪 **Casos de Prueba Automáticos**

#### 🔬 Pruebas Incluidas
1. **Agregar Libros de Prueba** - 5 libros clásicos
2. **Registrar Lectores** - 3 lectores de prueba
3. **Préstamos Exitosos** - Múltiples préstamos
4. **Prueba de Límite** - Validación de máximo 3 préstamos
5. **Lector Inexistente** - Manejo de errores
6. **Libro Inexistente** - Validación de disponibilidad
7. **Devolución** - Proceso de devolución
8. **Préstamo Post-Devolución** - Nuevo préstamo después de devolución

#### 📋 Resultados de Pruebas
- Ejecución automática de todos los casos
- Mensajes de resultado para cada prueba
- Estado final del sistema después de las pruebas

### 💾 **Persistencia de Datos**

#### 🔄 Guardado Automático
- Los datos se guardan en `datos_biblioteca.json`
- Formato JSON legible y portable
- Incluye fecha y hora de guardado

#### 📂 Carga de Datos
- Recuperación automática al iniciar
- Restauración del estado completo del sistema
- Manejo de errores en archivos corruptos

## 🎮 **Guía de Uso Paso a Paso**

### 1. **Primera Ejecución**
```bash
./run_interactivo.sh
```

### 2. **Explorar el Sistema**
- Use la opción **5** para ejecutar casos de prueba
- Esto llenará el sistema con datos de ejemplo
- Explore las diferentes secciones del menú

### 3. **Probar Funcionalidades**
- **Gestionar Lectores**: Registre nuevos lectores
- **Gestionar Libros**: Agregue libros a la biblioteca
- **Gestionar Préstamos**: Realice préstamos y devoluciones

### 4. **Ver Estadísticas**
- Use la opción **4** para ver el estado del sistema
- Observe cómo cambian las estadísticas con cada operación

### 5. **Guardar y Cargar**
- Use **6** para guardar el estado actual
- Use **7** para cargar datos guardados
- Los datos persisten entre sesiones

## 🔧 **Características Técnicas**

### ✅ **Validaciones Implementadas**
- Registro de lectores duplicados
- Límite de 3 préstamos por lector
- Verificación de existencia de libros
- Validación de disponibilidad
- Manejo de errores robusto

### 📱 **Interfaz de Usuario**
- Menús intuitivos con emojis
- Navegación clara y consistente
- Mensajes de confirmación y error
- Pausas automáticas para lectura

### 💾 **Persistencia**
- Guardado en formato JSON
- Carga automática al iniciar
- Manejo de errores de archivo
- Datos portables entre sistemas

### 🧪 **Testing**
- Casos de prueba automáticos
- Validación de todas las funcionalidades
- Pruebas de casos límite
- Verificación de manejo de errores

## 🎯 **Casos de Uso Recomendados**

### 📚 **Para Estudiantes**
1. Ejecute los casos de prueba para ver el sistema en acción
2. Experimente con diferentes combinaciones de préstamos
3. Pruebe los límites del sistema (máximo 3 préstamos)
4. Explore las estadísticas y reportes

### 👨‍💼 **Para Desarrolladores**
1. Examine el código fuente de las clases
2. Modifique los casos de prueba
3. Agregue nuevas funcionalidades
4. Experimente con la persistencia de datos

### 🏫 **Para Demostraciones**
1. Use los casos de prueba para mostrar funcionalidades
2. Demuestre el manejo de errores
3. Muestre la persistencia de datos
4. Explique las validaciones del sistema

## 🚀 **¡Disfrute Explorando el Sistema!**

La aplicación interactiva le permite probar todas las funcionalidades del sistema de biblioteca de manera segura y controlada. ¡Experimente con diferentes escenarios y vea cómo responde el sistema!

