using aspnetcore.ntier.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Services.IServices
{
    public interface IAccountService
    {
        Task<LoginResponseDto> Login(string Email, string Password, bool IsPersistent);
    }
}
