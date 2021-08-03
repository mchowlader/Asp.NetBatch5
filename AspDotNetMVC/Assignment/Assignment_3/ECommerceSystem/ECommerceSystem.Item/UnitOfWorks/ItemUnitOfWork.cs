using ECommerceSystem.Data;
using ECommerceSystem.Item.Contexts;
using ECommerceSystem.Item.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Item.UnitOfWorks
{
    public class ItemUnitOfWork : UnitOfWork, IItemUnitOfWork
    {
        public IProductRepository Products { get; private set; }
        public ItemUnitOfWork(IItemDbContext dbContext,
            IProductRepository  productRepository)
            :base((DbContext)dbContext)
        {
            Products = productRepository;
        }
    }
}
