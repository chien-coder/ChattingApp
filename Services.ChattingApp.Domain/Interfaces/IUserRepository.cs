using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ChattingApp.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetUsers(int count);
    }

}
