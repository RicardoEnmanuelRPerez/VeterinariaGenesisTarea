using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Repository.Interfaces;

public interface IVacunaRepository
{
    Task<List<RecordatorioVacunacionDto>> ObtenerRecordatoriosAsync(int diasAnticipacion);
}

