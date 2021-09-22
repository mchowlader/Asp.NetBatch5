using Autofac;
using AutoMapper;
using DataImporter.Common.Utilities;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Transfer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Models
{
    public class ContactsModel
    {
        private IMapper _mapper;
        private ILifetimeScope _scope;
        private IDateTimeUtility _dateTimeUtility;
        private IGroupService _groupService;

        public ContactsModel()
        {
           
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _mapper = _scope.Resolve<IMapper>();
            _groupService = _scope.Resolve<IGroupService>();
            _dateTimeUtility = _scope.Resolve<IDateTimeUtility>();
        }
        public ContactsModel(IMapper mapper, IDateTimeUtility dateTimeUtility,
            IGroupService groupService)
        {
            _mapper = mapper;
            _dateTimeUtility = dateTimeUtility;
            _groupService = groupService;
        }
        public int Id { get; set; }
        public string Group { get; set; }
        public string DateTo { get; set; }
        public string DateFrom { get; set; }

        public IList<Group> groupsList { get; set; }

        public void LoadGroupProperty(Guid id)
        {
            groupsList = _groupService.LoadGroupProperty(id);
        }
    }
}
