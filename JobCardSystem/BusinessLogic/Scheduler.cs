using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using FluentScheduler;
using JobCardSystem.Persistence;

namespace JobCardSystem.BusinessLogic
{
    public class Scheduler : IJob
    {
        public void Execute()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            foreach (var contextStockItem in context.StockItems)
            {
                if(contextStockItem.LimitWarning >= contextStockItem.QuantityAvailable && contextStockItem.FlagCheck == false)
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