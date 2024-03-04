using Services.ChattingApp.WebAPI.Enums;

namespace Services.ChattingApp.WebAPI.Entities
{
    public class Result<T>
    {
        /// <summary>
        /// State
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string? ErrorJson { get; set; }

        /// <summary>
        /// Content data
        /// </summary>
        public T? Content { get; set; }
    }
}
