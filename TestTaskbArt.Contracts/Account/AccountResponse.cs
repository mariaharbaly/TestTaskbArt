using TestTaskbArt.Contracts.Contact;
using TestTaskbArt.Contracts.Incident;

namespace TestTaskbArt.Contracts.Account;

public record AccountResponse(
    string Name,
    List<ContactResponse> Contacts,
    IncidentResponse Incident);