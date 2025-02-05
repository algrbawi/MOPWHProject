using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace aspnetcore.ntier.DAL.Entities;

public class DashboardUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool IsSuperAdmin { get; set; }
    public bool IsAllowedToEdit { get; set; }
    public virtual ICollection<AccessUser> AccessUsers { get; set; } = new List<AccessUser>();
}
