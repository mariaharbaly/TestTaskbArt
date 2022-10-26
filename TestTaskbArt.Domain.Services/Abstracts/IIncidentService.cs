using TestTaskbArt.Contracts.Incident;

namespace TestTaskbArt.Domain.Services.Abstracts;

public interface IIncidentService
{
    Task<IncidentResponse> CreateIncidentAsync(CreateIncidentRequest createIncidentRequest);
    Task<IEnumerable<IncidentResponse>> GetIncidentAsync();
}