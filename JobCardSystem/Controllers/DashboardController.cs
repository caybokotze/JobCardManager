using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCardSystem.Constants;

namespace JobCardSystem.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class DashboardController : ApplicationBaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}