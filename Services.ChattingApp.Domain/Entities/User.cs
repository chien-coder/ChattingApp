﻿namespace Services.ChattingApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public List<Group>? Groups { get; set; }
    }
}