using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.DTO.DTOs;
using System.Net;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using aspnetcore.ntier.DAL.Entities;
using aspnetcore.ntier.DAL.Password;

namespace aspnetcore.ntier.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IGenericRepository<DashboardUser> _dashboardUser;

        public AccountService(IHttpContextAccessor contextAccessor, IGenericRepository<DashboardUser> dashboardUser)
        {
            _contextAccessor = contextAccessor;
            _dashboardUser = dashboardUser;
        }

        public async Task<LoginResponseDto> Login(string Email, string Password, bool IsPersistent)
        {
            var user = await _dashboardUser.GetAsync(x => x.Email == Email);

            var result = new LoginResponseDto()
            {
                StatusCode = HttpStatusCode.OK
            };
            var isValidPassword = HashPassword.VerifyPasswordHash(Password, user?.PasswordHash, user?.PasswordSalt);

            if (user is null || !isValidPassword)
            {
                result.ErrorMessage = "البريد الالكتروني او كلمة المرور غير صحيحة";
                result.StatusCode = HttpStatusCode.BadRequest;
            }

            else
            {
                var claims = new List<Claim>{
                                            new Claim(ClaimTypes.Name, Email),
                                            new Claim("FullName", Email),
                };

                if (user.IsSuperAdmin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "SuperAdmin"));
                }
                else
                {
                    foreach (var item in user.AccessUsers)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.Id.ToString()));
                    }
                }

                var claimsIdentity = new ClaimsIdentity(
               claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = IsPersistent
                };

                await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                               new ClaimsPrincipal(claimsIdentity),
                                                               authProperties);
            }
            return result;
        }
    }
}
