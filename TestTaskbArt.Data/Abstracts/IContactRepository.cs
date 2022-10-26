using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Data.Abstracts;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetContacts();
    Task<Contact> GetContactByEmail(string email);
    Task InsertContact(Contact? contact);
    Task DeleteContact(string email);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}