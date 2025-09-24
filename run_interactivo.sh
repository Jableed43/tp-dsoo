#!/bin/bash

echo "=== SISTEMA DE BIBLIOTECA INTERACTIVO - COMPILACIÓN Y EJECUCIÓN ==="
echo

# Verificar si dotnet está instalado
if ! command -v dotnet &> /dev/null; then
    echo "Error: .NET SDK no está instalado."
    echo "Por favor, instala .NET 8.0 o superior desde https://dotnet.microsoft.com/download"
    exit 1
fi

echo "Versión de .NET:"
dotnet --version
echo

# Restaurar dependencias
echo "Restaurando dependencias..."
dotnet restore
echo

# Compilar el proyecto
echo "Compilando el proyecto..."
dotnet build
echo

# Verificar si la compilación fue exitosa
if [ $? -eq 0 ]; then
    echo "✅ Compilación exitosa!"
    echo
    echo "🚀 Iniciando aplicación interactiva..."
    echo "═══════════════════════════════════════════════════════════════"
    echo
    echo "💡 CONSEJOS DE USO:"
    echo "   • Use el menú para navegar por las opciones"
    echo "   • Los datos se guardan automáticamente en 'datos_biblioteca.json'"
    echo "   • Puede probar todas las funcionalidades del sistema"
    echo "   • Use la opción 'Casos de Prueba' para ver ejemplos"
    echo
    echo "Presione Enter para continuar..."
    read
    echo
    dotnet run --no-build
else
    echo "❌ Error en la compilación"
    exit 1
fi

u