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
        var e = _context.Messages.Add(entity);

        _context.SaveChanges();
        
        e.Entity.Author = _context.Authors.AsNoTracking().SingleOrDefault(p => p.Id == entity.AuthorId);
        return e.Entity;
    }

    public Message Modify(Message entity)
    {
        var current = _context.Messages.AsNoTracking().SingleOrDefault(m => m.Id == entity.Id);
        
        _context.Messages.Update(current! with { Title = entity.Title, Body = entity.Body});
        _context.SaveChanges();
        
        var author = _context.Authors.Find(entity.AuthorId);
        entity.Author = author;
        
        return entity;

    }

    public Message Delete(int id)
    {
        var message = _context.Messages.AsNoTracking().SingleOrDefault(p => p.Id == id);
        _context.Remove(message);
        _context.SaveChanges();
        return message;
    }
}