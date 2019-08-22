using System;
using System.Web.Mvc;
using JobCardSystem.Controllers;
using JobCardSystem.Core;
using JobCardSystem.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ManageControllerTest
    {
        [TestMethod]
        public void Index()
        {
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    IUnitOfWork unitOfWork = new UnitOfWork(context);
        //    var controller = new ManageController();
        //    var result = controller.Index(ManageController.ManageMessageId.AddPhoneSuccess) as ActionResult;
        //    Assert.AreEqual(expected: "Index", actual: result.ViewName);
        }

        [TestMethod]
        public void ChangePassword()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            var controller = new ManageController();
            var result = controller.ChangePassword() as ViewResult;
            Assert.AreEqual(expected: "ChangePassword", actual: result.ViewName);
        }

        [TestMethod]
        public void AddPhoneNumber()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            var controller = new ManageController();
            var result = controller.AddPhoneNumber() as ViewResult;
            Assert.AreEqual(expected: "AddPhoneNumber", actual: result.ViewName);
        }
    }
}
