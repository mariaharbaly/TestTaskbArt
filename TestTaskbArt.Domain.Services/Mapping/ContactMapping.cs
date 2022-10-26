using Mapster;
using TestTaskbArt.Contracts.Contact;
using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Domain.Services.Mapping;

public class ContactMapping : IRegister 
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateContactRequest, Contact>();
        config.NewConfig<Contact, ContactResponse>();
    }
}