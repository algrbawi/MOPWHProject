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
using Microsoft.EntityFrameworkCore;
using aspnetcore.ntier.BLL.Static;

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
            var user = await _dashboardUser.GetAsync(x => x.Email == Email, include: ac => ac.Include(x => x.AccessUsers));

            var result = new LoginResponseDto()
            {
                StatusCode = HttpStatusCode.OK
            };
            var isValidPassword = HashPassword.VerifyPasswordHash(Password, user?.PasswordHash, user?.PasswordSalt);


            if (user is not null && !user.IsActive)
            {
                result.ErrorMessage = "تم إيقاف الحساب";
                result.StatusCode = HttpStatusCode.BadRequest;
            }
            else if (user is not null && !isValidPassword)
            {

                result.ErrorMessage = "البريد الالكتروني او كلمة المرور غير صحيحة";
                result.StatusCode = HttpStatusCode.BadRequest;
                if (user.FailedLoginAttempts >= 2)
                {
                    user.IsActive = false;
                }
                else
                {
                    user.FailedLoginAttempts++;
                }
                await _dashboardUser.UpdateAsync(user);
            }
            else if (user is null || !isValidPassword)
            {
                result.ErrorMessage = "البريد الالكتروني او كلمة المرور غير صحيحة";
                result.StatusCode = HttpStatusCode.BadRequest;
            }

            else
            {
                var claims = new List<Claim>{
                                            new Claim(ClaimTypes.Name, Email),
                                            new Claim(CustomClaims.UserFullName, user.Name),
                };

                if (user.IsSuperAdmin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "SuperAdmin"));
                }
                else
                {
                    foreach (var item in user.AccessUsers)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.SiteTblId.ToString()));
                    }
                }

                if (user.IsAllowedToEdit)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "AllowToEdit"));
                }
                var hexArrayOfBytes = string.Join(string.Empty, Array.ConvertAll(user.PasswordHash, b => b.ToString("X2")));

                claims.Add(new Claim(CustomClaims.UserHashedPassword, hexArrayOfBytes));
                var claimsIdentity = new ClaimsIdentity(
               claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = IsPersistent
                };
                user.FailedLoginAttempts = 0;
                await _dashboardUser.UpdateAsync(user);
                await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                               new ClaimsPrincipal(claimsIdentity),
                                                               authProperties);
            }
            return result;
        }
    }
}
