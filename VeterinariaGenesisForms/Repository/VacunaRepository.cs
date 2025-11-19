using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Repository;

public class VacunaRepository : IVacunaRepository
{
    private readonly ApiClient _apiClient;

    public VacunaRepository(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<List<RecordatorioVacunacionDto>> ObtenerRecordatoriosAsync(int diasAnticipacion)
    {
        var resultado = await _apiClient.GetAsync<List<RecordatorioVacunacionDto>>($"Vacuna/Recordatorios?diasAnticipacion={diasAnticipacion}");
        return resultado ?? new List<RecordatorioVacunacionDto>();
    }
}

