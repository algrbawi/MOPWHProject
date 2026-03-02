using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Static
{
    public static class CustomClaims
    {
        public static string UserHashedPassword = "UserHashedPassword";
        public static string UserFullName = "UserFullName";
        public static string UserId = "UserId";
    }
}
