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
        public IActionResult CreateUser(User request)
        {
            _unitOfWork.Users.Add(request);
            _unitOfWork.Complete();

            return Ok();
        }


        [HttpPut]
        public IActionResult UpdateUser(User request)
        {
            if(request.Groups != null)
            {
                for(var i = 0; i < request.Groups.Count; i++)
                {
                    var groupExisted = _unitOfWork.Groups.GetById(request.Groups[i].Id);

                    if(groupExisted != null)
                    {
                        request.Groups[i] = groupExisted;
                    }
                }
            }

            var user = _unitOfWork.Users.GetById(request.Id);

            if(user == null)
            {
                return BadRequest("User doesn't exist");
            }

            user = request;

            _unitOfWork.Users.Update(user);

            _unitOfWork.Complete();

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAllUser([FromQuery]int? count = 1000)
        {
            var users = _unitOfWork.Users.GetUsers(count);
            return Ok(users);
        }
    }
}