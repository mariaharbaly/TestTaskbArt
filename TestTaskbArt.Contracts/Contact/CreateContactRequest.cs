namespace TestTaskbArt.Contracts.Contact;

public record CreateContactRequest
(
    string FirstName,
    string LastName,
    string Email
);