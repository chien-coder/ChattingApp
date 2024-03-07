namespace Services.ChattingApp.Domain.Entities
{
    public class UserRespone : UserRequest
    {
        public new List<GroupResponse>? Groups { get; set; }
    }
}