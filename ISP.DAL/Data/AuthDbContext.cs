using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Data;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : IdentityDbContext(options);