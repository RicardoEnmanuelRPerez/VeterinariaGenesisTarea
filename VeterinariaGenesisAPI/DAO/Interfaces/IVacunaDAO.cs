using VeterinariaGenesisAPI.Models.DTOs;

namespace VeterinariaGenesisAPI.DAO.Interfaces;

public interface IVacunaDAO
{
    Task<List<RecordatorioVacunacionDto>> ObtenerRecordatoriosAsync(int diasAnticipacion);
}

