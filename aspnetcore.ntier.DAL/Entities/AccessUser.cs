using aspnetcore.ntier.BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DAL.Entities
{
    [Index(nameof(DashboardUserId), nameof(SiteTblId), IsUnique = true)]

    public class AccessUser
    {
        public int Id { get; set; }
        public int DashboardUserId { get; set; }
        public decimal SiteTblId { get; set; }
        public DashboardUser DashboardUser { get; set; }
        public SiteTbl SiteTbl { get; set; }
    }
}
