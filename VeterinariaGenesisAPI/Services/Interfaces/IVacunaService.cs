using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.Services.Interfaces;

public interface IVacunaService
{
    Task<List<RecordatorioVacunacionDto>> ObtenerRecordatoriosAsync(int diasAnticipacion);
}

