using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces.Base;

namespace Services.ChattingApp.Domain.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        IEnumerable<Message> GetMessages(int count);
    }

}
