using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.ViewModels;

namespace JobCardSystem.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobCard, JobCardViewModel>();
            CreateMap<JobCardViewModel, JobCard>();
        }
    }
}