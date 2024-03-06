using System.ComponentModel.DataAnnotations.Schema;

namespace Services.ChattingApp.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public DateTime DateTime { get; set; }

        public int SenderId { get; set; }

        [ForeignKey("SenderId")]
        public User Sender { get; set; } = new User();
    }
}