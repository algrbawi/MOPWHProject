using aspnetcore.ntier.DAL.DataContext;
using aspnetcore.ntier.DAL.Entities;
using aspnetcore.ntier.DAL.Repositories.IRepositories;

namespace aspnetcore.ntier.DAL.Repositories;

public class UserRepository : GenericRepository<ApiUser>, IUserRepository
{
    private readonly AspNetCoreNTierDbContext _aspNetCoreNTierDbContext;
    public UserRepository(AspNetCoreNTierDbContext aspNetCoreNTierDbContext) : base(aspNetCoreNTierDbContext)
    {
        _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
    }

    public async Task<ApiUser> UpdateUserAsync(ApiUser user)
    {
        _ = _aspNetCoreNTierDbContext.Update(user);

        // Ignore password property update for user
        _aspNetCoreNTierDbContext.Entry(user).Property(x => x.Password).IsModified = false;

        await _aspNetCoreNTierDbContext.SaveChangesAsync();
        return user;
    }
}
