namespace TheBillboard.Data.Models;

public record Message(int? Id = default, string Title = "", string Body = "", DateTime? PostDate = default) : Entity(Id)
{
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
}