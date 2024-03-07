using System.Text.Json.Serialization;

namespace Services.ChattingApp.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [JsonIgnore]
        public List<Conversation> Conversations { get; set; } = new List<Conversation>();

        [JsonIgnore]
        public List<User>? Users { get; set; }
    } 
}