namespace Services.ChattingApp.Domain.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        IEnumerable<Message> GetMessages(int count);
    }

}
