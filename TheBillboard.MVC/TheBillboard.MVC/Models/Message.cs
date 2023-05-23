namespace TheBillboard.MVC.Models;

public record Message(int Id, string Title, string Body, DateTime PostDate, Author Author) : Entity(Id);