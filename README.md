# Hola Mundo en C#

Este es un programa simple de "Hola Mundo" escrito en C#.

##  Requisitos previos

### Windows
1. Descarga el SDK de .NET: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
2. Instálalo con las opciones por defecto
3. Verifica la instalación abriendo una nueva terminal y escribiendo:
   ```
   dotnet --version
   ```
   Deberías ver un número de versión (ej: 8.0.100)

### Linux (Ubuntu/Debian)
Abre una terminal y ejecuta estos comandos uno por uno:
```bash
# 1. Instalar dependencias
sudo apt update
sudo apt install -y wget

# 2. Descargar e instalar .NET SDK
wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

# 3. Instalar el SDK
sudo apt update
sudo apt install -y dotnet-sdk-8.0

# 4. Verificar instalación
dotnet --version
```

##  Cómo ejecutar el programa

### En Windows:
1. Abre el Explorador de archivos
2. Navega a la carpeta `d:\Docs\C learning\HolaMundo`
3. Haz clic en la barra de direcciones, escribe `cmd` y presiona Enter
4. En la terminal que se abre, escribe:
   ```
   dotnet run
   ```

### En Linux:
1. Abre una terminal
2. Navega a la carpeta del proyecto:
   ```bash
   cd /ruta/completa/hasta/HolaMundo
   ```
3. Ejecuta el programa:
   ```bash
   dotnet run
   ```

## 🔍 ¿Qué hace el programa?

El archivo `Program.cs` contiene este código:

```csharp
using System;

class Program
{
    static void Main()
    {
        // Muestra "¡Hola Mundo!" en la consola
        Console.WriteLine("¡Hola Mundo!");
        
        // Espera a que el usuario presione una tecla
        Console.ReadKey();
    }
}
```

##  Solución de problemas

- Si ves `'dotnet' no se reconoce como un comando interno o externo`:
  - En Windows: Cierra y vuelve a abrir la terminal
  - En Linux: Verifica que instalaste el SDK correctamente

- Si ves errores de compilación:
  ```
  dotnet restore
  dotnet build
  ```

##  Recursos útiles
- [Descargar .NET](https://dotnet.microsoft.com/download)
- [Documentación de C#](https://docs.microsoft.com/es-es/dotnet/csharp/)
