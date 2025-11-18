using System.Data;
using Microsoft.Data.SqlClient;
using VeterinariaGenesisAPI.Data;
using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO;

public class ReporteDAO : IReporteDAO
{
    private readonly ConexionDB _conexionDB;

    public ReporteDAO(ConexionDB conexionDB)
    {
        _conexionDB = conexionDB;
    }

    public async Task<List<ReportePropietarioDto>> ObtenerReportePropietariosAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Reporte_Propietarios, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            var resultados = new List<ReportePropietarioDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new ReportePropietarioDto
                {
                    IdPropietario = reader.GetInt32(reader.GetOrdinal("IdPropietario")),
                    NombreCompleto = reader.GetString(reader.GetOrdinal("NombreCompleto")),
                    Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                    Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
                    CantidadFacturas = reader.GetInt32(reader.GetOrdinal("CantidadFacturas")),
                    TotalPagado = reader.GetDecimal(reader.GetOrdinal("TotalPagado")),
                    TotalPendiente = reader.GetDecimal(reader.GetOrdinal("TotalPendiente")),
                    CantidadMascotas = reader.GetInt32(reader.GetOrdinal("CantidadMascotas"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener reporte de propietarios: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener reporte de propietarios: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteServicioVendidoDto>> ObtenerReporteServiciosVendidosAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Reporte_ServiciosVendidos, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            var resultados = new List<ReporteServicioVendidoDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new ReporteServicioVendidoDto
                {
                    IdServicio = reader.GetInt32(reader.GetOrdinal("IdServicio")),
                    NombreServicio = reader.GetString(reader.GetOrdinal("NombreServicio")),
                    Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString(reader.GetOrdinal("Descripcion")),
                    PrecioUnitario = reader.GetDecimal(reader.GetOrdinal("PrecioUnitario")),
                    CantidadVendida = reader.GetInt32(reader.GetOrdinal("CantidadVendida")),
                    TotalIngresos = reader.GetDecimal(reader.GetOrdinal("TotalIngresos")),
                    CantidadFacturas = reader.GetInt32(reader.GetOrdinal("CantidadFacturas"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener reporte de servicios vendidos: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener reporte de servicios vendidos: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteCitaVeterinarioDto>> ObtenerReporteCitasPorVeterinarioAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Reporte_CitasPorVeterinario, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            var resultados = new List<ReporteCitaVeterinarioDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new ReporteCitaVeterinarioDto
                {
                    IdVeterinario = reader.GetInt32(reader.GetOrdinal("IdVeterinario")),
                    NombreVeterinario = reader.GetString(reader.GetOrdinal("NombreVeterinario")),
                    Especialidad = reader.IsDBNull(reader.GetOrdinal("Especialidad")) ? null : reader.GetString(reader.GetOrdinal("Especialidad")),
                    CantidadCitas = reader.GetInt32(reader.GetOrdinal("CantidadCitas")),
                    CitasCompletadas = reader.GetInt32(reader.GetOrdinal("CitasCompletadas")),
                    CitasCanceladas = reader.GetInt32(reader.GetOrdinal("CitasCanceladas")),
                    CitasProgramadas = reader.GetInt32(reader.GetOrdinal("CitasProgramadas")),
                    TotalIngresos = reader.GetDecimal(reader.GetOrdinal("TotalIngresos"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener reporte de citas por veterinario: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener reporte de citas por veterinario: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteIngresoPeriodoDto>> ObtenerReporteIngresosPorPeriodoAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Reporte_IngresosPorPeriodo, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            var resultados = new List<ReporteIngresoPeriodoDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new ReporteIngresoPeriodoDto
                {
                    Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                    CantidadFacturas = reader.GetInt32(reader.GetOrdinal("CantidadFacturas")),
                    CantidadClientes = reader.GetInt32(reader.GetOrdinal("CantidadClientes")),
                    IngresosPagados = reader.GetDecimal(reader.GetOrdinal("IngresosPagados")),
                    IngresosPendientes = reader.GetDecimal(reader.GetOrdinal("IngresosPendientes")),
                    TotalFacturado = reader.GetDecimal(reader.GetOrdinal("TotalFacturado")),
                    FacturasPagadas = reader.GetInt32(reader.GetOrdinal("FacturasPagadas")),
                    FacturasPendientes = reader.GetInt32(reader.GetOrdinal("FacturasPendientes"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener reporte de ingresos por período: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener reporte de ingresos por período: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteMascotaEspecieDto>> ObtenerReporteMascotasPorEspecieAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Reporte_MascotasPorEspecie, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            var resultados = new List<ReporteMascotaEspecieDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new ReporteMascotaEspecieDto
                {
                    Especie = reader.GetString(reader.GetOrdinal("Especie")),
                    CantidadMascotas = reader.GetInt32(reader.GetOrdinal("CantidadMascotas")),
                    CantidadPropietarios = reader.GetInt32(reader.GetOrdinal("CantidadPropietarios")),
                    CantidadCitas = reader.GetInt32(reader.GetOrdinal("CantidadCitas")),
                    CantidadTratamientos = reader.GetInt32(reader.GetOrdinal("CantidadTratamientos")),
                    TotalIngresos = reader.GetDecimal(reader.GetOrdinal("TotalIngresos"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener reporte de mascotas por especie: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener reporte de mascotas por especie: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteTratamientoDto>> ObtenerReporteTratamientosComunesAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Reporte_TratamientosComunes, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            var resultados = new List<ReporteTratamientoDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new ReporteTratamientoDto
                {
                    IdTratamiento = reader.GetInt32(reader.GetOrdinal("IdTratamiento")),
                    Diagnostico = reader.GetString(reader.GetOrdinal("Diagnostico")),
                    Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                    Especie = reader.GetString(reader.GetOrdinal("Especie")),
                    NombreMascota = reader.GetString(reader.GetOrdinal("NombreMascota")),
                    NombrePropietario = reader.GetString(reader.GetOrdinal("NombrePropietario")),
                    CantidadMedicamentos = reader.GetInt32(reader.GetOrdinal("CantidadMedicamentos"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener reporte de tratamientos comunes: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener reporte de tratamientos comunes: {ex.Message}", ex);
        }
    }

    public async Task<List<ReporteMetodoPagoDto>> ObtenerReporteMetodosPagoAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Reporte_MetodosPago, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            var resultados = new List<ReporteMetodoPagoDto>();

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resultados.Add(new ReporteMetodoPagoDto
                {
                    MetodoPago = reader.GetString(reader.GetOrdinal("MetodoPago")),
                    CantidadPagos = reader.GetInt32(reader.GetOrdinal("CantidadPagos")),
                    TotalRecaudado = reader.GetDecimal(reader.GetOrdinal("TotalRecaudado")),
                    PromedioPago = reader.GetDecimal(reader.GetOrdinal("PromedioPago")),
                    PagoMinimo = reader.GetDecimal(reader.GetOrdinal("PagoMinimo")),
                    PagoMaximo = reader.GetDecimal(reader.GetOrdinal("PagoMaximo")),
                    PorcentajeUso = reader.IsDBNull(reader.GetOrdinal("PorcentajeUso")) ? 0 : reader.GetDecimal(reader.GetOrdinal("PorcentajeUso"))
                });
            }

            return resultados;
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener reporte de métodos de pago: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener reporte de métodos de pago: {ex.Message}", ex);
        }
    }

    public async Task<ReporteResumenGeneralDto> ObtenerReporteResumenGeneralAsync(DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        try
        {
            await using var connection = _conexionDB.GetConnection();
            await connection.OpenAsync();

            await using var command = new SqlCommand(Procedimientos.Reporte_ResumenGeneral, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) 
            { 
                Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value 
            });
            command.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) 
            { 
                Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value 
            });

            await using var reader = await command.ExecuteReaderAsync();
            
            if (await reader.ReadAsync())
            {
                return new ReporteResumenGeneralDto
                {
                    TotalPropietarios = reader.GetInt32(reader.GetOrdinal("TotalPropietarios")),
                    TotalMascotas = reader.GetInt32(reader.GetOrdinal("TotalMascotas")),
                    TotalCitas = reader.GetInt32(reader.GetOrdinal("TotalCitas")),
                    FacturasPagadas = reader.GetInt32(reader.GetOrdinal("FacturasPagadas")),
                    IngresosTotales = reader.GetDecimal(reader.GetOrdinal("IngresosTotales")),
                    TotalVeterinarios = reader.GetInt32(reader.GetOrdinal("TotalVeterinarios")),
                    TotalTratamientos = reader.GetInt32(reader.GetOrdinal("TotalTratamientos"))
                };
            }

            return new ReporteResumenGeneralDto();
        }
        catch (SqlException sqlEx)
        {
            throw new InvalidOperationException($"Error de base de datos al obtener reporte resumen general: {sqlEx.Message}", sqlEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al obtener reporte resumen general: {ex.Message}", ex);
        }
    }
}

