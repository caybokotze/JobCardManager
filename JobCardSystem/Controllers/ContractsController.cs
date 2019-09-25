using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCardSystem.Persistence;

namespace JobCardSystem.Controllers
{
    public class ContractsController : Controller
    {
        private ApplicationDbContext _context;
        public ContractsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Contracts
        public ActionResult Index()
        {
            var list = _context.ServiceContracts.ToList();
            return View(list);
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contracts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contracts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contracts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
