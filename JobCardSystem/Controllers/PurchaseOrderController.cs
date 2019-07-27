using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.Domain.Configurations;
using JobCardSystem.Core.ViewModels;
using JobCardSystem.Persistence;
using Microsoft.AspNet.Identity;

namespace JobCardSystem.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        public PurchaseOrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = new ApplicationDbContext();
        }

        // GET: PurchaseOrder
        public ActionResult Index()
        {
            var list = _unitOfWork.PurchaseOrders.GetPurchaseOrdersWithSupplierDetails();
            return View(list);
        }

        public ActionResult Create()
        {
            TempPurchaseOrderViewModel purchaseOrderViewModel = new TempPurchaseOrderViewModel();
            /* When we use Javascript we can restrict a user from being able to select a product that does not match something a supplier offers. */
            purchaseOrderViewModel.StockItems = _unitOfWork.StockItems.GetAll().ToList();
            purchaseOrderViewModel.Suppliers = _unitOfWork.Suppliers.GetAll().ToList();
            //
            return View(purchaseOrderViewModel);
        }

        [HttpPost]
        public ActionResult Create(TempPurchaseOrderViewModel purchaseVm)
        {
            if (ModelState.IsValid)
            {
                PurchaseOrder purchaseOrder = new PurchaseOrder();
                purchaseOrder.SupplierId = purchaseVm.SupplierId;
                purchaseOrder.Supplier = _unitOfWork.Suppliers.Get(purchaseOrder.SupplierId);
                //
                //var userId = User.Identity.GetUserId();
                //var userFromDb = _context.Users.SingleOrDefault(u => u.Id == userId);
                _unitOfWork.PurchaseOrders.Add(purchaseOrder);
                int purchaseOrderId = _unitOfWork.Complete();

                var stockItemList = _unitOfWork.StockItems.GetStockItems(purchaseVm.PurchaseOrderItemsIdArray);
                var PoiList = new List<PurchaseOrderItem>();
                foreach (var item in purchaseVm.PurchaseOrderItemsIdArray)
                {
                    var Poi = new PurchaseOrderItem()
                    {
                        StockItemId = item,
                        PurchaseOrderId = purchaseOrderId,
                        AmountOfItems = 1
                    };
                    PoiList.Add(Poi);
                }
                _unitOfWork.PurchaseOrderItems.AddRange(PoiList);
                _unitOfWork.Complete();
            }
            else
            {
                return View(purchaseVm);
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetOrderItemsFromSupplier(int id)
        {
            //Note: Use this space to populate the dropdown list for the product list.
            var returnList = _unitOfWork.StockItems.GetStockItemsWithSupplierId(id);
            return Json(returnList);
        }
    }
}