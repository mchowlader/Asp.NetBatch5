using Autofac;
using AutoMapper;
using DataImporter.Transfer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Models.Groups
{
    public class EditGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DateTime { get; set; }

        private readonly IMapper _mapper;
        private readonly IGroupService _groupService;

        public EditGroupModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
        }

        public EditGroupModel(IMapper mapper, IGroupService groupService)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        internal void EditGroup(int id)
        {
            var group = _groupService.GetGroup(id);
            _mapper.Map(group,this);
        }
    }
}
