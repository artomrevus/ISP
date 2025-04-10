using ISP.DAL.Data;
using ISP.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Repositories;

public class UserEmployeeResolver(AuthDbContext dbContext) : IUserEmployeeResolver
{
    public async Task<string> GetEmployeeIdByUserIdAsync(string userId)
    {
        var userEmployee = await dbContext.UserEmployees
            .FirstOrDefaultAsync(x => x.UserId == userId);

        if (userEmployee is null)
        {
            throw new InvalidOperationException($"UserEmployee for user id '{userId}' not found");
        }

        return userEmployee.EmployeeId;
    }
}