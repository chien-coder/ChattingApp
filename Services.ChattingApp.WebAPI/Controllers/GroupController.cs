using Microsoft.AspNetCore.Mvc;
using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces.Base;

namespace Services.ChattingApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult CreateGroup(Group group)
        {
            _unitOfWork.Groups.Add(group);
            _unitOfWork.Complete();

            return Ok();
        }


        [HttpGet]
        public IActionResult GetAllUser([FromQuery]int? count = 1000)
        {
            var groups = _unitOfWork.Groups.GetGroups(count);
            return Ok(groups);
        }
    }
}