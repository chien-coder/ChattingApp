using System.Text.Json.Serialization;

namespace Services.ChattingApp.Domain.Entities
{
    public class GroupRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<UserRequest> Users { get; set; }
    } 
}