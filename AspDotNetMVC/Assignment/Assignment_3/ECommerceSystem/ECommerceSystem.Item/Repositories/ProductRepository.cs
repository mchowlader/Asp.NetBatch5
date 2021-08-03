using ECommerceSystem.Data;
using ECommerceSystem.Item.Contexts;
using ECommerceSystem.Item.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Item.Repositories
{
    public class ProductRepository 
        : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(IItemDbContext dbContext)
            : base((DbContext)dbContext)
        {

        }
    }
}
