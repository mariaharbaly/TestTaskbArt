namespace TestTaskbArt.Data.Entities;

public class Account : IEntity
{
    public string Name { get; set; }
    public string IncidentName { get; set; }
    public Incident Incident { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}