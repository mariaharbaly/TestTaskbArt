namespace TestTaskbArt.Contracts.Incident;

public record IncidentResponse(
    string AccountName,
    string ContactFirstName,
    string ContactLastName,
    string ContactEmail,
    string Description);