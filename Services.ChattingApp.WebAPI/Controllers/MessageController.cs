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
        private readonly IHubContext<SignalRHub> _signHub;

        public MessageController(IUnitOfWork unitOfWork, IHubContext<SignalRHub> signHub)
        {
            _unitOfWork = unitOfWork;
            _signHub = signHub;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            _unitOfWork.Messages.Add(message);

            try
            {
                var rs = _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            await _signHub.Clients.All.SendAsync("ReceiveMessage", message.Sender, message.Content);

            return Ok(message);
        }


        [HttpGet]
        public IActionResult GetMessage([FromQuery] int count)
        {
            var users = _unitOfWork.Messages.GetMessages(count);
            return Ok(users);
        }
    }
}