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
    public class JobCardsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobCardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: JobCards
        public ActionResult Index()
        {
            var list = _unitOfWork.JobCards.GetAll();
            return View(list);
        }

        // GET: JobCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            JobCard jobCard = _unitOfWork.JobCards.Get((int) id);
            if (jobCard == null)
            {
                return HttpNotFound();
            }
            return View(jobCard);
        }

        // GET: JobCards/Create
        public ActionResult Create()
        {
            JobCardViewModel jvm = new JobCardViewModel();
            jvm.JobStatuses = _unitOfWork.JobStatuses.GetAll().ToList();
            jvm.JobTypes = _unitOfWork.JobTypes.GetAll().ToList();

            return View(jvm);
        }

        // POST: JobCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreatedAt,ScheduledFor,JobTotal,SiteLocation,ArrivalTime,DepartureTime,Distance,JobStatusId,JobTypeId")] JobCard jobCard)
        {
            if (ModelState.IsValid)
            {
                jobCard.CreatedAt = DateTime.Now;
                //Add the total for the job here.
                _unitOfWork.JobCards.Add(jobCard);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var jobCardVm = Mapper.Map<JobCard, JobCardViewModel>(jobCard);

            jobCardVm.JobStatuses = _unitOfWork.JobStatuses.GetAll().ToList();
            jobCardVm.JobTypes = _unitOfWork.JobTypes.GetAll().ToList();

            return View(jobCardVm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            JobCard jobCard = _unitOfWork.JobCards.Get((int)id);
            if (jobCard == null)
            {
                return HttpNotFound();
            }
            //
            JobCardViewModel jvm = Mapper.Map<JobCard, JobCardViewModel>(jobCard);
            jvm.JobStatuses = _unitOfWork.JobStatuses.GetAll().ToList();
            jvm.JobTypes = _unitOfWork.JobTypes.GetAll().ToList();
            //
            return View(jvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobCard jobCard)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.JobCards.Update(jobCard);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            //
            JobCardViewModel jvm = new JobCardViewModel();
            jvm.JobStatuses = _unitOfWork.JobStatuses.GetAll().ToList();
            //
            return View(jvm);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCard jobCard = _unitOfWork.JobCards.Get((int) id);
            if (jobCard == null)
            {
                return HttpNotFound();
            }
            return View(jobCard);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobCard jobCard = _unitOfWork.JobCards.Get((int) id);
            _unitOfWork.JobCards.Remove(jobCard);
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
