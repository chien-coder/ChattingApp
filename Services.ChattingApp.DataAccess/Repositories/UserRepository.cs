﻿using Services.ChattingApp.DataAccess.Repositories.Base;
using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces;

namespace Services.ChattingApp.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<User> GetUsers(int? count)
        {
            if(count == null)
            {
                return _context.Users.ToList();
            }
            return _context.Users.Take((int)count).ToList();
        }
    }

}
