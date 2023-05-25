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
    public Message? GetById(int id) => _context.Messages.AsNoTracking().SingleOrDefault(p => p.Id == id);
    public Message Insert(Message entity)
    {
        entity.Author = _context.Authors.AsNoTracking().SingleOrDefault(p => p.Id == entity.AuthorId);
        var e = _context.Messages.Add(entity);

        _context.SaveChanges();

        return e.Entity;
    }

    public Message Modify(Message entity)
    {

        var author = _context.Authors.AsNoTracking().SingleOrDefault(p => p.Id == entity.AuthorId);
        entity.Author = author;

        _context.Messages.Update(entity);
        _context.SaveChanges();
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