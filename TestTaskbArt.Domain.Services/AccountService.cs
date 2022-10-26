using MapsterMapper;
using TestTaskbArt.Contracts.Account;
using TestTaskbArt.Contracts.Contact;
using TestTaskbArt.Data.Abstracts;
using TestTaskbArt.Data.Entities;
using TestTaskbArt.Domain.Services.Abstracts;

namespace TestTaskbArt.Domain.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public AccountService(IMapper mapper, IAccountRepository accountRepository, IContactRepository contactRepository)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
        _contactRepository = contactRepository;
    }
    
    public async Task<AccountResponse> CreateAccountAsync(CreateAccountRequest createAccountRequest)
    {
        Contact contact = await _contactRepository.GetContactByEmail(createAccountRequest.ContactEmail);

        if (contact.IsLinked)
            throw new InvalidOperationException("Contact is already linked to account");
        
        Account account = _mapper.Map<Account>(createAccountRequest);

        await _accountRepository.InsertAccount(account);
        
        contact.AccountName = account.Name;
        contact.IsLinked = true;

        await _accountRepository.SaveChangesAsync();
            
        return _mapper.Map<AccountResponse>(account);
    }

    public async Task<IEnumerable<AccountResponse>> GetAccountAllInfoAsync()
    {
        return _mapper.Map<IEnumerable<AccountResponse>>(await _accountRepository.GetAccountsAllInfo());
    }
    
    public async Task LinkContact(string accountName, string contactEmail)
    {
        Contact contact = await _contactRepository.GetContactByEmail(contactEmail);

        if (contact.IsLinked)
            throw new InvalidOperationException("Contact is already linked to account");

        Account account = await _accountRepository.GetAccountByName(accountName);
      
        contact.AccountName = account.Name;
        contact.IsLinked = true;

        await _accountRepository.SaveChangesAsync();
    }
}