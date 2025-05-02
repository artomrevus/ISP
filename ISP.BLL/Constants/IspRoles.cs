namespace ISP.BLL.Constants;

public static class IspRoles
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

    public static Dictionary<string, string> PositionsRoles = new()
    {
        { EmployeePositionConstants.OfficeManager, IspRoles.OfficeManager },
        { EmployeePositionConstants.WarehouseWorker, IspRoles.WarehouseWorker },
        { EmployeePositionConstants.NetworkTechnician, IspRoles.NetworkTechnician },
        { EmployeePositionConstants.Recruiter, IspRoles.HumanResource },
    };
}