using Services.ChattingApp.DataAccess.Repositories.Base;
using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces;
using System.Linq;

namespace Services.ChattingApp.DataAccess.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Message> GetMessages(int? count)
        {
            if(count == null)
            {
                return _context.Messages.ToList();
            }

            return _context.Messages.Take((int)count).ToList();
        }
    }

}
