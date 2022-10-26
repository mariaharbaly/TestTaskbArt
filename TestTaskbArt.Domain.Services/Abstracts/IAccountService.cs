using TestTaskbArt.Contracts.Account;

namespace TestTaskbArt.Domain.Services.Abstracts;

public interface IAccountService
{
    Task<AccountResponse> CreateAccountAsync(CreateAccountRequest createAccountRequest);
    Task<IEnumerable<AccountResponse>> GetAccountAllInfoAsync();
    Task LinkContact(string accountName, string contactEmail);
}