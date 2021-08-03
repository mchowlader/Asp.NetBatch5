﻿using InventorySystem.Data;
using InventorySystem.Tracking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tracking.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {

    }
}
