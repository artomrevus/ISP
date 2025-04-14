namespace ISP.BLL.DTOs.ISP.ClientStatus;

public class UpdateClientStatusDto
{
    public int Id { get; set; }

    public string ClientStatusName { get; set; } = default!;
}