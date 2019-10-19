using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobCardSystem.BusinessLogic
{
    public class RandomString
    {
        public static string Generate()
        {
            return Guid.NewGuid().ToString();
        }

        //var userManager = new UserManager(context);
        //var passwordHash = userManager.PasswordHasher.HashPassword("mySecurePassword");
    }
}