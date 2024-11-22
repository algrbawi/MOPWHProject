using aspnetcore.ntier.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.ntier.DAL.DataContext;

public class AspNetCoreNTierDbContext : DbContext
{
    public AspNetCoreNTierDbContext(DbContextOptions<AspNetCoreNTierDbContext> options) : base(options) { }

    public DbSet<ApiUser> ApiUsers { get; set; }
    public DbSet<DashboardUser> DashboardUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiUser>().HasData(
             new ApiUser
             {
                 Id = 1,
                 Email = "admin@admin.com",
                 Password = "123",
             }
         );

        modelBuilder.Entity<DashboardUser>().HasData(
        new DashboardUser
        {
            Id = 1,
            Email = "admin@admin.com",
            Password = "123",
            Name = "Admin",
        }
    );
    }
}