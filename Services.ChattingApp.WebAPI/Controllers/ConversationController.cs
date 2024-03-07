using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces.Base;

namespace Services.ChattingApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConversationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult CreateConversation(Conversation conversation)
        {
            _unitOfWork.Conversations.Add(conversation);
            _unitOfWork.Complete();

            return Ok();
        }


        [HttpGet]
        public IActionResult GetAllConversation([FromQuery]int? count = 1000)
        {
            var conversations = _unitOfWork.Conversations.GetConversations(count);
            return Ok(conversations);
        }
    }
}