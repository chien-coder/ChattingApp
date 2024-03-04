using Services.ChattingApp.Domain;
using Services.ChattingApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ChattingApp.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<User> GetUsers(int count)
        {
            return _context.Users.Take(count).ToList();
        }
    }

}
