using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces.Base;
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
            var user = _unitOfWork.Users.GetById(message.SenderId);

            if (user == null)
            {
                return BadRequest("User doesn't exist");
            }
            else
            {
                message.Sender = user;
            }

            var group = _unitOfWork.Groups.GetById(message.GroupId);

            if(group == null)
            {
                return BadRequest("Group doesn't exist");
            }
            else
            {
                message.Group = group;
            }

            var userInGroup = group.Users?.Find(x => x.Id == user.Id);

            if(userInGroup == null)
            {
                return BadRequest("User not in Group");
            }

            _unitOfWork.Messages.Add(message);

            _unitOfWork.Complete();

            await _signHub.Clients.Group(group.Id.ToString()).SendAsync("ReceiveMessage", user.LastName, message.Content, group.Name);

            return Ok(message);
        }


        [HttpGet]
        public IActionResult GetMessage([FromQuery]int? count = 1000)
        {
            var messages = _unitOfWork.Messages.GetMessages(count);
            return Ok(messages);
        }
    }
}