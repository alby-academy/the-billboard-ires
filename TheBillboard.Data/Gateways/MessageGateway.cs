namespace TheBillboard.Data.Gateways;

using Abstract;
using Microsoft.EntityFrameworkCore;
using Models;
using TheBillboard.Data.Data;

public class MessageGateway : IGateway<Message>
{
    private readonly TheBillboardContext _context;

    public MessageGateway(TheBillboardContext context) => _context = context;

    public IEnumerable<Message> GetAll() => _context.Messages
        .Include(m => m.Author);
    public Message? GetById(int id) => _context.Messages.Find(id);
    public Message Insert(Message entity)
    {
        var e = _context.Messages.Add(entity);
        _context.SaveChanges();

        return e.Entity;
    }

    public void Modify(Message entity) => throw new NotImplementedException();

    public void Delete(int id) => throw new NotImplementedException();
}