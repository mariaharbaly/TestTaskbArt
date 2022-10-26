using MapsterMapper;
using TestTaskbArt.Contracts.Account;
using TestTaskbArt.Contracts.Incident;
using TestTaskbArt.Data.Abstracts;
using TestTaskbArt.Data.Entities;
using TestTaskbArt.Domain.Services.Abstracts;

namespace TestTaskbArt.Domain.Services;

public class IncidentService : IIncidentService
{
    private readonly IIncidentRepository _incidentRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public IncidentService(IMapper mapper, IIncidentRepository incidentRepository, IAccountRepository accountRepository)
    {
        _incidentRepository = incidentRepository;
        _accountRepository = accountRepository;
        _mapper = mapper;
    }
    
    public async Task<IncidentResponse> CreateIncidentAsync(CreateIncidentRequest createIncidentRequest)
    {
        Account account = await _accountRepository.GetAccountByName(createIncidentRequest.AccountName);

        Incident incident = _mapper.Map<Incident>(createIncidentRequest);

        await _incidentRepository.InsertIncident(incident);
        
        account.IncidentName = incident.Name;

        await _incidentRepository.SaveChangesAsync();
            
        return _mapper.Map<IncidentResponse>(incident);
    }

    public async Task<IEnumerable<IncidentResponse>> GetIncidentAsync()
    {
        return _mapper.Map<IEnumerable<IncidentResponse>>(await _incidentRepository.GetIncidents());
    }
}