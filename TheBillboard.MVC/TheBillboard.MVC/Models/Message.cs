namespace TheBillboard.MVC.Models;

public record Message(int? Id = default, string Title = "", string Body = "", DateTime? PostDate = default, Author? Author = default) : Entity(Id);