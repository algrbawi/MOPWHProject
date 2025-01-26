using aspnetcore.ntier.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Services.IServices
{
    public interface IDashboardUserService
    {
        Task AddUserAsync(DashboardUserDto model, string password);
        Task EditUserAsync(DashboardUserDto model, string password);
        Task<List<DashboardUserDto>> GetAllAsync();
        Task<DashboardUserDto> GetByEmailAsync(string email);
        Task<DashboardUserDto> GetByIdAsync(int Id);
        Task RemoveUserAsync(int Id);
    }
}
