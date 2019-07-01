using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobCardSystem.BusinessLogic
{
    public class GetDisplayName
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }

    public class GetIdentityDisplayName
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
    }
}