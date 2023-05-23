namespace TheBillboard.MVC.Models;

public record Author(int Id, string GivenName, string FamilyName) : Entity(Id)
{
    public string FullName => $"{GivenName} {FamilyName}";
}