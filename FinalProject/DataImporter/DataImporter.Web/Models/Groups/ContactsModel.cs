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
        private readonly IMapper _mapper;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IGroupService _groupService;

        public ContactsModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _dateTimeUtility = Startup.AutofacContainer.Resolve<IDateTimeUtility>();
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
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

        public void LoadGroupProperty()
        {
            groupsList = _groupService.LoadGroupProperty();
        }
    }
}
