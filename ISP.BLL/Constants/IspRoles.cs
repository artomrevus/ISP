namespace ISP.BLL.Constants;

public class IspRoles
{
    public const string Admin = "Admin";
    public const string OfficeManager = "OfficeManager";
    public const string WarehouseWorker = "WarehouseWorker";
    public const string NetworkTechnician = "NetworkTechnician";
    public const string HumanResource = "HumanResource";
    
    public static IEnumerable<string> EmployeeRoles()
    {
        return
        [
            OfficeManager,
            WarehouseWorker,
            NetworkTechnician,
            HumanResource,
        ];
    }
}