using aspnetcore.ntier.DAL.Entities;
using aspnetcore.ntier.DAL.Password;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace aspnetcore.ntier.DAL.DataContext;

public class AspNetCoreNTierDbContext : DbContext
{
    public AspNetCoreNTierDbContext(DbContextOptions<AspNetCoreNTierDbContext> options) : base(options) { }

    public DbSet<ApiUser> ApiUsers { get; set; }
    public DbSet<DashboardUser> DashboardUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        byte[] hashedPassword;
        byte[] passwordSalt;

        HashPassword.CreatePasswordHash("123qwe", out hashedPassword, out passwordSalt);
        modelBuilder.Entity<ApiUser>().HasData(

             new ApiUser
             {
                 Id = 1,
                 Email = "admin@admin.com",
                 PasswordHash = hashedPassword,
                 PasswordSalt = passwordSalt
             }
         );

        modelBuilder.Entity<DashboardUser>().HasData(
        new DashboardUser
        {
            Id = 1,
            Email = "admin@admin.com",
            Name = "Admin",
            PasswordHash = hashedPassword,
            PasswordSalt= passwordSalt
        }
    );
    }
}