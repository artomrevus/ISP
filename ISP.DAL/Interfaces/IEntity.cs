namespace ISP.DAL.Interfaces;

public interface IEntity
{
    public int Id { get; set; }
    
    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }
}