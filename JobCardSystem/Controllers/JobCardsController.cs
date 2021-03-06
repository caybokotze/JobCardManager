﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using JobCardSystem.BusinessLogic;
using JobCardSystem.Constants;
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

            IEnumerable<JobCard> jobCards = new List<JobCard>();

            if (User.IsInRole(UserRoles.Admin))
            {
                jobCards = _unitOfWork.JobCards.GetJobCardWithAllTypes(1, 100);
            }else if (User.IsInRole(UserRoles.Technician))
            {
                jobCards = _unitOfWork.JobCards.GetJobCardForUser(User.Identity.GetUserId());
            }
            //foreach (var item in list2)
            //{
            //    var signature = _unitOfWork.CustomerSignatures.Get((int)item.SignatureId);
            //    item.CustomerSignature = signature;
            //    list.Add(item);
            //}

            return View(jobCards);
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
            //JobCardViewModel jvm = new JobCardViewModel();
            //jvm.JobStatuses = _unitOfWork.JobStatuses.GetAll().ToList();
            //jvm.JobTypes = _unitOfWork.JobTypes.GetAll().ToList();
            ////jvm.Customers = _unitOfWork.Customers.GetAll().ToList();
            //jvm.Staff = _context.Users.ToList();
            return View("Index");
        }

        public ActionResult Download(int id)
        {
            return RedirectToAction("Download", "Quotation", new {id = id});
        }

        public ActionResult Assign(int? id)
        {
            if (id.HasValue)
            {
                //
                JobCardViewModel jvm = new JobCardViewModel();
                jvm.Staff = _context.Users.ToList();
                jvm.JobTypes = _unitOfWork.JobTypes.GetAll().ToList();
                jvm.Id = (int)id;
                //
                return View(jvm);
            }
            else return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Assign(JobCardViewModel jobCardViewModel)
        {
            IUnitOfWork testUnit = new UnitOfWork(_context);
            testUnit.JobCards.SingleOrDefault(s => s.Id == jobCardViewModel.Id);
            //
            var job = Mapper.Map<JobCardViewModel, JobCard>(jobCardViewModel);
            job.ScheduledFor = jobCardViewModel.ScheduledFor;
            job.JobStatusId = 2;
            job.CustomerId = jobCardViewModel.CustomerId;

            var userList = new List<ApplicationUser>();

            foreach (var userId in jobCardViewModel.ApplicationUserIdArray)
            {
                var user = _context.Users.SingleOrDefault(s => s.Id == userId);
                userList.Add(user);
                PushBullet.Assigned(user.Id);
            }

            job.ApplicationUsers = userList;

            testUnit.JobCards.Update(job);
            testUnit.Complete();

            

            return RedirectToAction("Index");
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
                job.ScheduledFor = jobCardViewModel.ScheduledFor;

                var customer = testUnit.Customers.SingleOrDefault(f => f.Id == jobCardViewModel.CustomerId);
                job.Customer = customer;

                var userList = new List<ApplicationUser>();

                foreach (var userId in jobCardViewModel.ApplicationUserIdArray)
                {
                    var user = _context.Users.SingleOrDefault(s => s.Id == userId);
                    userList.Add(user);
                    PushBullet.Assigned(userId);
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

        public ActionResult SignatureBinder()
        {
            var signature = _context.CustomerSignatures.OrderByDescending(d => d.Id).FirstOrDefault();
            var jobcard = _context.JobCards.OrderByDescending(d => d.LastUpdated).FirstOrDefault();

            jobcard.SignatureId = signature.Id;
            _context.Entry(jobcard).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Technician(int? id)
        {
            return View("Technician");
        }

        public ActionResult Pending()
        {
            var jobCards = _unitOfWork.JobCards.GetAllJobCardWithQuotation();
            //_unitOfWork.JobCards.
            return View("Pending", jobCards);
        }

        [Authorize(Roles = UserRoles.AdminOrTech)]
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole(UserRoles.Technician))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                JobCard jobCard = _unitOfWork.JobCards.GetJobCardWithCustomer((int) id);
                if (jobCard == null)
                {
                    return HttpNotFound();
                }
                //
                JobCardViewModel jvm = Mapper.Map<JobCard, JobCardViewModel>(jobCard);

                JobCard jc = new JobCard();

                jvm.Id = jobCard.Id;
                jvm.CustomerId = (int)jobCard.CustomerId;
                jvm.Customer = jobCard.Customer;
                jvm.JobTypeId = jobCard.JobTypeId;
                jvm.JobStatusId = jobCard.JobStatusId;
                //
                jvm.JobStatuses = _unitOfWork.JobStatuses.GetAll().ToList();
                jvm.JobTypes = _unitOfWork.JobTypes.GetAll().ToList();
                jvm.Staff = _context.Users.ToList();
                //
                return View("Technician", jvm);
            }
            else
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
                JobCardViewModel jvm = new JobCardViewModel();
                jvm.Id = jobCard.Id;
                jvm.CustomerId = (int)jobCard.CustomerId;
                jvm.JobTypeId = jobCard.JobTypeId;
                jvm.JobStatusId = jobCard.JobStatusId;
                //
                jvm.JobStatuses = _unitOfWork.JobStatuses.GetAll().ToList();
                jvm.JobTypes = _unitOfWork.JobTypes.GetAll().ToList();
                jvm.Staff = _context.Users.ToList();
                //
                return View("Admin", jvm);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRoles.AdminOrTech)]
        public ActionResult Edit(JobCard jobCard)
        {
            if (ModelState.IsValid)
            {
                jobCard.LastUpdated = DateTime.Now;
                _unitOfWork.JobCards.Update(jobCard);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            //
            JobCardViewModel jvm = new JobCardViewModel();
            jvm.JobStatuses = _unitOfWork.JobStatuses.GetAll().ToList();
            //
            return RedirectToAction("Create", "Signature");
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


        public ActionResult Close(int? id)
        {
            return RedirectToAction("Create", "Signature", new {id = id});
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
