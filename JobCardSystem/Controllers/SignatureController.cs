using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace JobCardSystem.Controllers
{
    public class SignatureViewController : Controller
    {
        public ActionResult Create()
        {
            return View("~/Views/Signature/View.cshtml");
        }
    }

    public class SignatureController : ApiController
    {
        

        [System.Web.Mvc.HttpPost]
        public void Create([FromBody] string base64)
        {
            
        }

        
    }

    
}