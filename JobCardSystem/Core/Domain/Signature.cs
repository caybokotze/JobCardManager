using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Signature
    {
        public int Id { get; set; }

        public string FileDir { get; set; }

        #region Navigational Properties

        public int CustomerId { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        #endregion

    }
}