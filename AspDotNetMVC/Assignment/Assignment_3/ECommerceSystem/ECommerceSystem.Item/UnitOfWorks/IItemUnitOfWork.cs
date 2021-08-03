using ECommerceSystem.Data;
using ECommerceSystem.Item.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Item.UnitOfWorks
{
    public interface IItemUnitOfWork : IUnitOfWork
    {
         IProductRepository Products { get;}
    }
}
