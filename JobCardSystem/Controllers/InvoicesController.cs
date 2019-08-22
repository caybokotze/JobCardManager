
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using InvoiceService;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using Invoice = JobCardSystem.Core.Domain.Invoice;


namespace JobCardSystem.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult DownloadInvoice()
        {

            InvoiceService.Business business = new InvoiceService.Business()
            {
                LogoRootPath = HttpContext.Server.MapPath("~//Content//Assets//Images//icon.png"),
                CompanyName = "Abstergo Industries",
                EmailAddress = "info@abstergo.com",
                WebsiteAddress = "www.abstergo.com",
                PhoneNumber = "031 100 9089",
                PhysicalAddress = "12 Cope Road, Durban",
                BankAccountNumber = "1234456790",
                BankBranchCode = "021234",
                SwiftCode = "SLkjLKJS",
                BankReferenceNumber = "#3333"
            };

            InvoiceService.Client client = new Client(
                "The main company", 
                "Bob", 
                "082 2390 2300",
                "info@company.com",
                "12 Cope Road");

            List<InvoiceService.InvoiceItem> invoiceItems = new List<InvoiceItem>()
            {
                new InvoiceItem()
                {
                    Id = 0,
                    Name = "A bar of soap",
                    Price = 23,
                    Quantity = 1
                },
                new InvoiceItem()
                {
                    Id = 1,
                    Name = "A toilet plunger",
                    Price = 300, 
                    Quantity = 2
                },
                new InvoiceItem()
                {
                    Id = 2,
                    Name = "A rubber duck",
                    Price = 400,
                    Quantity = 2
                }
            };

            InvoiceService.Invoice invoice = new InvoiceService.Invoice()
            {
                Client = client,
                Business = business,
                InvoiceItems = invoiceItems,
                //
                Currency = "R",
                Title = "Invoice",
                InvoiceNumber = "2",
                Discount = 0,
                Status = "Paid",
                Date = DateTime.Now,
            };

            InvoiceService.Generate invoiceGeneration = new Generate();

            byte[] pdfBytes = invoiceGeneration.GetInvoice(invoice);
            return File(pdfBytes, "application/pdf", 
                fileDownloadName: DateTime.Now.ToShortDateString() 
                + "_Invoice_"
                + invoice.Business.BankReferenceNumber + ".pdf");

        }

        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = _unitOfWork.Invoices.GetAll();
            return View(invoices);
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Invoice invoice = _unitOfWork.Invoices.Get((int)id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateTime,Content")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {

                var stockItem = new StockItem();
                stockItem = _unitOfWork.StockItems.Get(1);

                var stockItemList = new List<StockItem>();
                stockItemList.Add(stockItem);

                invoice.StockItems = stockItemList;

                _unitOfWork.Invoices.Add(invoice);

                int entityId = _unitOfWork.Complete();
                return Content(entityId.ToString());
            }

            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Invoice invoice = _unitOfWork.Invoices.Get((int) id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,Content")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(invoice).State = EntityState.Modified;
                _unitOfWork.Invoices.Update(invoice);
                int entityId = _unitOfWork.Complete();

                return RedirectToAction("Index");
                //return Redirect("edit/" + entityId);
            }
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Invoice invoice = _unitOfWork.Invoices.Get((int) id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = _unitOfWork.Invoices.Get((int)id);
            _unitOfWork.Invoices.Remove(invoice);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
