﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using JobCardSystem.Persistence;

namespace JobCardSystem.BusinessLogic
{
    public class PushBullet
    {

        public static void StockAlert()
        {
            //String apiKey = "o.wrR3pnPlvDoFj2h4DLDFCtvrASI53jVl";
            ////String apiKey = "o.2OU1tt3SygeQxzc7vUsgEV7rdpBA1pyS";
            //String type = "note", title = "Limit Warning", body = "Stock is running low for this item.";
            //byte[] data = Encoding.ASCII.GetBytes(String.Format("{{ \"type\": \"{0}\", \"title\": \"{1}\", \"body\": \"{2}\" }}", type, title, body));

            //var request = System.Net.WebRequest.Create("https://api.pushbullet.com/v2/pushes") as System.Net.HttpWebRequest;
            //request.Method = "POST";
            //request.ContentType = "application/json";
            //request.Credentials = new System.Net.NetworkCredential(apiKey, "");
            //// var to = new PhoneNumber("+27662127924");

            //request.ContentLength = data.Length;
            //String responseJson = null;

            //using (var requestStream = request.GetRequestStream())
            //{
            //    requestStream.Write(data, 0, data.Length);
            //    requestStream.Close();
            //}

            //using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            //{
            //    using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            //    {
            //        responseJson = reader.ReadToEnd();
            //    }
            //}
        }

        public static void Assigned(string userId)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            var user = _context.Users.SingleOrDefault(s => s.Id == userId);
            
            String apiKey = "o.wrR3pnPlvDoFj2h4DLDFCtvrASI53jVl";
            String type = "note", title = "Job Assignment", body = "A job has been assigned to " + user.Name + " " + user.Surname +". Log in to view your assignment.";
            byte[] data = Encoding.ASCII.GetBytes(String.Format("{{ \"type\": \"{0}\", \"title\": \"{1}\", \"body\": \"{2}\" }}", type, title, body));

            var request = System.Net.WebRequest.Create("https://api.pushbullet.com/v2/pushes") as System.Net.HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Credentials = new System.Net.NetworkCredential(apiKey, "");
            // var to = new PhoneNumber("+27662127924");

            request.ContentLength = data.Length;
            String responseJson = null;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
            }

            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    responseJson = reader.ReadToEnd();
                }
            }
        }
    }
}