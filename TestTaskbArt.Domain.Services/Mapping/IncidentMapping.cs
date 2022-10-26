using Mapster;
using TestTaskbArt.Contracts.Account;
using TestTaskbArt.Contracts.Incident;
using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Domain.Services.Mapping;

public class IncidentMapping : IRegister 
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateIncidentRequest, Incident>();
        config.NewConfig<Incident, IncidentResponse>();
    }
}