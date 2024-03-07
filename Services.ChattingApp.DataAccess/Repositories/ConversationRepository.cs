using Services.ChattingApp.DataAccess.Repositories.Base;
using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces;

namespace Services.ChattingApp.DataAccess.Repositories
{
    public class ConversationRepository : GenericRepository<Conversation>, IConversationRepository
    {
        public ConversationRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Conversation> GetConversations(int? count)
        {
            if(count == null)
            {
                return _context.Conversations;
            }
            return _context.Conversations.Take((int)count);
        }
    }

}
