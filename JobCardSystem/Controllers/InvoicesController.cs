
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;


namespace JobCardSystem.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
