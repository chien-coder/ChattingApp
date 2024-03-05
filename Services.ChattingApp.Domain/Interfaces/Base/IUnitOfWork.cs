namespace Services.ChattingApp.Domain.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IMessageRepository Messages { get; }
        int Complete();
    }
}
