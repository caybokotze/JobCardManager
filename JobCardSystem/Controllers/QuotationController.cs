using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceService;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using JobCardSystem.Persistence;

namespace JobCardSystem.Controllers
{
    public class QuotationController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public QuotationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Quotation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Quotation quotation)
        {
            return null;
        }

        public ActionResult Download(int? id)
        {
            InvoiceService.Business business = new InvoiceService.Business()
            {
                LogoRootPath = HttpContext.Server.MapPath("~//Content//Assets//Images//merge.png"),
                CompanyName = "Merge Group (Pty) Ltd",
                EmailAddress = "info@mergemedia.co.za",
                WebsiteAddress = "www.mergemedia.co.za",
                PhoneNumber = "031 100 8096",
                PhysicalAddress = "16 Rosedale Place, Kloof",
                BankAccountNumber = "62746768235",
                BankBranchCode = "250 655",
                SwiftCode = "FIRNZAJJXXX",
                BankReferenceNumber = "#1561607274945",

            };

            InvoiceService.Client client = new Client(
                "Roag (Mauritius)",
                "Bob",
                "0861007624",
                "info@roag.org",
                "12 Cope Road");

            
            return View(_unitOfWork.Quotes.Get((int)id));
        }
    }
}