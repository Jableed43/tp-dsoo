-- Esquema de Base de Datos para Sistema de Biblioteca
-- Incluye gestión de lectores, libros y préstamos

-- Tabla de Lectores
CREATE TABLE lectores (
    id_lector SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    dni VARCHAR(20) UNIQUE NOT NULL,
    fecha_registro TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    activo BOOLEAN DEFAULT TRUE
);

-- Tabla de Libros
CREATE TABLE libros (
    id_libro SERIAL PRIMARY KEY,
    titulo VARCHAR(200) NOT NULL,
    autor VARCHAR(100),
    isbn VARCHAR(20),
    editorial VARCHAR(100),
    año_publicacion INTEGER,
    disponible BOOLEAN DEFAULT TRUE,
    fecha_ingreso TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabla de Préstamos
CREATE TABLE prestamos (
    id_prestamo SERIAL PRIMARY KEY,
    id_lector INTEGER NOT NULL,
    id_libro INTEGER NOT NULL,
    fecha_prestamo TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_vencimiento TIMESTAMP,
    fecha_devolucion TIMESTAMP,
    estado VARCHAR(20) DEFAULT 'ACTIVO', -- ACTIVO, DEVUELTO, VENCIDO
    FOREIGN KEY (id_lector) REFERENCES lectores(id_lector) ON DELETE CASCADE,
    FOREIGN KEY (id_libro) REFERENCES libros(id_libro) ON DELETE CASCADE
);

-- Índices para optimizar consultas
CREATE INDEX idx_lectores_dni ON lectores(dni);
CREATE INDEX idx_libros_titulo ON libros(titulo);
CREATE INDEX idx_prestamos_lector ON prestamos(id_lector);
CREATE INDEX idx_prestamos_estado ON prestamos(estado);
CREATE INDEX idx_prestamos_fecha ON prestamos(fecha_prestamo);

-- Vista para consultar préstamos activos por lector
CREATE VIEW prestamos_activos_por_lector AS
SELECT 
    l.id_lector,
    l.nombre,
    l.dni,
    COUNT(p.id_prestamo) as prestamos_activos
FROM lectores l
LEFT JOIN prestamos p ON l.id_lector = p.id_lector AND p.estado = 'ACTIVO'
GROUP BY l.id_lector, l.nombre, l.dni;

-- Función para verificar si un lector puede realizar más préstamos
CREATE OR REPLACE FUNCTION puede_prestar_libro(p_dni VARCHAR)
RETURNS BOOLEAN AS $$
DECLARE
    prestamos_count INTEGER;
BEGIN
    SELECT COUNT(*)
    INTO prestamos_count
    FROM prestamos p
    JOIN lectores l ON p.id_lector = l.id_lector
    WHERE l.dni = p_dni AND p.estado = 'ACTIVO';
    
    RETURN prestamos_count < 3;
END;
$$ LANGUAGE plpgsql;

-- Función para realizar un préstamo
CREATE OR REPLACE FUNCTION prestar_libro(
    p_titulo_libro VARCHAR,
    p_dni_lector VARCHAR
)
RETURNS VARCHAR AS $$
DECLARE
    v_id_lector INTEGER;
    v_id_libro INTEGER;
    v_prestamos_actuales INTEGER;
    v_resultado VARCHAR;
BEGIN
    -- Verificar si el lector existe
    SELECT id_lector INTO v_id_lector
    FROM lectores
    WHERE dni = p_dni_lector AND activo = TRUE;
    
    IF v_id_lector IS NULL THEN
        RETURN 'LECTOR INEXISTENTE';
    END IF;
    
    -- Verificar si el libro existe y está disponible
    SELECT id_libro INTO v_id_libro
    FROM libros
    WHERE titulo = p_titulo_libro AND disponible = TRUE;
    
    IF v_id_libro IS NULL THEN
        RETURN 'LIBRO INEXISTENTE';
    END IF;
    
    -- Verificar si el lector puede realizar más préstamos
    SELECT COUNT(*) INTO v_prestamos_actuales
    FROM prestamos
    WHERE id_lector = v_id_lector AND estado = 'ACTIVO';
    
    IF v_prestamos_actuales >= 3 THEN
        RETURN 'TOPE DE PRESTAMO ALCANZADO';
    END IF;
    
    -- Realizar el préstamo
    INSERT INTO prestamos (id_lector, id_libro, fecha_vencimiento)
    VALUES (v_id_lector, v_id_libro, CURRENT_TIMESTAMP + INTERVAL '15 days');
    
    -- Marcar el libro como no disponible
    UPDATE libros SET disponible = FALSE WHERE id_libro = v_id_libro;
    
    RETURN 'PRESTAMO EXITOSO';
END;
$$ LANGUAGE plpgsql;

-- Función para devolver un libro
CREATE OR REPLACE FUNCTION devolver_libro(
    p_titulo_libro VARCHAR,
    p_dni_lector VARCHAR
)
RETURNS BOOLEAN AS $$
DECLARE
    v_id_prestamo INTEGER;
BEGIN
    -- Buscar el préstamo activo
    SELECT p.id_prestamo INTO v_id_prestamo
    FROM prestamos p
    JOIN lectores l ON p.id_lector = l.id_lector
    JOIN libros li ON p.id_libro = li.id_libro
    WHERE l.dni = p_dni_lector 
    AND li.titulo = p_titulo_libro 
    AND p.estado = 'ACTIVO';
    
    IF v_id_prestamo IS NULL THEN
        RETURN FALSE;
    END IF;
    
    -- Marcar préstamo como devuelto
    UPDATE prestamos 
    SET estado = 'DEVUELTO', fecha_devolucion = CURRENT_TIMESTAMP
    WHERE id_prestamo = v_id_prestamo;
    
    -- Marcar libro como disponible
    UPDATE libros 
    SET disponible = TRUE
    WHERE id_libro = (
        SELECT id_libro FROM prestamos WHERE id_prestamo = v_id_prestamo
    );
    
    RETURN TRUE;
END;
$$ LANGUAGE plpgsql;

-- Datos de ejemplo
INSERT INTO lectores (nombre, dni) VALUES 
('Juan Pérez', '12345678'),
('María García', '87654321'),
('Carlos López', '11223344');

INSERT INTO libros (titulo, autor, isbn, editorial, año_publicacion) VALUES 
('El Quijote', 'Miguel de Cervantes', '978-84-376-0494-7', 'Cátedra', 1605),
('Cien años de soledad', 'Gabriel García Márquez', '978-84-376-0494-8', 'Cátedra', 1967),
('Don Juan Tenorio', 'José Zorrilla', '978-84-376-0494-9', 'Cátedra', 1844),
('La Celestina', 'Fernando de Rojas', '978-84-376-0495-0', 'Cátedra', 1499),
('Lazarillo de Tormes', 'Anónimo', '978-84-376-0495-1', 'Cátedra', 1554);

