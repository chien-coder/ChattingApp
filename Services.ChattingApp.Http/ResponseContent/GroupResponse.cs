using System.Text.Json.Serialization;

namespace Services.ChattingApp.Domain.Entities
{
    public class GroupResponse : GroupRequest
    {
        public new List<UserRespone> Users { get; set; }
    } 
}