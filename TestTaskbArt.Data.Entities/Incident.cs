namespace TestTaskbArt.Data.Entities;

public class Incident : IEntity
{ 
    public string Name { get; set; }
    public string AccountName { get; set; }
    public string ContactEmail { get; set; }
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }
    public string Description { get; set; }
}