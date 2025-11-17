# Documentación - API RESTful VeterinariaGenesis

## 📋 Resumen del Proyecto

Esta es una API RESTful de alto rendimiento y seguridad desarrollada en **ASP.NET Core Web API (.NET 8.0)** para la gestión de una clínica veterinaria. La API utiliza **ADO.NET** exclusivamente para el acceso a datos (sin Entity Framework Core), siguiendo una arquitectura en capas con el patrón **MVC/Repository-Service-Controller**.

---

## 🏗️ Arquitectura del Proyecto

### Estructura de Carpetas

```
VeterinariaGenesisAPI/
├── Controllers/          # Controladores REST (Capa de Presentación)
│   ├── AuthController.cs
│   ├── PropietarioController.cs
│   ├── MascotaController.cs
│   ├── CitaController.cs
│   └── FacturaController.cs
├── Services/             # Servicios de Negocio (Capa de Lógica)
│   ├── Interfaces/
│   └── [Servicios].cs
├── Repositories/         # Repositorios de Datos (Capa de Acceso a Datos)
│   ├── Interfaces/
│   └── [Repositorios].cs
├── Models/
│   └── DTOs/            # Data Transfer Objects (DTOs)
├── Helpers/             # Utilidades y Helpers
│   ├── DatabaseHelper.cs
│   └── JwtHelper.cs
└── Program.cs           # Configuración de la aplicación
```

---

## 🔐 Seguridad Implementada

### 1. Autenticación JWT (JSON Web Tokens)

- **Autenticación basada en tokens** para acceso a los endpoints
- **Hash de contraseñas**: Utiliza `HASHBYTES('SHA2_256')` en SQL Server
- **Configuración JWT** en `appsettings.json`:
  - Key, Issuer, Audience
  - Tiempo de expiración: 60 minutos

### 2. Autorización Basada en Roles

La API implementa **3 roles principales**:

- **Administrador**: Acceso completo al sistema
- **Veterinario**: Acceso a sus propias citas y operaciones clínicas
- **Recepcionista**: Acceso a operaciones de recepción

**Políticas de autorización creadas:**
- `Administrador` - Solo administradores
- `Veterinario` - Solo veterinarios
- `Recepcionista` - Solo recepcionistas
- `AdministradorOrVeterinario` - Admin y Veterinario
- `AllRoles` - Todos los roles autenticados

### 3. Control de Acceso Discrecional (DCL)

- **Login de API**: `api_veterinaria_login` (con permisos mínimos)
- **Usuario de BD**: `api_veterinaria_user`
- **Rol**: `rol_api_ejecutor`
- **Permisos**: Solo `EXECUTE` sobre Stored Procedures
- **Denegación**: Acceso directo a tablas denegado (solo vía SPs)

---

## 💾 Capa de Acceso a Datos (ADO.NET)

### DatabaseHelper

Clase central para manejo de conexiones y ejecución de comandos:

**Características:**
- ✅ Usa `SqlConnection`, `SqlCommand`, `SqlDataReader`
- ✅ Ejecución asíncrona (`async/await`)
- ✅ Gestión automática de conexiones (abre/cierra por operación)
- ✅ Prevención de SQL Injection mediante parámetros tipados

**Métodos principales:**
- `ExecuteNonQueryAsync()` - Para INSERT, UPDATE, DELETE
- `ExecuteScalarAsync()` - Para obtener valores únicos (IDs)
- `ExecuteReaderAsync()` - Para consultas que retornan múltiples filas
- `ExecuteReaderSingleAsync()` - Para consultas que retornan una sola fila

### Repositorios

Cada repositorio implementa su interfaz y usa `DatabaseHelper`:

**Repositorios implementados:**
1. **AuthRepository** - Autenticación de usuarios
2. **PropietarioRepository** - CRUD de propietarios
3. **MascotaRepository** - CRUD de mascotas
4. **CitaRepository** - Gestión de citas
5. **FacturaRepository** - Procesamiento de facturas

**Patrón utilizado:**
```csharp
// Ejemplo de uso de parámetros (Prevención SQL Injection)
var parameters = new[]
{
    new SqlParameter("@Nombre", SqlDbType.VarChar, 100) { Value = dto.Nombre },
    new SqlParameter("@Apellidos", SqlDbType.VarChar, 120) { Value = dto.Apellidos }
};
```

---

## 🗄️ Lógica de Negocio en SQL Server

### Stored Procedures (SPs)

**Toda la lógica de negocio reside en SQL Server** mediante Stored Procedures:

#### Seguridad
- `sp_Usuario_Login` - Autenticación con HASHBYTES

#### Propietarios
- `sp_Propietario_Crear` - Crear propietario
- `sp_Propietario_Actualizar` - Actualizar propietario
- `sp_Propietario_Desactivar` - Soft delete
- `sp_Propietario_ListarActivos` - Listar activos (usa vista)
- `sp_Propietario_BuscarPorID` - Buscar por ID

#### Mascotas
- `sp_Mascota_Crear` - Crear mascota
- `sp_Mascota_Actualizar` - Actualizar mascota
- `sp_Mascota_ListarPorPropietario` - Listar por propietario (usa vista)
- `sp_Mascota_BuscarPorID` - Buscar por ID (usa vista)

#### Citas
- `sp_Cita_Agendar` - Agendar cita (valida doble reserva)
- `sp_Cita_Cancelar` - Cancelar cita
- `sp_Cita_ListarPorFecha` - Listar por fecha (usa vista)
- `sp_Cita_ListarPorVeterinario` - Listar por veterinario (usa vista)

#### Facturación (Transaccional)
- `sp_Factura_CrearDesdeCita` - Crear factura desde cita (con transacción)
- `sp_Factura_AgregarItem` - Agregar item a factura
- `sp_Factura_Pagar` - Procesar pago (con transacción)

**Características de los SPs:**
- ✅ Validaciones de negocio (ej: unicidad de correo, doble reserva)
- ✅ Manejo de errores con `TRY...CATCH`
- ✅ Transacciones (`BEGIN TRAN`, `COMMIT TRAN`, `ROLLBACK TRAN`)
- ✅ Uso de `RAISERROR` para errores de negocio

### Vistas (Views)

**Vistas creadas para optimizar consultas:**
- `vw_PropietariosActivos` - Solo propietarios activos
- `vw_MascotasConPropietario` - Mascotas con información del propietario
- `vw_VeterinariosActivos` - Solo veterinarios activos
- `vw_AgendaCitas` - Citas con información completa

### Triggers

**Triggers implementados:**
- `tr_ActualizarTotalFactura` - Recalcula automáticamente el total de facturas al modificar `FacturaDetalle`

---

## 📡 Endpoints de la API

### Autenticación

#### `POST /api/auth/login`
Autentica un usuario y genera un token JWT.

**Request:**
```json
{
  "nombreLogin": "admin",
  "contrasena": "P@ssw0rd123"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "usuario": {
    "id_Usuario": 1,
    "nombreLogin": "admin",
    "nombreCompleto": "Administrador del Sistema",
    "nombreRol": "Administrador",
    "id_Veterinario": null
  }
}
```

---

### Propietarios

#### `GET /api/propietario`
Lista todos los propietarios activos.
- **Autorización**: AllRoles

#### `GET /api/propietario/{id}`
Obtiene un propietario por su ID.
- **Autorización**: AllRoles

#### `POST /api/propietario`
Crea un nuevo propietario.
- **Autorización**: AllRoles
- **Request:**
```json
{
  "nombre": "Juan",
  "apellidos": "Pérez",
  "direccion": "Calle 123",
  "telefono": "1234567890"
}
```

#### `PUT /api/propietario`
Actualiza un propietario existente.
- **Autorización**: AdministradorOrVeterinario

#### `DELETE /api/propietario/{id}`
Desactiva un propietario (soft delete).
- **Autorización**: Administrador

---

### Mascotas

#### `GET /api/mascota/propietario/{idPropietario}`
Lista las mascotas de un propietario.
- **Autorización**: AllRoles

#### `GET /api/mascota/{id}`
Obtiene una mascota por su ID.
- **Autorización**: AllRoles

#### `POST /api/mascota`
Crea una nueva mascota.
- **Autorización**: AllRoles
- **Request:**
```json
{
  "nombre": "Max",
  "especie": "Perro",
  "raza": "Labrador",
  "edad": 5,
  "sexo": "Macho",
  "id_Propietario": 1
}
```

#### `PUT /api/mascota`
Actualiza una mascota existente.
- **Autorización**: AdministradorOrVeterinario

---

### Citas

#### `POST /api/cita/agendar`
Agenda una nueva cita.
- **Autorización**: AllRoles
- **Validación**: Evita doble reserva del veterinario
- **Request:**
```json
{
  "fecha": "2025-01-20",
  "hora": "10:00:00",
  "id_Mascota": 1,
  "id_Veterinario": 1,
  "id_Servicio": 1
}
```

#### `POST /api/cita/{id}/cancelar`
Cancela una cita programada.
- **Autorización**: AllRoles

#### `GET /api/cita/fecha/{fecha}`
Lista las citas de una fecha específica.
- **Autorización**: AllRoles

#### `GET /api/cita/mis-citas`
Lista las citas del veterinario autenticado (usa ID_Veterinario del token).
- **Autorización**: Veterinario

#### `GET /api/cita/veterinario/{idVeterinario}`
Lista las citas de un veterinario específico.
- **Autorización**: Administrador

---

### Facturas

#### `POST /api/factura/desde-cita`
Crea una factura desde una cita (operación transaccional).
- **Autorización**: AllRoles
- **Transacción**: BEGIN TRAN, COMMIT TRAN, ROLLBACK TRAN
- **Request:**
```json
{
  "id_Cita": 1
}
```

#### `POST /api/factura/agregar-item`
Agrega un item adicional a una factura existente.
- **Autorización**: AllRoles
- **Request:**
```json
{
  "id_Factura": 1,
  "id_Servicio": 2,
  "cantidad": 2
}
```

#### `POST /api/factura/pagar`
Procesa el pago de una factura (operación transaccional).
- **Autorización**: AllRoles
- **Transacción**: Actualiza factura, crea pago y actualiza cita
- **Request:**
```json
{
  "id_Factura": 1,
  "montoPagado": 150.00,
  "metodoPago": "Efectivo"
}
```

---

## 🔧 Configuración

### Cadena de Conexión

**appsettings.json:**
```json
{
  "ConnectionStrings": {
    "VeterinariaGenesisDB": "Server=DESKTOP-ND3SPV7;Database=VeterinariaGenesisDB;User Id=api_veterinaria_login;Password=Api.Pass.Vet2025!;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "VeterinariaGenesis2025!SuperSecretKeyForJWTTokenGenerationAndValidation",
    "Issuer": "VeterinariaGenesisAPI",
    "Audience": "VeterinariaGenesisClient",
    "ExpirationMinutes": 60
  }
}
```

### Paquetes NuGet Instalados

- `Microsoft.AspNetCore.Authentication.JwtBearer` (8.0.0) - Autenticación JWT
- `System.Data.SqlClient` (4.8.6) - Acceso a SQL Server con ADO.NET
- `Swashbuckle.AspNetCore` (6.6.2) - Documentación Swagger

---

## 🚀 Flujo de Trabajo

### 1. Autenticación
```
Cliente → POST /api/auth/login
         ↓
         Validación en sp_Usuario_Login (HASHBYTES)
         ↓
         Generación de JWT con roles
         ↓
         Respuesta con token
```

### 2. Operación CRUD
```
Cliente → Endpoint protegido (con JWT)
         ↓
         Controller → Service → Repository
         ↓
         DatabaseHelper → SqlCommand (con parámetros)
         ↓
         Stored Procedure (lógica de negocio)
         ↓
         Respuesta DTO
```

### 3. Operación Transaccional
```
Cliente → POST /api/factura/pagar
         ↓
         Repository ejecuta SP transaccional
         ↓
         SQL Server: BEGIN TRAN
         ↓
         Validaciones y operaciones
         ↓
         COMMIT TRAN o ROLLBACK TRAN
         ↓
         Respuesta con resultado
```

---

## 📝 Ejemplos de Uso

### 1. Login y obtener token

```bash
POST /api/auth/login
Content-Type: application/json

{
  "nombreLogin": "admin",
  "contrasena": "P@ssw0rd123"
}
```

### 2. Crear propietario (con token)

```bash
POST /api/propietario
Authorization: Bearer {token}
Content-Type: application/json

{
  "nombre": "Carlos",
  "apellidos": "González",
  "direccion": "Av. Principal 456",
  "telefono": "9876543210"
}
```

### 3. Agendar cita

```bash
POST /api/cita/agendar
Authorization: Bearer {token}
Content-Type: application/json

{
  "fecha": "2025-01-25T00:00:00",
  "hora": "14:30:00",
  "id_Mascota": 1,
  "id_Veterinario": 1,
  "id_Servicio": 1
}
```

---

## 🔍 Características Técnicas Destacadas

### Prevención de SQL Injection
- ✅ **Uso exclusivo de parámetros tipados** en todos los comandos
- ✅ **Nunca concatenación de strings** para construir queries
- ✅ **SqlParameter con tipos específicos** (SqlDbType.VarChar, SqlDbType.Int, etc.)

### Manejo de Errores
- ✅ **TRY...CATCH en Stored Procedures** para errores de negocio
- ✅ **RAISERROR para validaciones** de negocio
- ✅ **InvalidOperationException** en repositorios para errores de negocio
- ✅ **Logging estructurado** en controladores

### Optimización
- ✅ **Vistas materializadas** para consultas frecuentes
- ✅ **Índices en tablas** para mejor rendimiento
- ✅ **Conexiones por operación** (no persistentes)
- ✅ **Ejecución asíncrona** en toda la API

### Transacciones
- ✅ **Transacciones en SQL Server** (no en código C#)
- ✅ **Atomicidad garantizada** en operaciones críticas
- ✅ **Rollback automático** en caso de error

---

## 📚 Scripts SQL Requeridos

**Orden de ejecución:**

1. **VeterinariaNGenesisDB.sql**
   - Crea la base de datos
   - Crea todas las tablas
   - Crea índices

2. **SP,Trigger,users-Veterinaria.sql**
   - Crea login y usuario de API
   - Crea tablas de seguridad (Roles, Usuario)
   - Crea vistas
   - Crea triggers
   - Crea todos los Stored Procedures
   - Asigna permisos (DCL)

---

## 🧪 Usuarios de Prueba

Los siguientes usuarios están creados en la base de datos (todos con contraseña: `P@ssw0rd123`):

| Usuario | Rol | Descripción |
|---------|-----|-------------|
| `admin` | Administrador | Administrador del Sistema |
| `asolis` | Veterinario | Dr. Alejandro Solís (ID_Veterinario: 1) |
| `bpena` | Veterinario | Dra. Beatriz Peña (ID_Veterinario: 2) |
| `r.gomez` | Recepcionista | Raquel Gómez (Recepción) |
| `j.perez` | Recepcionista | Javier Pérez (Recepción) |

---

## 📌 Notas Importantes

1. **La API NO accede directamente a las tablas** - Solo ejecuta Stored Procedures
2. **Toda la lógica de negocio está en SQL Server** - Los repositorios son "delgados"
3. **Autenticación obligatoria** - Todos los endpoints (excepto login) requieren JWT
4. **Autorización por roles** - Cada endpoint tiene políticas de acceso específicas
5. **Transacciones manejadas en SQL** - Las transacciones están en los SPs, no en C#

---

## 🎯 Ventajas de esta Arquitectura

✅ **Seguridad**: DCL en SQL Server, parámetros tipados, JWT
✅ **Rendimiento**: Vistas optimizadas, índices, ejecución asíncrona
✅ **Mantenibilidad**: Separación de capas, código limpio
✅ **Escalabilidad**: Arquitectura modular y extensible
✅ **Auditoría**: Triggers automáticos, logging estructurado

---

**Desarrollado con:** ASP.NET Core 8.0, ADO.NET, SQL Server, JWT Authentication
**Patrón Arquitectónico:** MVC / Repository-Service-Controller
**Fecha de creación:** Enero 2025


