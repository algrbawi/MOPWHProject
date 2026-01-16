using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class DashboardUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsAllowedToEdit { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateOnly LastUpdatePassword { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<AccessUserDto> AccessUsers { get; set; } = new List<AccessUserDto>();

    }
}
