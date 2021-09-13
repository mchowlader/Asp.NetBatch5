using DataImporter.Transfer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.Services
{
    public interface IGroupService
    {
        void CreateGroup(Group group);
        (IList<Group> records, int total, int totalDisplay) GetGroups(int pageIndex, 
            int pageSize, string searchText, string sortText);
        Home CountHomeProperty();
    }
}
