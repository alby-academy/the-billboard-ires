namespace TheBillboard.MVC.Controllers;

using Abstract;
using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModel;

public class MessageController : Controller
{
    private readonly IGateway<Author> _authorGateway;
    private readonly ILogger<MessageController> _logger;
    private readonly IGateway<Message> _messageGateway;

    public MessageController(IGateway<Message> messageGateway, IGateway<Author> authorGateway, ILogger<MessageController> logger)
    {
        _messageGateway = messageGateway;
        _authorGateway = authorGateway;
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Message.Index was called");
        return View(BuildViewModel());
    }

    public IActionResult Detail(int id)
    {
        _logger.LogInformation("Message.Detail was called");
        return View(_messageGateway.GetById(id));
    }

    public IActionResult Create(MessageIndexViewModel vm)
    {
        var message = new Message(Title: vm.Title, Body: vm.Body)
        {
            Author = _authorGateway.GetById(vm.SelectedAuthor)
        };

        _messageGateway.Insert(message);
        return RedirectToAction("Index");
    }

    public IActionResult Update(Message message)
    {
        message = message with { Author = _authorGateway.GetById(message.Author?.Id ?? 0) };
        _messageGateway.Modify(message);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _messageGateway.Delete(id);
        return RedirectToAction("Index");
    }

    private MessageIndexViewModel BuildViewModel()
    {
        var messages = _messageGateway.GetAll();
        var author = _authorGateway.GetAll();

        return new(messages, author);
    }
}