using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace JobCardSystem.Core.Domain
{
    public class Image
    {
        public int Id { get; set; }

        public string Dir { get; set; }

        public virtual ICollection<JobCard> JobCards { get; set; }
    }
}