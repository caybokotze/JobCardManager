using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.ViewModels;
using JobCardSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

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

        public static List<StockItemViewModel> StockItemListMapper(List<StockItem> mappingObjectList)
        {
            var objectList = new List<StockItemViewModel>();
            foreach (var item in mappingObjectList)
            {
                var mappedModel = Mapper.Map<StockItem, StockItemViewModel>(item);
                objectList.Add(mappedModel);
            }
            return objectList;
        }

        public static List<StockItem> StockItemListMapper(List<StockItemViewModel> mappingObjectList)
        {
            var objectList = new List<StockItem>();
            foreach (var item in mappingObjectList)
            {
                var mappedModel = Mapper.Map<StockItemViewModel, StockItem>(item);
                objectList.Add(mappedModel);
            }
            return objectList;
        }

        public static List<RoleViewModel> RoleMapper(List<IdentityRole> mappingObjectList)
        {
            var objectList = new List<RoleViewModel>();
            foreach (var item in mappingObjectList)
            {
                var mappedModel = Mapper.Map<IdentityRole, RoleViewModel>(item);
                objectList.Add(mappedModel);
            }
            return objectList;
        }

        public static List<IdentityRole> RoleMapper(List<RoleViewModel> mappingObjectList)
        {
            var objectList = new List<IdentityRole>();
            foreach (var item in mappingObjectList)
            {
                var mappedModel = Mapper.Map<RoleViewModel, IdentityRole>(item);
                objectList.Add(mappedModel);
            }
            return objectList;
        }



    }
}