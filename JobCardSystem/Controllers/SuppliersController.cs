using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using JobCardSystem.Persistence;

namespace JobCardSystem.Controllers
{
    public class SuppliersController : ApplicationBaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuppliersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            
            ApplicationDbContext context = new ApplicationDbContext();
            var list = context.Suppliers.Where(w => w.Delete == false).ToList();
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supplier supplier = _unitOfWork.Suppliers.Get((int)id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        public ActionResult Create()
        {
            Supplier supplier = new Supplier();

            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Suppliers.Add(supplier);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supplier supplier = _unitOfWork.Suppliers.Get((int)id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            //
            //
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Suppliers.Update(supplier);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _unitOfWork.Suppliers.Get((int)id);
            supplier.Delete = true;
            if (supplier == null)
            {
                return HttpNotFound();
            }
            _unitOfWork.Suppliers.Update(supplier);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = _unitOfWork.Suppliers.Get((int)id);
            _unitOfWork.Suppliers.Remove(supplier);
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