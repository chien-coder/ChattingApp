using System.Text.Json.Serialization;

namespace Services.ChattingApp.Domain.Entities
{
    public class GroupUsers
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public string? Name { get; set; }

        public Group Group { get; set; }

        public User User { get; set; }
    } 
}