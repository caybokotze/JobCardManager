using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCardSystem.Controllers;
using JobCardSystem.BusinessLogic;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.ViewModels;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
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
    }
}
