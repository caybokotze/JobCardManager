using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobCardSystem.Controllers
{
    public class SystemController : Controller
    {
        public SystemController()
        {
            
        }
        // GET: System
        public ActionResult GetAreas()
        {
            return View();
        }

        public void DeleteAreas(int? id)
        {
            
        }
    }
}