using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces.Base;

namespace Services.ChattingApp.Domain.Interfaces
{
    public interface IConversationRepository : IGenericRepository<Conversation>
    {
        IEnumerable<Conversation> GetConversations(int? count);
    }

}
