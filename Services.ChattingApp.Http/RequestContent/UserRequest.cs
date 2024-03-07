namespace Services.ChattingApp.Domain.Entities
{
    public class UserRequest
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public  List<GroupRequest>? Groups { get; set; }
    }
}