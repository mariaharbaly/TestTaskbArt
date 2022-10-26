using Microsoft.EntityFrameworkCore;
using TeastTaskbArt.Common.Exceptions;
using TestTaskbArt.Data.Abstracts;
using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Data.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly IDataContext _dataContext;

    public ContactRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Contact>> GetContacts()
    {
        return await _dataContext.Contacts.ToListAsync();
    }
    
    public async Task<Contact> GetContactByEmail(string email)
    {
        var contact = await _dataContext.Contacts.FirstOrDefaultAsync(x => x.Email == email);
        
        if (contact == null)
            throw new NotFoundException($"Contact with email: {email} not found");
        
        return contact;
    }
    
    public async Task InsertContact(Contact? contact)
    {
        if (contact == null)
            throw new ArgumentNullException();
        
        await _dataContext.Contacts.AddAsync(contact);  
    }
    
    public async Task DeleteContact(string email)
    {
        Contact? contact = await _dataContext.Contacts.FindAsync(email);
        
        if (contact == null)
            throw new NotFoundException($"Contact with email: {email} not found");
        
        _dataContext.Contacts.Remove(contact);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dataContext.SaveChangesAsync(cancellationToken);
    }
}