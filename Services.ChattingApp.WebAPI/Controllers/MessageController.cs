using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Services.ChattingApp.Domain;
using Services.ChattingApp.Domain.Interfaces;
using Services.ChattingApp.WebAPI.Hubs;

namespace Services.ChattingApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<ChatHub> _chatHub;

        public MessageController(IUnitOfWork unitOfWork, IHubContext<ChatHub> chatHub)
        {
            _unitOfWork = unitOfWork;
            _chatHub = chatHub;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            _unitOfWork.Messages.Add(message);
            _unitOfWork.Complete();

            await _chatHub.Clients.All.SendAsync("ReceiveMessage", message.Sender, message.Content);

            return Ok();
        }


        [HttpGet]
        public IActionResult GetMessage([FromQuery] int count)
        {
            var users = _unitOfWork.Messages.GetMessages(count);
            return Ok(users);
        }
    }
}