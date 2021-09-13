using Autofac;
using AutoMapper;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Transfer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Models
{
    public class HomeModel
    {
        public int Groups { get; set; }
        public int Imports { get; set; }
        public int Exports { get; set; }


        private readonly IMapper _mapper;
        private readonly IGroupService _groupService;

        public HomeModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
        }

        internal void CountHomeProperty()
        {
            var count = _groupService.CountHomeProperty();
            Groups = count.Groups;
        }


        public HomeModel(IMapper mapper, IGroupService groupService)
        {
            _mapper = mapper;
            _groupService = groupService;
        }
    }
}
