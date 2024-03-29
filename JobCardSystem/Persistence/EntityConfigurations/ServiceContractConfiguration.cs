﻿using System.Data.Entity.ModelConfiguration;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Persistence.EntityConfigurations
{
    public class ServiceContractConfiguration : EntityTypeConfiguration<ServiceContract>
    {
        public ServiceContractConfiguration()
        {
            HasKey(k => k.Id);
        }
    }
}