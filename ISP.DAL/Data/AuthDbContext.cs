using ISP.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Data;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : IdentityDbContext(options)
{
    public virtual DbSet<UserEmployee> UserEmployees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<UserEmployee>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserEmployees");
            
            entity.Property(e => e.UserId).HasMaxLength(255).HasColumnName("UserId");
            entity.Property(e => e.EmployeeId).HasMaxLength(255).HasColumnName("EmployeeId").IsRequired();
        });
    }
}