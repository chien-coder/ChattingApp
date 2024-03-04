namespace Services.ChattingApp.Domain
{
    public class GroupChat
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Message>? Messages { get; set; }
        public List<User>? Users { get; set; }
    }
}