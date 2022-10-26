namespace TestTaskbArt.Contracts.Account;

public record CreateAccountRequest(
    string Name,
    string ContactEmail);