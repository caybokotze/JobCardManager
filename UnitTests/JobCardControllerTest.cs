using System;
using System.Web.Mvc;
using JobCardSystem.Controllers;
using JobCardSystem.Core;
using JobCardSystem.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class JobCardControllerTest
    {
        [TestMethod]
        public void Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            var controller = new JobCardsController(unitOfWork);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(expected: "Index", actual: result.ViewName);
        }

        [TestMethod]
        public void Create()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            var controller = new CustomersController(unitOfWork);
            var result = controller.Create() as ViewResult;
            Assert.AreEqual(expected: "Create", actual: result.ViewName);
        }
    }
}
