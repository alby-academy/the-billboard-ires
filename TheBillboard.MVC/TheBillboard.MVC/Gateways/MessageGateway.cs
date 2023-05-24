namespace TheBillboard.MVC.Gateways;

using Abstract;
using Models;

public class MessageGateway : IGateway<Message>
{
    private readonly ICollection<Message> _messages;

    public MessageGateway(IGateway<Author> gateway) =>
        _messages = new List<Message>
        {
            new(1, "Ciao Mondo", "Ciao Bellissimo Mondo", DateTime.Now.AddHours(-32), gateway.GetById(1)),
            new(2, "Hello World", "Hello Wonderful World", DateTime.Now.AddDays(-2), gateway.GetById(2))
        };

    public IEnumerable<Message> GetAll() => _messages;

    public Message? GetById(int id) => _messages.SingleOrDefault(message => message.Id == id);
    public void Insert(Message entity) => _messages.Add(entity with { Id = _messages.Max(m => m.Id) + 1, PostDate = DateTime.Now });

    public void Modify(Message entity)
    {
        _messages.Remove(GetById(entity.Id ?? 0)!);
        _messages.Add(entity);
    }

    public void Delete(int id) => _messages.Remove(GetById(id)!);
}