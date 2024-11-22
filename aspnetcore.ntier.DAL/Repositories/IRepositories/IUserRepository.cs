using aspnetcore.ntier.DAL.Entities;

namespace aspnetcore.ntier.DAL.Repositories.IRepositories;

public interface IUserRepository : IGenericRepository<ApiUser>
{
    Task<ApiUser> UpdateUserAsync(ApiUser user);
}
