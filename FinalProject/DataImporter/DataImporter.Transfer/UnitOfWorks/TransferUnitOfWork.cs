using DataImporter.Data;
using DataImporter.Transfer.Contexts;
using DataImporter.Transfer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.UnitOfWorks
{
    public class TransferUnitOfWork : UnitOfWork, ITransferUnitOfWork
    {
        public IGroupRepository Groups { get; private set; }

        public TransferUnitOfWork(ITransferDbContext transferDbContext, 
            IGroupRepository groupRepository)
           : base((DbContext)transferDbContext)
        {
            Groups = groupRepository;
        }

    }
}
