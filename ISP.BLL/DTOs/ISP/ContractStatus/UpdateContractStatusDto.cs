namespace ISP.BLL.DTOs.ISP.ContractStatus;

public class UpdateContractStatusDto
{
    public int Id { get; set; }

    public string ContractStatusName { get; set; } = default!;
}