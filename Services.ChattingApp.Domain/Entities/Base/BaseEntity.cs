namespace Services.ChattingApp.Domain.Base.Entities
{
    public abstract class BaseEntity : IAudit, IDeleted
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public bool IsDelete { get; set; }
    }
}
