using AutoMapper;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Transfer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.Services
{
    public class GroupService : IGroupService
    {
        private readonly IMapper _mapper;
        private readonly ITransferUnitOfWork _transferUnitOfWork;

        public GroupService(IMapper mapper,ITransferUnitOfWork transferUnitOfWork)
        {
            _mapper = mapper;
            _transferUnitOfWork = transferUnitOfWork;
        }

        public void CreateGroup(Group group)
        {
            _transferUnitOfWork.Groups.Add(
                _mapper.Map<Entities.Group>(group));
            _transferUnitOfWork.Save();
        }

        public (IList<Group> records, int total, int totalDisplay) GetGroups(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var groupData = _transferUnitOfWork.Groups.GetDynamic(
               string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
               sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from groups in groupData.data
                              select _mapper.Map<Group>(groups)).ToList();


            return (resultData, groupData.total, groupData.totalDisplay);
        }

    }
}
