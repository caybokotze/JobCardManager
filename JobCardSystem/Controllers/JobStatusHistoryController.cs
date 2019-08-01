using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Controllers
{
    public class JobStatusHistoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public JobStatusHistoryController(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        // GET: JobStatusHistory
        public ActionResult Index()
        {
            var list = _unitOfWork.JobStatusHistory.GetAll().ToList();
            return View(list);
        }

        // GET: JobStatusHistory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobStatusHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(JobStatusHistory history)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.JobStatusHistory.Add(history);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }

                return View(history);
            }
            catch
            {
                return View();
            }
        }

        // GET: JobStatusHistory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobStatusHistory/Edit/5
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

        // GET: JobStatusHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobStatusHistory/Delete/5
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
