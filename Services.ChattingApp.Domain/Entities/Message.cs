using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Services.ChattingApp.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public DateTime DateTime { get; set; }

        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        [JsonIgnore]
        public Group? Group { get; set; } = new Group();

        public int SenderId { get; set; }

        [ForeignKey("SenderId")]
        [JsonIgnore]
        public User? Sender { get; set; } = new User();
    }
}