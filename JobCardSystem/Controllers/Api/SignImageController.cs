using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using JobCardSystem.Blob;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using JobCardSystem.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace JobCardSystem.Controllers.Api
{
    public class SignImageController : ApiController
    {
        //private readonly IUnitOfWork _unitOfWork;

        //public SignImageController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        private readonly ApplicationDbContext _context;

        public SignImageController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Signaturepost
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Signaturepost/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Signaturepost
        public void Post([FromBody] JsonBase64Object obj)
        {
            if (ModelState.IsValid)
            {
                string isolate = obj.Image.Remove(0, 22);
                byte[] imgBytes = Convert.FromBase64String(isolate);
                var dir = @"~\Content\Assets\Images\Signatures\";
                var fileName = DateTime.Now.ToString("yyyyMMMdd-mm-ss") + ".png";
                var imageFile = new FileStream(System.Web.HttpContext.Current.Server.MapPath(dir + fileName), FileMode.Create);
                imageFile.Write(imgBytes, 0, imgBytes.Length);
                imageFile.Flush();
                //
                CustomerSignature aus = new CustomerSignature();
                aus.FileDir = @"Content\Assets\Images\Signatures\" + fileName;
                //
                _context.CustomerSignatures.Add(aus);
                _context.SaveChanges();
                //StorageHandler.Upload(System.Web.HttpContext.Current.Server.MapPath(dir + fileName), dir + fileName);
            }
        }

        // PUT: api/Signaturepost/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Signaturepost/5
        public void Delete(int id)
        {
        }
    }

    public class JsonBase64Object
    {
        public string DisplayName { get; set; }
        public string Image { get; set; }
    }

}
