using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobCardSystem.Constants
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string Technician = "Technician";
        public const string AdminOrTech = Admin + " , " + Technician;
    }
}