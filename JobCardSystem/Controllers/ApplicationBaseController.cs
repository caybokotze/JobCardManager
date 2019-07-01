using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCardSystem.Core;
using JobCardSystem.Persistence;

namespace JobCardSystem.Controllers
{
    public class ApplicationBaseController : Controller
    {
        private ApplicationDbContext _context;

        public ApplicationBaseController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var identityUserName = User.Identity.Name;

                if (!string.IsNullOrEmpty(identityUserName))
                {
                    var user = _context.Users.SingleOrDefault(u => u.UserName == identityUserName);
                    ViewData.Add("DisplayName", user.Name);
                    
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}