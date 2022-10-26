namespace TestTaskbArt.Data.Entities;

public class Contact : IEntity
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsLinked { get; set; } 
    public string AccountName { get; set; }
}