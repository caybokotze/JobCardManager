using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.ViewModels;
using JobCardSystem.Persistence;

namespace JobCardSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Customers
        public ActionResult Index(int? page, int? numberOfItems)
        {
            if (page == null || numberOfItems == null)
            {
                return View(_unitOfWork.Customers.GetCustomersWithContracts(1, 10));
            }
            return View(_unitOfWork.Customers.GetCustomersWithContracts((int)page, (int)numberOfItems));
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _unitOfWork.Customers.Get((int) id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            CustomerViewModel customerVm = new CustomerViewModel();

            customerVm.MaintenanceContracts = _unitOfWork.MaintenanceContracts.GetAll().ToList();
            customerVm.ServiceContracts = _unitOfWork.ServiceContracts.GetAll().ToList();

            return View(customerVm);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CreatedAt = DateTime.Now;
                _unitOfWork.Customers.Add(customer);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var customerVm = Mapper.Map<Customer, CustomerViewModel>(customer);
            customerVm.MaintenanceContracts = _unitOfWork.MaintenanceContracts.GetAll().ToList();
            customerVm.ServiceContracts = _unitOfWork.ServiceContracts.GetAll().ToList();

            return View(customerVm);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = _unitOfWork.Customers.Get((int) id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "Id,ActiveState,Name,Address,Customer_email,Industry,Client,Contact_Name,Contact_Number,Contact_Email,MaintenanceContract,ContractDuration,ServicesPerMonth")] 
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Customers.Update(customer);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = _unitOfWork.Customers.Get((int) id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = _unitOfWork.Customers.Get((int) id);
            _unitOfWork.Customers.Remove(customer);
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
