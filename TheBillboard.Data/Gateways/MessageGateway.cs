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
    public Message? GetById(int id) => _context.Messages
        .AsNoTracking()
        .SingleOrDefault(message => message.Id == id);
    
    public Message Insert(Message entity)
    {
        entity.Author = _context.Authors.AsNoTracking().SingleOrDefault(p => p.Id == entity.AuthorId);
        var e = _context.Messages.Add(entity);

        _context.SaveChanges();

        return e.Entity;
    }

    public Message Modify(Message entity)
    {
        _context.Messages.Update(entity);
        _context.SaveChanges();
        
        var author = _context.Authors.Find(entity.AuthorId);
        entity.Author = author;
        
        return entity;

    }

    public Message Delete(int id)
    {
        var message = _context.Messages.Find(id);
        _context.Remove(message);
        _context.SaveChanges();
        return message;
    }
}