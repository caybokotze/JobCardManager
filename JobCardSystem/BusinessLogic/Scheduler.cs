using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using FluentScheduler;
using JobCardSystem.Persistence;
using System.Data.Entity;

namespace JobCardSystem.BusinessLogic
{
    public static class DoTask
    {
        public static void CheckStockLimits()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            foreach (var contextStockItem in context.StockItems)
            {
                if (contextStockItem.LimitWarning >= contextStockItem.QuantityAvailable && contextStockItem.FlagCheck == false)
                {
                    PushBullet.Push();
                    Mailer.SendSimpleMessage(1, "There is a snake in my boot.");
                    //var currentItem = context.StockItems.SingleOrDefault(s => s.Id == contextStockItem.Id);
                    contextStockItem.FlagCheck = true;
                    context.Entry(contextStockItem).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public static void CheckContractDeadlines()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var customerList = context.Customers.Include(i => i.ServiceContract).ToList();
            //
            foreach (var item in context.Customers)
            {
                var serviceContractEndMonth = item.ServiceContract.Months - DateTime.Now.Month;
                if (serviceContractEndMonth == 0)
                {
                    PushBullet.Push();
                    Mailer.SendSimpleMessage(1, "Your contract is about to expire.");
                }
            }
        }
    }
    public class Scheduler : IJob
    {
        public void Execute()
        {
            DoTask.CheckStockLimits();
            //
            DoTask.CheckContractDeadlines();

        }
    }

    public class CustomRegistry : Registry
    {
        public CustomRegistry()
        {
            Schedule<Scheduler>().NonReentrant()
                .ToRunOnceAt(DateTime.Now.AddSeconds(3))
                .AndEvery(3)
                .Seconds();
        }
    }
}