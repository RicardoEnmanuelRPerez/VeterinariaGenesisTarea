using VeterinariaGenesisAPI.DAO.Interfaces;
using VeterinariaGenesisAPI.Models.DTOs;
using VeterinariaGenesisAPI.Services.Interfaces;

namespace VeterinariaGenesisAPI.Services;

public class VacunaService : IVacunaService
{
    private readonly IVacunaDAO _vacunaDAO;

    public VacunaService(IVacunaDAO vacunaDAO)
    {
        _vacunaDAO = vacunaDAO;
    }

    public async Task<List<RecordatorioVacunacionDto>> ObtenerRecordatoriosAsync(int diasAnticipacion)
    {
        try
        {
            return await _vacunaDAO.ObtenerRecordatoriosAsync(diasAnticipacion);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error en el servicio al obtener recordatorios de vacunación: {ex.Message}", ex);
        }
    }
}

