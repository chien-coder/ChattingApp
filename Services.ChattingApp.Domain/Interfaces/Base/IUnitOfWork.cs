namespace Services.ChattingApp.Domain.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IMessageRepository Messages { get; }
        IGroupRepository Groups { get; }
        IConversationRepository Conversations { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
