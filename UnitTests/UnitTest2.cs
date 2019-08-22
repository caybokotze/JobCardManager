using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCardSystem.Controllers;
using JobCardSystem.BusinessLogic;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.ViewModels;
using JobCardSystem.Persistence;

namespace UnitTests
{
    [TestClass]
    public class UnitTest2
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


        [TestMethod]
        public void TestListJobcard()
        {
            JobCardSystem.BusinessLogic.ListMapper listMapper = new ListMapper();
            var jobcardlist = new List<JobCard>()
            {
                new JobCard()
                {

            Id = 1,
            Distance = 10,
            JobStatusId = 1,
            JobTypeId = 1

    }
            };
            var testResult = ListMapper.JobCardListMapper(jobcardlist);

            var JobcardVMList = new List<JobCardViewModel>()
            {
                new JobCardViewModel()
                {

                    Id = 1,
                    Distance = 10,
                    JobStatusId = 1,
                    JobTypeId = 1

                }
            };

            var expected = ListMapper.JobCardListMapper(jobcardlist);

            Assert.AreEqual(expected, JobcardVMList);
        }


        [TestMethod]
        public void TestStockItem()
        {
            JobCardSystem.BusinessLogic.ListMapper listMapper = new ListMapper();
            var Stockitemlist = new List<StockItem>()
            {
                new StockItem()
                {


         Name = "Johnson",
         QuantityAvailable = 30,
         Cost = 250,
         SellingPrice = 350,


                }
            };
            var testResult = ListMapper.StockItemListMapper(Stockitemlist);

            var StockItemVM = new List<StockItemViewModel>()
            {
                new StockItemViewModel()
                {
         Name = "Johnson",
         QuantityAvailable = 30,
         Cost = 250,
         SellingPrice = 350,


                }
            };

            var expected = ListMapper.StockItemListMapper(Stockitemlist);

            Assert.AreEqual(expected, StockItemVM);
        }




    }
}

