using Microsoft.AspNetCore.Mvc;

namespace TheBillboard.API.Controllers;

using Data.Abstract;
using Data.Models;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IGateway<Message> _gateway;
    private readonly ILogger<MessageController> _logger;

    public MessageController(IGateway<Message> gateway, ILogger<MessageController> logger)
    {
        _gateway = gateway;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Message> Get() => _gateway.GetAll();

    [HttpPost]
    public Message Post([FromBody] Message message) => _gateway.Insert(message);
}