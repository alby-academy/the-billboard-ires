namespace TheBillboard.MVC.ViewModel;

using Data.Models;

public class MessageIndexViewModel
{
    public MessageIndexViewModel(IEnumerable<Message> messages, IEnumerable<Author> availableAuthors)
    {
        Messages = messages;
        AvailableAuthors = availableAuthors;
    }

    public MessageIndexViewModel() : this(new List<Message>(), new List<Author>())
    {
    }

    public IEnumerable<Message> Messages { get; }
    public IEnumerable<Author> AvailableAuthors { get; }

    public int SelectedAuthor { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}