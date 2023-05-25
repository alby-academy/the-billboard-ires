namespace TheBillboard.MVC.Gateways;

using Abstract;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

public class MessageGateway : IGateway<Message>
{
    private readonly TheBillboardContext _context;

    public MessageGateway(TheBillboardContext context) => _context = context;

    public IEnumerable<Message> GetAll() => _context.Messages
        .Include(m => m.Author);
    public Message? GetById(int id) => _context.Messages.Find(id);
    public void Insert(Message entity) => throw new NotImplementedException();

    public void Modify(Message entity) => throw new NotImplementedException();

    public void Delete(int id) => throw new NotImplementedException();
}