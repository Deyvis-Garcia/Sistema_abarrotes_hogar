# AbarrotesHogar - API REST

API REST para la gestión de productos, inventario, compras, ventas, proveedores y usuarios de un negocio de abarrotes. Está desarrollada con ASP.NET Core Web API, Entity Framework Core y SQL Server.

## Descripción general y arquitectura

El proyecto separa responsabilidades por capas:

- `Controllers`: rutas HTTP, autorización y enlace de parámetros y cuerpos JSON.
- `Services`: operaciones de negocio, validaciones de referencias y conversión entre modelos y DTOs.
- `Repository`: acceso a datos mediante Entity Framework Core.
- `Models`: entidades persistidas.
- `Dtos`: objetos de solicitud y respuesta de la API.
- `Data`: `AppDbContext`, configuraciones de EF Core y migraciones.
- `Middlewares`: manejo centralizado de excepciones.
- `Excepciones`: excepciones de dominio como `RecursoNoEncontradoException` y `ConflictoException`.

La autenticación usa JWT. `POST /api/Auth/login` es público; las demás rutas requieren un token salvo que se indique lo contrario en el catálogo. Algunas operaciones administrativas requieren el rol `Administrador`.

## Configuración y ejecución local

### Requisitos

- .NET SDK 10.
- SQL Server, SQL Server Express o LocalDB.
- La herramienta `dotnet-ef` compatible con la versión de Entity Framework Core 10 del proyecto.

Instala la herramienta si aún no está disponible:

```bash
dotnet tool install --global dotnet-ef
```

### Configuración

Configura en `appsettings.json` o mediante variables de entorno:

- `ConnectionStrings:Default`: cadena de conexión a SQL Server.
- `Jwt:Key`: clave secreta para firmar tokens; utiliza una clave aleatoria de al menos 32 bytes y no la publiques.
- `Jwt:Issuer`: emisor esperado del token.
- `Jwt:Audience`: audiencia esperada del token.
- `Jwt:ExpireMinutes`: duración del token en minutos. Si no es un número positivo, el servicio de autenticación usa 60 minutos.

Ejemplo de estructura, con valores que debes reemplazar:

```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost;Database=bd_abarrotes_hogar;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "REEMPLAZAR_POR_UN_SECRETO_ALEATORIO_DE_32_BYTES_O_MAS",
    "Issuer": "AbarrotesHogarApi",
    "Audience": "AbarrotesHogarCliente",
    "ExpireMinutes": 60
  }
}
```

Las variables de entorno equivalentes usan `ConnectionStrings__Default`, `Jwt__Key`, `Jwt__Issuer`, `Jwt__Audience` y `Jwt__ExpireMinutes`.

### Restaurar, aplicar migraciones e iniciar

Desde la carpeta del proyecto:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

El proyecto incluye migraciones EF Core. La cadena `ConnectionStrings:Default` debe apuntar a una instancia de SQL Server disponible antes de aplicar la actualización de la base de datos. Los perfiles de desarrollo de `launchSettings.json` usan `http://localhost:5056` y `https://localhost:7075`. En Development también se publica el documento OpenAPI en `/openapi/v1.json`.

## Catálogo de endpoints

Las rutas usan el prefijo `api/`. Los métodos `POST` y `PUT` reciben sus DTOs mediante cuerpo JSON (`[FromBody]`). `{id}` es un parámetro de ruta. Los tres listados paginados reciben `pagina` y `tamano` como query string.

### Autenticación

| Método | Ruta | Entrada | Acceso y comportamiento |
|---|---|---|---|
| POST | `/api/Auth/login` | `AuthRequest` en JSON: `Usuario`, `Contraseña` | Público. Devuelve un JWT cuando las credenciales son válidas. |

### Productos

Todas las rutas requieren autenticación. Las operaciones marcadas como **Administrador** requieren además el rol `Administrador`.

| Método | Ruta | Entrada | Acceso y comportamiento |
|---|---|---|---|
| GET | `/api/Productos` | Query: `pagina` (por defecto 1), `tamano` (por defecto 10) | Devuelve `ResultadoPaginado<ProductoResponse>`. |
| GET | `/api/Productos/{id}` | Ruta: `id` | Obtiene un producto. |
| GET | `/api/Productos/eliminados` | — | **Administrador**. Lista productos eliminados lógicamente. |
| POST | `/api/Productos` | `ProductoRequest` en JSON | **Administrador**. Crea un producto. |
| PUT | `/api/Productos/{id}` | Ruta: `id`; `ProductoRequest` en JSON | **Administrador**. Actualiza un producto. |
| DELETE | `/api/Productos/{id}` | Ruta: `id` | **Administrador**. Marca el producto como eliminado. |
| PATCH | `/api/Productos/{id}/recuperar` | Ruta: `id` | **Administrador**. Recupera un producto eliminado. |

### Ventas

Todas las rutas requieren autenticación. La eliminación requiere el rol `Administrador`.

| Método | Ruta | Entrada | Acceso y comportamiento |
|---|---|---|---|
| GET | `/api/Ventas` | Query: `pagina` (por defecto 1), `tamano` (por defecto 10) | Devuelve `ResultadoPaginado<VentasResponse>`. |
| GET | `/api/Ventas/{id}` | Ruta: `id` | Obtiene una venta. |
| POST | `/api/Ventas` | `VentasRequest` en JSON | Crea una venta. |
| PUT | `/api/Ventas/{id}` | Ruta: `id`; `VentasRequest` en JSON | Actualiza una venta. |
| DELETE | `/api/Ventas/{id}` | Ruta: `id` | **Administrador**. Elimina una venta. |

### Compras

Todas las rutas requieren autenticación. La eliminación requiere el rol `Administrador`.

| Método | Ruta | Entrada | Acceso y comportamiento |
|---|---|---|---|
| GET | `/api/Compras` | Query: `pagina` (por defecto 1), `tamano` (por defecto 10) | Devuelve `ResultadoPaginado<ComprasResponse>`. |
| GET | `/api/Compras/{id}` | Ruta: `id` | Obtiene una compra. |
| POST | `/api/Compras` | `ComprasRequest` en JSON | Crea una compra. |
| PUT | `/api/Compras/{id}` | Ruta: `id`; `ComprasRequest` en JSON | Actualiza una compra. |
| DELETE | `/api/Compras/{id}` | Ruta: `id` | **Administrador**. Elimina una compra. |

### Detalles de compra

Todas las rutas requieren autenticación. La eliminación requiere el rol `Administrador`.

| Método | Ruta | Entrada | Acceso y comportamiento |
|---|---|---|---|
| GET | `/api/DetalleCompra` | — | Lista detalles de compra. |
| GET | `/api/DetalleCompra/{id}` | Ruta: `id` | Obtiene un detalle. |
| POST | `/api/DetalleCompra` | `DetalleCompraRequest` en JSON | Crea un detalle; el servicio calcula el subtotal usando cantidad y precio unitario. |
| PUT | `/api/DetalleCompra/{id}` | Ruta: `id`; `DetalleCompraRequest` en JSON | Actualiza un detalle y calcula el subtotal. |
| DELETE | `/api/DetalleCompra/{id}` | Ruta: `id` | **Administrador**. Elimina un detalle. |

### Detalles de venta

Todas las rutas requieren autenticación. La eliminación requiere el rol `Administrador`.

| Método | Ruta | Entrada | Acceso y comportamiento |
|---|---|---|---|
| GET | `/api/DetalleVenta` | — | Lista detalles de venta. |
| GET | `/api/DetalleVenta/{id}` | Ruta: `id` | Obtiene un detalle. |
| POST | `/api/DetalleVenta` | `DetalleVentaRequest` en JSON | Crea un detalle; el servicio calcula el subtotal usando cantidad y precio unitario. |
| PUT | `/api/DetalleVenta/{id}` | Ruta: `id`; `DetalleVentaRequest` en JSON | Actualiza un detalle y calcula el subtotal. |
| DELETE | `/api/DetalleVenta/{id}` | Ruta: `id` | **Administrador**. Elimina un detalle. |

### Lotes de inventario

Todas las rutas requieren autenticación. Las operaciones de escritura y eliminación requieren el rol `Administrador`.

| Método | Ruta | Entrada | Acceso y comportamiento |
|---|---|---|---|
| GET | `/api/InventarioLotes` | — | Lista lotes. |
| GET | `/api/InventarioLotes/{id}` | Ruta: `id` | Obtiene un lote. |
| POST | `/api/InventarioLotes` | `InventarioLotesRequest` en JSON | **Administrador**. Crea un lote. |
| PUT | `/api/InventarioLotes/{id}` | Ruta: `id`; `InventarioLotesRequest` en JSON | **Administrador**. Actualiza un lote. |
| DELETE | `/api/InventarioLotes/{id}` | Ruta: `id` | **Administrador**. Elimina un lote. |

### Proveedores

Todas las rutas requieren autenticación. Las operaciones administrativas requieren el rol `Administrador`.

| Método | Ruta | Entrada | Acceso y comportamiento |
|---|---|---|---|
| GET | `/api/Proveedor` | — | Lista proveedores activos. |
| GET | `/api/Proveedor/{id}` | Ruta: `id` | Obtiene un proveedor activo. |
| GET | `/api/Proveedor/eliminados` | — | **Administrador**. Lista proveedores eliminados lógicamente. |
| POST | `/api/Proveedor` | `ProveedorRequest` en JSON | **Administrador**. Crea un proveedor. |
| PUT | `/api/Proveedor/{id}` | Ruta: `id`; `ProveedorRequest` en JSON | **Administrador**. Actualiza un proveedor. |
| DELETE | `/api/Proveedor/{id}` | Ruta: `id` | **Administrador**. Marca el proveedor como eliminado. |
| PATCH | `/api/Proveedor/{id}/recuperar` | Ruta: `id` | **Administrador**. Recupera un proveedor eliminado. |

### Usuarios

Todas las rutas requieren el rol `Administrador`.

| Método | Ruta | Entrada | Acceso y comportamiento |
|---|---|---|---|
| GET | `/api/Usuarios` | — | Lista usuarios activos. |
| GET | `/api/Usuarios/{id}` | Ruta: `id` | Obtiene un usuario activo. |
| GET | `/api/Usuarios/eliminados` | — | Lista usuarios eliminados lógicamente. |
| POST | `/api/Usuarios` | `UsuariosRequest` en JSON | Crea un usuario; la contraseña se almacena con BCrypt. |
| PUT | `/api/Usuarios/{id}` | Ruta: `id`; `UsuariosRequest` en JSON | Actualiza un usuario. |
| DELETE | `/api/Usuarios/{id}` | Ruta: `id` | Marca el usuario como eliminado. |
| PATCH | `/api/Usuarios/{id}/recuperar` | Ruta: `id` | Recupera un usuario eliminado. |

## Reglas de negocio y manejo de errores

### Borrado lógico

`AppDbContext` aplica filtros globales `Estado == true` a `Productos`, `Usuarios` y `Proveedores`. Las consultas normales ocultan los registros inactivos. Los servicios/repositorios de productos, usuarios y proveedores incluyen operaciones para listarlos por separado y recuperarlos. Compras, ventas, detalles y lotes no tienen ese filtro global.

### Paginación

Solo los listados generales de productos, ventas y compras están paginados. Sus controladores normalizan los parámetros antes de llamar a los servicios:

- `pagina < 1` se convierte en `1`.
- `tamano < 1` se convierte en `1`.
- `tamano > 50` se convierte en `50`.
- Valores omitidos: `pagina=1` y `tamano=10`.

Los repositorios cuentan los registros y obtienen la página ordenada por ID con `AsNoTracking`, `Skip` y `Take`. `ResultadoPaginado<T>` incluye `Datos`, `Total`, `Pagina`, `TamanoPagina` y `TotalPaginas` (`ceil(Total / TamanoPagina)`). Las listas de los otros recursos no usan paginación.

### Validaciones y servicios

- `Ventas` comprueba en el servicio que exista el usuario referenciado.
- `Compras` comprueba que existan el proveedor y el usuario referenciados.
- Los DTOs aplican validaciones de Data Annotations, por ejemplo campos obligatorios, longitudes, rangos y formato de RUC/correo/teléfono. Al estar los controladores marcados con `[ApiController]`, un modelo inválido se rechaza automáticamente con HTTP 400.
- Los detalles de compra y venta calculan el subtotal como `Cantidad * Precio_unitario`.
- El servicio de usuarios impide nombres de usuario duplicados, valida que usuario y contraseña no estén vacíos, y almacena la contraseña con BCrypt. `UsuariosRequest` restringe los roles a `Administrador`, `Usuario` o `Vendedor`.
- El login rechaza credenciales incorrectas o usuarios inactivos. El JWT incluye identificador, nombre de usuario y rol.

### Respuestas de error

`ManejoErroresMiddleware` convierte excepciones de servicios a `ErrorResponse`:

| Excepción | HTTP |
|---|---:|
| `RecursoNoEncontradoException` | 404 |
| `ConflictoException` | 409 |
| `ArgumentException` | 400 |
| `UnauthorizedAccessException` | 401 |
| Cualquier otra excepción | 500 |

El JSON de `ErrorResponse` contiene `status`, `mensaje` y `fecha` (el serializador web los representa normalmente como `status`, `mensaje` y `fecha`). Los errores 500 usan un mensaje genérico y se registran en el log. La autenticación JWT también devuelve JSON para 401 y 403; la falta de autenticación o un token inválido genera 401, y un rol insuficiente genera 403. Las respuestas automáticas de validación de `[ApiController]` pueden tener el formato de errores de validación de ASP.NET Core en lugar de `ErrorResponse`.

## Guía de pruebas

Los ejemplos usan el perfil HTTP local (`http://localhost:5056`). Sustituye `{{token}}` por el campo `token` devuelto al iniciar sesión y utiliza identificadores que existan en tu base de datos cuando quieras probar un caso exitoso.

### Iniciar sesión y obtener un token

```http
POST http://localhost:5056/api/Auth/login
Content-Type: application/json

{
  "usuario": "usuario_existente",
  "contraseña": "ContraseñaDePrueba1"
}
```

La respuesta exitosa contiene `id_usuario`, `usuario`, `rol`, `mensaje`, `expiracion` y `token`.

### Consultas exitosas y paginación

```http
GET http://localhost:5056/api/Productos?pagina=1&tamano=10
Authorization: Bearer {{token}}
```

También se puede comprobar la normalización de parámetros fuera de rango:

```http
GET http://localhost:5056/api/Productos?pagina=0&tamano=999
Authorization: Bearer {{token}}
```

La respuesta paginada refleja `pagina: 1` y `tamanoPagina: 50`. Los listados de ventas y compras siguen el mismo formato:

```http
GET http://localhost:5056/api/Ventas?pagina=1&tamano=10
Authorization: Bearer {{token}}

GET http://localhost:5056/api/Compras?pagina=1&tamano=10
Authorization: Bearer {{token}}
```

### Crear un producto

Requiere un token con rol `Administrador`:

```http
POST http://localhost:5056/api/Productos
Authorization: Bearer {{token_admin}}
Content-Type: application/json

{
  "nombre": "Arroz",
  "descripcion": "Arroz de prueba",
  "precio_venta": 4.50,
  "stock_actual": 20,
  "stock_minimo": 5,
  "estado": true
}
```

### Probar errores

**401 — token ausente o inválido**

```http
GET http://localhost:5056/api/Productos
```

La respuesta de autenticación usa el formato `ErrorResponse`, por ejemplo:

```json
{
  "status": 401,
  "mensaje": "No está autenticado o el token no es válido.",
  "fecha": "2026-01-01T12:00:00"
}
```

**403 — token válido, rol insuficiente**

Envía el `POST /api/Productos` de creación con un token que no tenga rol `Administrador`. La ruta requiere ese rol y responderá HTTP 403.

**404 — identificador inexistente**

```http
GET http://localhost:5056/api/Productos/2147483647
Authorization: Bearer {{token}}
```

Si el producto no existe, el servicio lanza `RecursoNoEncontradoException` y el middleware responde HTTP 404.

**400 — datos inválidos**

```http
POST http://localhost:5056/api/Productos
Authorization: Bearer {{token_admin}}
Content-Type: application/json

{
  "nombre": "",
  "descripcion": "Prueba",
  "precio_venta": -1,
  "stock_actual": -2,
  "stock_minimo": 0,
  "estado": true
}
```

El nombre obligatorio y los rangos del DTO no se cumplen, por lo que `[ApiController]` responde HTTP 400 con los detalles de validación.

**409 — usuario duplicado**

Requiere un token `Administrador`. Envía `POST /api/Usuarios` con todos los campos válidos, pero usa en `usuario` un nombre que ya esté registrado:

```http
POST http://localhost:5056/api/Usuarios
Authorization: Bearer {{token_admin}}
Content-Type: application/json

{
  "nombre": "Ana",
  "apellido": "Prueba",
  "usuario": "usuario_ya_registrado",
  "contraseña": "ClaveSegura1",
  "rol": "Vendedor",
  "estado": true
}
```

El servicio lanza `ConflictoException` y el middleware responde HTTP 409.
