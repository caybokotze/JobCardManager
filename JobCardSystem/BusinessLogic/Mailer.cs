using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using JobCardSystem.Persistence;
using RestSharp;
using RestSharp.Authenticators;
using System.Data.Entity;

namespace JobCardSystem.BusinessLogic
{
    public class Mailer
    {
        public static void SendSimpleMessage(int id, string message)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api", "d8be0b7dae46df16dada2fc7e201c863-de7062c6-e85b8d33");
            //
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mail.mergegroup.net", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Abstergo <info@abstergo.org>");
            //
            request.AddParameter("to", "kotzecabo@gmail.com");
            //
            request.AddParameter("subject", "Account Activity: Login Notification.");
            //
            request.AddParameter("text", message);
            //
            request.AddParameter("html", "This is just a simple login notification.");
            request.Method = Method.POST;
            client.Execute(request);

        }

        public static void SendApprovalRequest(int id, string message)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var quote = db.Quotations.Include(i => i.Customer).SingleOrDefault(s => s.Id == id);
            var email = quote.Customer.Email;

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api", "d8be0b7dae46df16dada2fc7e201c863-de7062c6-e85b8d33");
            //
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mail.mergegroup.net", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Abstergo <info@abstergo.org>");
            //
            request.AddParameter("to", email);
            //
            request.AddParameter("subject", "Please check and approve this quote.");
            //
            request.AddParameter("text", message);
            //
            request.AddParameter("html", "<a href='https://jobcardsystem.azurewebsites.net/quotation/approve/" + id + "'>Click here to view your quotation.</a>");
            request.Method = Method.POST;
            client.Execute(request);
        }

        public void SendLoginNotification()
        {

        }

        public void StockAlertNotification()
        {

        }

    }
}