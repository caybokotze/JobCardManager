using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobCardSystem.BusinessLogic;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using Microsoft.Owin;

namespace JobCardSystem.Controllers
{
    public class StockItemsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var list = _unitOfWork.StockItems.GetAll();

            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StockItem stockItem = _unitOfWork.StockItems.Get((int)id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }
            return View(stockItem);
        }

        public ActionResult Create()
        {
            StockItem jvm = new StockItem();

            return View(jvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockItem stockItem, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.StockItems.Add(stockItem);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(stockItem);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StockItem stockItem = _unitOfWork.StockItems.Get((int)id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }
            return View(stockItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.StockItems.Update(stockItem);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            
            return View(stockItem);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = _unitOfWork.StockItems.Get((int)id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }
            return View(stockItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockItem stockItem = _unitOfWork.StockItems.Get((int)id);
            _unitOfWork.StockItems.Remove(stockItem);
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