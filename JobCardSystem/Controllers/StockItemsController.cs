using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using AutoMapper;
using JobCardSystem.BusinessLogic;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.ViewModels;
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
            var list = _unitOfWork.StockItems.GetStockItemsWithSuppliers();
            var vmList = ListMapper.StockItemListMapper(list.ToList());
            return View(vmList);
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
            StockItemViewModel svm = new StockItemViewModel();
            svm.Suppliers = _unitOfWork.Suppliers.GetAll().ToList();
            return View(svm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockItem stockItem, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var name = file.FileName;
                var dotExt = Path.GetExtension(name);
                var currentDts = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
                var dir = HostingEnvironment.ApplicationPhysicalPath + "\\Content\\Assets\\Images\\StockPictures\\";
                try
                {
                    file.SaveAs(dir + currentDts + dotExt);
                    stockItem.FileDir = currentDts + dotExt;
                } 
                catch (Exception exception)
                {
                    //Log.Save(exception);
                    Directory.CreateDirectory(dir);
                    file.SaveAs(dir + currentDts + dotExt);
                    stockItem.FileDir = currentDts + dotExt;
                }
                //
                _unitOfWork.StockItems.Add(stockItem);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(Mapper.Map<StockItem, StockItemViewModel>(stockItem));
            
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
            else
            {
                _unitOfWork.StockItems.Remove(stockItem);
                _unitOfWork.Complete();
            }

            return RedirectToAction("Index");
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