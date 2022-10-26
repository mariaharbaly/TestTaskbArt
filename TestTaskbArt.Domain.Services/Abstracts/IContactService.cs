using TestTaskbArt.Contracts.Contact;

namespace TestTaskbArt.Domain.Services.Abstracts;

public interface IContactService
{
    Task<ContactResponse> CreateContactAsync(CreateContactRequest createContactRequest);
    Task<IEnumerable<ContactResponse>> GetContactsAsync();
}