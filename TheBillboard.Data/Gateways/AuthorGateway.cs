namespace TheBillboard.Data.Gateways;

using Abstract;

using Models;

public class AuthorGateway : IGateway<Author>
{
    private readonly IEnumerable<Author> _authors = new List<Author>
    {
        new(1, "Alberto", "Viezzi"),
        new(2, "Dario", "Viezzi")
    };

    public IEnumerable<Author> GetAll() => _authors;

    public Author? GetById(int id) => _authors.SingleOrDefault(author => author.Id == id);
    public Author Insert(Author entity) => throw new NotImplementedException();
    public Author Modify(Author entity) => throw new NotImplementedException();
    public Author Delete(int id) => throw new NotImplementedException();
}