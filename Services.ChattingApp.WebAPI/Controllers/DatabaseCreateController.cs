using Microsoft.AspNetCore.Mvc;
using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces.Base;

namespace Services.ChattingApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseCreateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DatabaseCreateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Create()
        {
            var group1 = new Group()
            {
                Id = 1,
                Name = "Study Group",
                Users = new List<User>()
                {
                    new User()
                    {
                        Id = 1,
                        FirstName = "Test",
                        LastName = "Test",
                    },
                    new User()
                    {
                        Id = 2,
                        FirstName = "T",
                        LastName = "Chien",
                    },
                }
            };

            var group2 = new Group()
            {
                Id = 1,
                Name = "Null Group"
            };

            _unitOfWork.Groups.Add(group1);
            _unitOfWork.Groups.Add(group2);

            _unitOfWork.Complete();

            return Ok();
        }
        
    }
}