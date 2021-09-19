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

        private readonly IMapper _mapper;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IGroupService _groupService;

        public ImportModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _dateTimeUtility = Startup.AutofacContainer.Resolve<IDateTimeUtility>();
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
        }

        public ImportModel(IMapper mapper, IDateTimeUtility dateTimeUtility,
            IGroupService groupService)
        {
            _mapper = mapper;
            _dateTimeUtility = dateTimeUtility;
            _groupService = groupService;
        }
        public IList<Group> groupsList { get; set; }

        public void LoadGroupProperty()
        {
            groupsList = _groupService.LoadGroupProperty();
        }
    }
}
