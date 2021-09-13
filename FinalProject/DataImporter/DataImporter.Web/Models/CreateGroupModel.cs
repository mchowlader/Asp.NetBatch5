using AutoMapper;
using DataImporter.Transfer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DataImporter.Transfer.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace DataImporter.Web.Models
{
    public class CreateGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DateTime { get; set; }

        private readonly IMapper _mapper;
        private readonly IGroupService  _groupService;

        public CreateGroupModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
        }

        public CreateGroupModel(IMapper mapper, IGroupService groupService)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        internal void CreateGroup()
        {
            var group = _mapper.Map<Group>(this);
            _groupService.CreateGroup(group);
        }
    }
}
