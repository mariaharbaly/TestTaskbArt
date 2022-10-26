using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Data.Abstracts;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAccountsAllInfo();
    Task<Account> GetAccountByName(string name);
    Task InsertAccount(Account? account);
    Task DeleteAccount(string name);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}