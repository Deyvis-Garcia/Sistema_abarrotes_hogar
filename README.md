# AbarrotesHogar - API REST

API REST desarrollada en **C# con .NET Core (ASP.NET Core Web API)** y **Entity Framework Core** utilizando SQL Server como base de datos, orientada a la gestión de inventario, compras, ventas, proveedores y usuarios para un negocio de abarrotes.

---

## 📋 Requisitos Previos

Antes de clonar y ejecutar el proyecto en tu máquina local, asegúrate de tener instalado lo siguiente:

* [.NET SDK](https://dotnet.microsoft.com/download) (versión 10.0 o compatible con el proyecto).
* [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (o SQL Server Express / LocalDB).
* [Visual Studio 2022](https://visualstudio.microsoft.com/es/) o [Visual Studio Code](https://code.visualstudio.com/).
* [Entity Framework Core Tools (dotnet-ef)](https://learn.microsoft.com/es-es/ef/core/cli/dotnet) instalado globalmente (opcional pero recomendado para migraciones):
  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

## 🚀 Instalación y Configuración

Sigue estos pasos detallados para poner en marcha el proyecto localmente:

### 1. Clonar el repositorio
Abre tu terminal (PowerShell, CMD o Git Bash) y ejecuta el siguiente comando:
```bash
git clone https://github.com/Deyvis-Garcia/Sistema_abarrotes_hogar.git
```

### 2. Entrar a la carpeta del proyecto
```bash
cd AbarrotesHogar
```

### 3. Configurar la Cadena de Conexión
Busca el archivo `appsettings.json` en la raíz del proyecto y asegúrate de que la cadena de conexión apunte correctamente a tu instancia local de SQL Server:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
    "ConnectionStrings": {
    "Default": "Server=DESKTOP-AMHKLDO;Database=bd_abarrotes_hogar;Trusted_Connection=True;TrustServerCertificate=True;"
  } 
}
```

### 4. Restaurar las Dependencias
Restaura los paquetes NuGet ejecutando:
```bash
dotnet restore
```

### 5. Aplicar Migraciones y Crear la Base de Datos
Asegúrate de tener creada la base de datos `bd_abarrotes_hogar` en tu SQL Server. Luego, ejecuta el siguiente comando para generar las tablas correspondientes a través de Entity Framework Core:
```bash
dotnet ef database update
```

### 6. Ejecutar la Aplicación
Inicia el servidor local de desarrollo con:
```bash
dotnet run
```

---

## 🧪 Pruebas con Postman

Para verificar los endpoints de la API:
1. Abre **Postman**.
2. Importa el archivo `AbarrotesHogar.postman_collection.json` incluido en el proyecto.
3. Comienza a realizar y probar las peticiones al servidor local.
