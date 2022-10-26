using Mapster;
using TestTaskbArt.Contracts.Account;
using TestTaskbArt.Contracts.Contact;
using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Domain.Services.Mapping;

public class AccountMapping : IRegister 
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAccountRequest, Account>();
        config.NewConfig<Account, AccountResponse>();
    }
}