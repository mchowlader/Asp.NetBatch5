using AutoMapper;
using DataImporter.Common.Exceptions;
using DataImporter.Common.Utilities;
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
        private readonly IUserService _userService;
        private readonly ITransferUnitOfWork _transferUnitOfWork;


        public GroupService(IMapper mapper,ITransferUnitOfWork transferUnitOfWork,
            IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
            _transferUnitOfWork = transferUnitOfWork;
        }

        public Home CountHomeProperty(Guid id)
        {
            
            var groupCount = _transferUnitOfWork.Groups.GetCount(x => x.UserId == id);
            return new Home()
            {
                Groups = groupCount
            };
        }
        //done
        public void CreateGroup(Group group)
        {
            _transferUnitOfWork.Groups.Add(
                _mapper.Map<Entities.Group>(group));
            _transferUnitOfWork.Save();
        }

        public Group GetGroup(int id)
        {
            var groupEntity = _transferUnitOfWork.Groups.GetById(id);

            if (groupEntity == null) return null;
            
            return _mapper.Map<Group>(groupEntity);
        }

        //done
        public (IList<Group> records, int total, int totalDisplay) GetGroupsByUserId(int pageIndex, 
            int pageSize, string searchText, string sortText, Guid id)
        {
            var groupData = _transferUnitOfWork.Groups.GetDynamic(
               string.IsNullOrWhiteSpace(searchText) ? x => x.UserId == id : x => x.GroupName.Contains(searchText),
               sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from groups in groupData.data
                              select _mapper.Map<Group>(groups)).ToList();

            return (resultData, groupData.total, groupData.totalDisplay);
        }

        //done
        public void GroupDelete(int id)
        {
            _transferUnitOfWork.Groups.Remove(id);
            _transferUnitOfWork.Save();
        }
        //done
        public IList<Group> LoadGroupProperty(Guid id)
        {
            var groupsList = new List<Group>();
            //var groupEntity = _transferUnitOfWork.Groups.GetAll();
            var groupEntity = _transferUnitOfWork.Groups.GetAll();

             groupsList = (from groups in groupEntity
                              where groups.UserId == id
                              select _mapper.Map<Group>(groups)).ToList();

            //foreach (var group in groupEntity)
            //{
            //    var groupData = _mapper.Map<Group>(group);
            //    groupsList.Add(groupData);
            //}

            return groupsList;
        }

        public void UpdateGroup(Group group)
        {
            if (group == null)
                throw new InvalidOperationException("Group is missing");

            if (IsTitleAlreadyUsed(group.GroupName, group.Id))
                throw new DuplicateTitleException("Group title already used in other group.");

            var groupEntity = _transferUnitOfWork.Groups.GetById(group.Id);

            if (groupEntity != null)
            {
                _mapper.Map(group, groupEntity);
                _transferUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't find group");
        }

        private bool IsTitleAlreadyUsed(string title) =>
          _transferUnitOfWork.Groups.GetCount(x => x.GroupName == title) > 0;

        private bool IsTitleAlreadyUsed(string title, int id) =>
            _transferUnitOfWork.Groups.GetCount(x => x.GroupName == title && x.Id != id) > 0;
    }
}
