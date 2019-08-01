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
using Microsoft.AspNet.Identity;

namespace JobCardSystem.Controllers
{
    [Authorize]
    public class JobCardsController : ApplicationBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private ApplicationDbContext _context;

        public JobCardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = new ApplicationDbContext();
        }

        // GET: JobCards
        public ActionResult Index()
        {
            var list = _unitOfWork.JobCards.GetJobCardWithAllTypes(1, 10);
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
            jvm.Customers = _unitOfWork.Customers.GetAll().ToList();
            jvm.Staff = _context.Users.ToList();

            return View(jvm);
        }

        // POST: JobCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCardViewModel jobCardViewModel)
        {
            if (ModelState.IsValid)
            {
                IUnitOfWork testUnit = new UnitOfWork(_context);

                var job = Mapper.Map<JobCardViewModel, JobCard>(jobCardViewModel);
                job.CreatedAt = DateTime.Now;

                var customer = testUnit.Customers.SingleOrDefault(f => f.Id == jobCardViewModel.CustomerId);
                job.Customers.Add(customer);

                var userList = new List<ApplicationUser>();
                foreach (var userId in jobCardViewModel.ApplicationUserIdArray)
                {
                    var user = _context.Users.SingleOrDefault(s => s.Id == userId);
                    userList.Add(user);
                }

                job.ApplicationUsers = userList;
                testUnit.JobCards.Add(job);
                testUnit.Complete();

                return RedirectToAction("Index");

                /*
                 * Note:
                 * This Code was used to pull the current user as the person the job is allocated to.
                 * //var userId = User.Identity.GetUserId();
                 * //var userFromDb = _context.Users.SingleOrDefault(u => u.Id == userId);
                 * //job.ApplicationUsers.Add(userFromDb);
                 */

            }

            return View(jobCardViewModel);
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

            JobCard jc = new JobCard();

            jvm.JobStatuses = _unitOfWork.JobStatuses.GetAll().ToList();
            jvm.JobTypes = _unitOfWork.JobTypes.GetAll().ToList();
            
            jvm.Staff = _context.Users.ToList();
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
