namespace Services.ChattingApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Message> Messages { get; } = new List<Message>();
    }
}