using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Services.ChattingApp.Domain.Interfaces;

namespace Services.ChattingApp.WebAPI.Hubs
{
    public class HubLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public HubLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void MessageTranfer(int user_send, int user_receive, string message)
        {
            
        }
    }
}
