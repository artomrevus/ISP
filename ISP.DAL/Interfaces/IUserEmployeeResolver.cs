namespace ISP.DAL.Interfaces;

public interface IUserEmployeeResolver
{
    Task<string> GetEmployeeIdByUserIdAsync(string userId);
}