using DemoApp.Data;
using DemoApp.Models;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly RabbitMqService _rabbitMq;

        public ItemsController(AppDbContext context, RabbitMqService rabbitMq)
        {
            _context = context;
            _rabbitMq = rabbitMq;
        }

        // GET /items
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Items.ToList());
        }

        // POST /items
        [HttpPost]
        public IActionResult Post(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        // POST /items/send
        [HttpPost("send")]
        public IActionResult SendMessage([FromBody] string message)
        {
            _rabbitMq.SendMessage(message);
            return Ok("Message sent to RabbitMQ!");
        }
    }
}