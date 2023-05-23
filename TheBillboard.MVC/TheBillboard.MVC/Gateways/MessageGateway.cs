namespace TheBillboard.MVC.Gateways;

using Abstract;
using Models;

public class MessageGateway : IGateway<Message>
{
    private readonly ICollection<Message> _messages = new List<Message>
    {
        new(1, "Ciao Mondo", "Ciao Bellissimo Mondo", DateTime.Now.AddHours(-32), new(1, "Alberto", "Viezzi")),
        new(2, "Hello World", "Hello Wonderful World", DateTime.Now.AddDays(-2), new(2, "Dario", "Viezzi"))
    };

    public IEnumerable<Message> GetAll() => _messages;

    public Message? GetById(int id) => _messages.SingleOrDefault(message => message.Id == id);
}