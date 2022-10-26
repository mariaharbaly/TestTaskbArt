namespace TestTaskbArt.Contracts.Incident;

public record CreateIncidentRequest(
    string AccountName,
    string ContactFirstName,
    string ContactLastName,
    string ContactEmail,
    string Description);