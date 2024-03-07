namespace Services.ChattingApp.Domain.Base.Entities
{
    public interface IAudit
    {
        DateTime CreateDate { get; set; }
        int CreateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        int? UpdateBy { get; set; }
    }
}
