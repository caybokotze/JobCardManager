using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.ViewModels;
using JobCardSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobCardSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobCard, JobCardViewModel>();
            CreateMap<JobCardViewModel, JobCard>();
            //
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();
            //
            CreateMap<ApplicationUser, AccountViewModel>();
            CreateMap<AccountViewModel, ApplicationUser>();
            //
            CreateMap<ApplicationUser, EditUserViewModel>();
            CreateMap<EditUserViewModel, ApplicationUser>();
            //
            CreateMap<StockItem, StockItemViewModel>();
            CreateMap<StockItemViewModel, StockItem>();
            //
            CreateMap<IdentityRole, RoleViewModel>();
            CreateMap<RoleViewModel, IdentityRole>();
            //

        }
    }
}