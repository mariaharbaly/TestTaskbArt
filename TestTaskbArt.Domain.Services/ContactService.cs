using MapsterMapper;
using TestTaskbArt.Contracts.Contact;
using TestTaskbArt.Data.Abstracts;
using TestTaskbArt.Data.Entities;
using TestTaskbArt.Domain.Services.Abstracts;

namespace TestTaskbArt.Domain.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public ContactService(IMapper mapper, IContactRepository contactRepository)
    {
        _mapper = mapper;
        _contactRepository = contactRepository;
    }
    
    public async Task<ContactResponse> CreateContactAsync(CreateContactRequest createContactRequest) 
    {
        Contact contact = _mapper.Map<Contact>(createContactRequest);

        await _contactRepository.InsertContact(contact);

        await _contactRepository.SaveChangesAsync();
            
        return _mapper.Map<ContactResponse>(contact);
    }

    public async Task<IEnumerable<ContactResponse>> GetContactsAsync()
    {
        return _mapper.Map<IEnumerable<ContactResponse>>(await _contactRepository.GetContacts());
    }
}
    