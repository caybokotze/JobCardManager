﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;

namespace JobCardSystem.Persistence.Repositories
{
    public class StockRepository : Repository<StockItem>, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context;
    }
}