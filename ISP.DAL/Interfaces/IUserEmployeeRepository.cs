namespace ISP.DAL.Interfaces;

public interface IUserEmployeeRepository
{
    Task<string> GetEmployeeIdByUserIdAsync(string userId);
    
    Task<string> GetUserIdByEmployeeIdAsync(string employeeId);
    
    Task AddUserEmployeeAsync(string userId, string employeeId);
}