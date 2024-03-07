using Services.ChattingApp.DataAccess.Repositories;
using Services.ChattingApp.Domain;
using Services.ChattingApp.Domain.Interfaces;
using Services.ChattingApp.Domain.Interfaces.Base;

namespace Services.ChattingApp.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IUserRepository Users { get; private set; }
        public IMessageRepository Messages { get; private set; }
        public IGroupRepository Groups { get; private set; }
        public IConversationRepository Conversations { get; private set; }


        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Messages = new MessageRepository(_context);
            Groups = new GroupRepository(_context);
            Conversations = new ConversationRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
