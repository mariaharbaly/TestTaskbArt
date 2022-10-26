using Microsoft.AspNetCore.Mvc;
using TestTaskbArt.Contracts.Account;
using TestTaskbArt.Contracts.Incident;
using TestTaskbArt.Domain.Services;
using TestTaskbArt.Domain.Services.Abstracts;

namespace TestTaskbArt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentController : ControllerBase
{
    private readonly IIncidentService _incidentService;
    
    public IncidentController(IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }

    [HttpPost] 
    [ProducesResponseType(typeof(IncidentResponse), StatusCodes.Status200OK)] 
    public async Task<ActionResult> Create(CreateIncidentRequest createIncidentRequest)
    {
        var incident = await _incidentService.CreateIncidentAsync(createIncidentRequest);
        return Ok(incident);
    }
     
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<IncidentResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Get()
    {
        var incident = await _incidentService.GetIncidentAsync();
        return Ok(incident);
    }
}