==================================================================================
ORDEN DE EJECUCIÓN DE SCRIPTS SQL - VeterinariaGenesisDB
==================================================================================

INSTRUCCIONES PARA CREAR LA BASE DE DATOS COMPLETA EN OTRA LAPTOP:

1. Abre SQL Server Management Studio (SSMS)
2. Conéctate a tu instancia de SQL Server con permisos de administrador (sa o dbo)
3. Ejecuta los siguientes scripts EN ORDEN, uno por uno:

==================================================================================
ORDEN DE EJECUCIÓN:
==================================================================================

1. 01_Esquema_Base.sql
   - Crea la base de datos VeterinariaGenesisDB
   - Crea todas las tablas necesarias
   - Crea las restricciones y claves foráneas

2. 02_Indices.sql
   - Crea los índices para optimizar las consultas

3. 03_Triggers.sql
   - Crea los triggers para automatización (actualización de totales, citas pasadas)

4. 04_StoredProcedures_CRUD.sql
   - Crea los SPs principales de CRUD (Propietario, Mascota, Cita, Usuario)

5. 05_StoredProcedures_Facturas.sql
   - Crea los SPs de facturación (crear, pagar, buscar, listar)

6. 06_StoredProcedures_Historial.sql
   - Crea los SPs de historial clínico

7. 07_StoredProcedures_Dashboard.sql
   - Crea los SPs de dashboard y estadísticas

8. 08_StoredProcedures_Vacunas.sql
   - Crea los SPs de recordatorios de vacunación

9. 09_StoredProcedures_Reportes.sql
   - Crea los SPs de reportes

10. 10_StoredProcedures_Servicios.sql
    - Crea los SPs de servicios y veterinarios

11. 11_Vistas.sql
    - Crea las vistas para simplificar consultas

12. 12_Usuarios_Permisos.sql
    - Crea el login/usuario de la API
    - Crea los roles y usuarios de ejemplo
    - Asigna todos los permisos necesarios

13. 13_Datos.sql
    - Inserta todos los datos de ejemplo (propietarios, mascotas, citas, facturas, etc.)

==================================================================================
NOTAS IMPORTANTES:
==================================================================================

- Ejecuta los scripts en el orden indicado
- Si un script muestra errores, revísalos antes de continuar
- El script 12_Usuarios_Permisos.sql crea el usuario de la API con la contraseña:
  Usuario: api_veterinaria_login
  Contraseña: Api.Pass.Vet2025!
  
- Los usuarios de ejemplo creados tienen la contraseña: P@ssw0rd123
  - admin (Administrador)
  - asolis (Veterinario)
  - bpena (Veterinario)
  - r.gomez (Recepcionista)
  - j.perez (Recepcionista)

- Después de ejecutar todos los scripts, tu aplicación Windows Forms debería
  funcionar correctamente conectándose a esta base de datos.

==================================================================================
VERIFICACIÓN:
==================================================================================

Después de ejecutar todos los scripts, puedes verificar que todo esté correcto:

1. Verifica que la base de datos existe:
   SELECT name FROM sys.databases WHERE name = 'VeterinariaGenesisDB';

2. Verifica que los SPs fueron creados:
   SELECT name FROM sys.procedures WHERE schema_id = SCHEMA_ID('dbo')
   ORDER BY name;

3. Verifica que los usuarios fueron creados:
   SELECT * FROM VeterinariaGenesisDB.dbo.Usuario;

4. Verifica que hay datos:
   SELECT COUNT(*) FROM VeterinariaGenesisDB.dbo.Propietario;
   SELECT COUNT(*) FROM VeterinariaGenesisDB.dbo.Mascota;
   SELECT COUNT(*) FROM VeterinariaGenesisDB.dbo.Cita;

==================================================================================







