using Autofac;
using AutoMapper;
using DataImporter.Common.Utilities;
using DataImporter.Transfer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Models
{
    public class ListGroupModel
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public DateTime DateTime { get; set; }

        private readonly IMapper _mapper;
        private readonly IGroupService _groupService;

        public ListGroupModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
        }

        public ListGroupModel(IMapper mapper, IGroupService groupService)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        internal object GetGroups(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _groupService.GetGroups(
               dataTableModel.PageIndex,
               dataTableModel.PageSize,
               dataTableModel.SearchText,
               dataTableModel.GetSortText(new string[] { "Name", "DateTime" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.DateTime.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void GroupDelete(int id)
        {
            _groupService.GroupDelete(id);
        }
    }
}
