using Services.ChattingApp.Domain;
using Services.ChattingApp.Domain.Interfaces;

namespace Services.ChattingApp.DataAccess.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Message> GetMessages(int count)
        {
            return _context.Messages.Take(count).ToList();
        }
    }

}
