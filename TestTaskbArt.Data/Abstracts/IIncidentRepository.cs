using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Data.Abstracts;

public interface IIncidentRepository
{
    Task<IEnumerable<Incident>> GetIncidents();
    Task<Incident> GetIncidentByName(string name);
    Task InsertIncident(Incident? incident);
    Task DeleteIncident(string name);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}