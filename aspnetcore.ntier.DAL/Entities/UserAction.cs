using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DAL.Entities
{
    public class UserAction
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime ActionTime { get; set; }
    }
}
