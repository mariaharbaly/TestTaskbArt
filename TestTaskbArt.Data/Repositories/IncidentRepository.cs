using Microsoft.EntityFrameworkCore;
using TeastTaskbArt.Common.Exceptions;
using TestTaskbArt.Data.Abstracts;
using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Data.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly IDataContext _dataContext;

    public IncidentRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<IEnumerable<Incident>> GetIncidents()
    {
        return await _dataContext.Incidents.ToListAsync();
    }

    public async Task<Incident> GetIncidentByName(string name)
    {
        Incident? incident = await _dataContext.Incidents.FirstOrDefaultAsync(x => x.Name == name);
        
        if (incident == null)
            throw new NotFoundException($"Incident with name: {name} not found");
        
        return incident;
    }

    public async Task InsertIncident(Incident? incident)
    {
        if (incident == null)
            throw new ArgumentNullException();
        
        await _dataContext.Incidents.AddAsync(incident);
    }

    public async Task DeleteIncident(string name)
    {
        Incident? incident = await _dataContext.Incidents.FirstOrDefaultAsync(x => x.Name == name);
        
        if (incident == null)
            throw new NotFoundException($"Incident with name: {name} not found");
        
        _dataContext.Incidents.Remove(incident);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dataContext.SaveChangesAsync(cancellationToken);
    }
}