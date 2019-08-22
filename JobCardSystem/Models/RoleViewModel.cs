using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Models
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            
        }

        public RoleViewModel(CustomRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}