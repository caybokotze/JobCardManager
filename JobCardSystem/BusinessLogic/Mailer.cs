using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;

namespace JobCardSystem.BusinessLogic
{
    public class Mailer
    {
        public static void SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api", "d8be0b7dae46df16dada2fc7e201c863-de7062c6-e85b8d33");

            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mail.mergegroup.net", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Abstergo <info@abstergo.org>");
            request.AddParameter("to", "kotzecabo@gmail.com");

            request.AddParameter("subject", "Account Activity: Login Notification.");

            request.AddParameter("text", "Someone logged into your account.");

            request.Method = Method.POST;
            client.Execute(request);


        }

    }
}