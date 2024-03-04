namespace Services.ChattingApp.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public User Sender { get; set; } = new User();
        public DateTime DateTime { get; set; }
    }
}