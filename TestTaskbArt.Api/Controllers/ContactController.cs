using Microsoft.AspNetCore.Mvc;
using TestTaskbArt.Contracts.Contact;
using TestTaskbArt.Domain.Services.Abstracts;

namespace TestTaskbArt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    
    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost] 
    [ProducesResponseType(typeof(ContactResponse), StatusCodes.Status200OK)] 
     public async Task<ActionResult> Create(CreateContactRequest createContactRequest)
     {
            var contact = await _contactService.CreateContactAsync(createContactRequest);
            return Ok(contact);
     }
     
     [HttpGet]
     [ProducesResponseType(typeof(IEnumerable<ContactResponse>), StatusCodes.Status200OK)]
     public async Task<ActionResult> Get() 
     {
         var contacts = await _contactService.GetContactsAsync();
         return Ok(contacts);
     }
}