using Services.ChattingApp.DataAccess.Repositories;
using Services.ChattingApp.Domain.Interfaces;

namespace Services.ChattingApp.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IUserRepository Users { get; private set; }


        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
