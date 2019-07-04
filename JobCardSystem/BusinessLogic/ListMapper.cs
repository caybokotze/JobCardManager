﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.ViewModels;

namespace JobCardSystem.BusinessLogic
{
    public class ListMapper
    {
        public static List<CustomerViewModel> CustomerListMapper(List<Customer> mappingObjectList)
        {
            var objectList = new List<CustomerViewModel>();
            foreach (var item in mappingObjectList)
            {
                var mappedModel = Mapper.Map<Customer, CustomerViewModel>(item);
                objectList.Add(mappedModel);
            }

            return objectList;
        }

        public static List<Customer> CustomerListMapper(List<CustomerViewModel> mappingObjectList)
        {
            var objectList = new List<Customer>();
            foreach (var item in mappingObjectList)
            {
                var mappedModel = Mapper.Map<CustomerViewModel, Customer>(item);
                objectList.Add(mappedModel);
            }

            return objectList;
        }

        public static List<JobCard> JobCardListMapper(List<JobCardViewModel> mappingObjectList)
        {
            var objectList = new List<JobCard>();
            foreach (var item in mappingObjectList)
            {
                var mappedModel = Mapper.Map<JobCardViewModel, JobCard>(item);
                objectList.Add(mappedModel);
            }
            return objectList;
        }

        public static List<JobCardViewModel> JobCardListMapper(List<JobCard> mappingObjectList)
        {
            var objectList = new List<JobCardViewModel>();
            foreach (var item in mappingObjectList)
            {
                var mappedModel = Mapper.Map<JobCard, JobCardViewModel>(item);
                objectList.Add(mappedModel);
            }
            return objectList;
        }

    }
}