using Autofac;
using AutoMapper;
using DataImporter.Common.Utilities;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Transfer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Models.Imports
{
    public class ImportModel
    {
        public int Id { get; set; }
        public string DateTo { get; set; }
        public string DateFrom { get; set; }

        private  IMapper _mapper;
        private  ILifetimeScope _scope;
        private  IDateTimeUtility _dateTimeUtility;
        private  IGroupService _groupService;

        public ImportModel()
        {
            
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _mapper = _scope.Resolve<IMapper>();
            _groupService = _scope.Resolve<IGroupService>();
            _dateTimeUtility = _scope.Resolve<IDateTimeUtility>();
        }

        public ImportModel(IMapper mapper, IDateTimeUtility dateTimeUtility,
            IGroupService groupService)
        {
            _mapper = mapper;
            _dateTimeUtility = dateTimeUtility;
            _groupService = groupService;
        }
        public IList<Group> groupsList { get; set; }

        public void LoadGroupProperty(Guid id)
        {
            groupsList = _groupService.LoadGroupProperty(id);
        }
    }
}
