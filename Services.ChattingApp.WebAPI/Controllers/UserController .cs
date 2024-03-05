using Microsoft.AspNetCore.Mvc;
using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces.Base;

namespace Services.ChattingApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();

            return Ok();
        }


        [HttpGet]
        public IActionResult GetAllUser([FromQuery] int count)
        {
            var users = _unitOfWork.Users.GetUsers(count);
            return Ok(users);
        }
    }
}