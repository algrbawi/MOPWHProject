using aspnetcore.ntier.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Services.IServices
{
    public interface ISiteService
    {
        Task AddAsync(SiteTblDto model);
        Task<List<SiteTblDto>> GetListAsync();
        Task<List<SiteTblDto>> GetListAsync(List<decimal>? Ids = null);
        Task<List<SiteTblDto>> GetListAsync(string name);
    }
}
