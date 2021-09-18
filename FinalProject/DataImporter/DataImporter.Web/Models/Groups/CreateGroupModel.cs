using AutoMapper;
using DataImporter.Transfer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DataImporter.Transfer.BusinessObjects;
using System.ComponentModel.DataAnnotations;
using DataImporter.Common.Utilities;

namespace DataImporter.Web.Models.Groups
{
    public class CreateGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime{ get; set; }
        
      
        private readonly IMapper _mapper;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IGroupService  _groupService;

        public CreateGroupModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _dateTimeUtility = Startup.AutofacContainer.Resolve<IDateTimeUtility>();
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
        }

        public CreateGroupModel(IMapper mapper, IDateTimeUtility dateTimeUtility, 
            IGroupService groupService)
        {
            _mapper = mapper;
            _dateTimeUtility = dateTimeUtility;
            _groupService = groupService;
        }

        internal void CreateGroup()
        {
            //var group = _mapper.Map<Group>(this);
            var group = new Group()
            {
                Name = Name,
                DateTime = _dateTimeUtility.Now
            };
            _groupService.CreateGroup(group);
        }
    }
}
