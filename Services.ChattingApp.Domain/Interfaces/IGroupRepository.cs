using Services.ChattingApp.Domain.Entities;
using Services.ChattingApp.Domain.Interfaces.Base;

namespace Services.ChattingApp.Domain.Interfaces
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        IEnumerable<Group> GetGroups(int? count);
    }

}
