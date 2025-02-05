using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.DAL.Entities;
using aspnetcore.ntier.DAL.Password;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using aspnetcore.ntier.DTO.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Services.Dashboard
{
    public class DashboardUserService : IDashboardUserService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<DashboardUser> _dashboardRepository;
        private readonly IGenericRepository<AccessUser> _accessUserRepository;
        public DashboardUserService(IMapper mapper, IGenericRepository<DashboardUser> dashboardRepository, IGenericRepository<AccessUser> accessUserRepository)
        {
            _mapper = mapper;
            _dashboardRepository = dashboardRepository;
            _dashboardRepository = dashboardRepository;
            _accessUserRepository = accessUserRepository;
        }

        public async Task<List<DashboardUserDto>> GetAllAsync()
        {
            var users = await _dashboardRepository.GetListAsync(null, include: inc => inc.Include(ac => ac.AccessUsers));
            return _mapper.Map<List<DashboardUserDto>>(users);
        }

        public async Task<DashboardUserDto> GetByIdAsync(int Id)
        {
            var user = await _dashboardRepository.GetAsync(x => x.Id == Id, include: inc => inc.Include(ac => ac.AccessUsers));
            return _mapper.Map<DashboardUserDto>(user);
        }
        public async Task<DashboardUserDto> GetByEmailAsync(string email)
        {
            var user = await _dashboardRepository.GetAsync(x => x.Email == email, include: inc => inc.Include(ac => ac.AccessUsers));
            return _mapper.Map<DashboardUserDto>(user);
        }
        public async Task EditUserAsync(DashboardUserDto model, string password)
        {

            var users = await _dashboardRepository.GetListAsync(x => x.IsSuperAdmin);
            var user = await _dashboardRepository.GetAsync(x => x.Email == model.Email, include: inc => inc.Include(ac => ac.AccessUsers));
            if (user.Id != model.Id)
            {
                throw new Exception("البريد الألكتروني مستخدم من قبل مستخدم اخر");
            }

            if (users.Count() < 2 && !model.IsSuperAdmin && users.FirstOrDefault(x => x.Id == model.Id) is not null)
            {
                model.IsSuperAdmin = true;
            }



            user.Name = model.Name;
            user.Email = model.Email;
            user.IsAllowedToEdit = model.IsAllowedToEdit;
            user.IsSuperAdmin = model.IsSuperAdmin;
            if (password != "------")
            {
                byte[] hashedPassword;
                byte[] passwordSalt;
                HashPassword.CreatePasswordHash(password, out hashedPassword, out passwordSalt);
                user.PasswordHash = hashedPassword;
                user.PasswordSalt = passwordSalt;
            }
            if (!model.IsSuperAdmin)
            {
                user.AccessUsers = _mapper.Map<List<AccessUser>>(model.AccessUsers);
            }
            else
            {
                user.AccessUsers = null;
            }
            await _accessUserRepository.DeleteRangeAsync(x => x.DashboardUserId == model.Id);
            await _dashboardRepository.UpdateAsync(user);


        }
        public async Task AddUserAsync(DashboardUserDto model, string password)
        {
            var user = await _dashboardRepository.GetAsync(x => x.Email == model.Email, include: inc => inc.Include(ac => ac.AccessUsers));
            if (user is not null)
            {
                throw new Exception("البريد الألكتروني مستخدم من قبل مستخدم اخر");
            }
            user = new DashboardUser();
            user.Name = model.Name;
            user.Email = model.Email;
            user.IsSuperAdmin = model.IsSuperAdmin;
            byte[] hashedPassword;
            byte[] passwordSalt;
            HashPassword.CreatePasswordHash(password, out hashedPassword, out passwordSalt);
            user.PasswordHash = hashedPassword;
            user.PasswordSalt = passwordSalt;
            user.IsAllowedToEdit = model.IsAllowedToEdit;

            if (!model.IsSuperAdmin)
            {
                user.AccessUsers = _mapper.Map<List<AccessUser>>(model.AccessUsers);
            }
            else
            {
                user.AccessUsers = null;
            }
            await _dashboardRepository.AddAsync(user);
        }
        public async Task RemoveUserAsync(int Id)
        {
            var users = await _dashboardRepository.GetListAsync(x => x.IsSuperAdmin == true);
            var user = await _dashboardRepository.GetAsync(x => x.Id == Id);
            if (user is not null && user.IsSuperAdmin && users.Where(x => x.IsSuperAdmin == true).Count() < 2)
            {
                return;
            }
            await _dashboardRepository.DeleteAsync(user);

        }
    }
}
