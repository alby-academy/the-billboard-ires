namespace TheBillboard.Data.Models;

public record Author(int? Id = default, string GivenName = "", string FamilyName = "") : Entity(Id)
{
    public IEnumerable<Message> Messages = new HashSet<Message>();
    public string FullName => $"{GivenName} {FamilyName}";
}