using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace JobCardSystem.BusinessLogic
{
    public static class Log
    {

        public static void Save(Exception error)
        {
            var errorMsg = error.ToString();
            var logicalDrives = Environment.GetLogicalDrives();
            var dir = logicalDrives[0] + "\\Content\\ErrorLogs\\" + DateTime.Now.ToString("yyyy-MM-dd");
            if (Directory.Exists(dir))
            {
                System.IO.File.WriteAllText(dir, errorMsg);
            }
            else
            {
                Directory.CreateDirectory(dir);
                System.IO.File.WriteAllText(dir, errorMsg);
            }
        }

        
    }

    public interface ILog
    {
        void Save(Exception error);
        void Save(Exception error, string userId);
        void Save(Exception error, string userId, string customMessage);
    }
}