namespace TheBillboard.MVC.Controllers;

using Abstract;
using Microsoft.AspNetCore.Mvc;
using Models;

public class MessageController : Controller
{
    private readonly IGateway<Message> _gateway;
    private readonly ILogger<MessageController> _logger;

    public MessageController(IGateway<Message> gateway, ILogger<MessageController> logger)
    {
        _gateway = gateway;
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Message.Index was called");
        return View(_gateway.GetAll());
    }

    public IActionResult Detail(int id)
    {
        _logger.LogInformation("Message.Detail was called");
        return View(_gateway.GetById(id));
    }
}