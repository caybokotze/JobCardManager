using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class JobStatusHistory
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Status History Name")]
        public string Name { get; set; }

        #region Nav properties

        public int JobCardId { get; set; }
        //public virtual JobCard JobCard { get; set; }
        #endregion

    }
}