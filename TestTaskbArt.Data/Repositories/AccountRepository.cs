using Microsoft.EntityFrameworkCore;
using TeastTaskbArt.Common.Exceptions;
using TestTaskbArt.Data.Abstracts;
using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Data.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IDataContext _dataContext;

    public AccountRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<IEnumerable<Account>> GetAccountsAllInfo()
    {
        var accounts =  await _dataContext.Accounts.Include(x=>x.Contacts)
            .Include(x=>x.Incident).ToListAsync();
        
        if (accounts == null)
            throw new NotFoundException($"Accounts  not found");

        return accounts;
    }

    public async Task<Account> GetAccountByName(string name)
    {
        Account? account = await _dataContext.Accounts.FirstOrDefaultAsync(x => x.Name == name);
        
        if (account == null)
            throw new NotFoundException($"Account with name: {name} not found");
        
        return account;
    }

    public async Task InsertAccount(Account? account)
    {
        if (account == null)
            throw new ArgumentNullException();
        
        await _dataContext.Accounts.AddAsync(account);
    }

    public async Task DeleteAccount(string name)
    {
        Account? account = await _dataContext.Accounts.FirstOrDefaultAsync(x => x.Name == name);
        
        if (account == null)
            throw new NotFoundException($"Account with name: {name} not found");
        
        _dataContext.Accounts.Remove(account);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dataContext.SaveChangesAsync(cancellationToken);
    }
}