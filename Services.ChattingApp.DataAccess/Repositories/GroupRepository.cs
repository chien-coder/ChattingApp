using Services.ChattingApp.DataAccess.Repositories.Base;
using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces;

namespace Services.ChattingApp.DataAccess.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Group> GetGroups(int? count)
        {
            if(count == null)
            {
                return _context.Groups;
            }
            return _context.Groups.Take((int)count);
        }
    }

}
