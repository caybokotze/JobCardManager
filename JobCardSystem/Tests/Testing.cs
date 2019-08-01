using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCardSystem.BusinessLogic;
using JobCardSystem.Controllers;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.ViewModels;
using JobCardSystem.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobCardSystem.Tests
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void TestMethod1()
        {
            JobCardSystem.BusinessLogic.ListMapper listMapper = new ListMapper();
            var customerList = new List<Customer>()
            {
                new Customer()
                {
                    Name = "John",
                    CellNumber = "0832902300",
                    MaintenanceContractId = 1,
                    ServiceContractId = 1
                }
            };
            var testResult = ListMapper.CustomerListMapper(customerList);

            var customerVMList = new List<CustomerViewModel>()
            {
                new CustomerViewModel()
                {
                    Name = "John",
                    CellNumber = "0832902300",
                    MaintenanceContractId = 1,
                    ServiceContractId = 1
                }
            };

            var expected = ListMapper.CustomerListMapper(customerList);

            Assert.AreEqual(expected, customerVMList);
        }

        [TestMethod]
        public void TestIndexView()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IUnitOfWork unitOfwork = new UnitOfWork(context);
            var controller = new JobCardsController(unitOfwork);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}