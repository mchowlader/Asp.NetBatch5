using Autofac;
using AutoMapper;
using Publication.Publisher.Services;
using Publication.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Web.Areas.Admin.Models
{
    public class ListAuthorModel
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public ListAuthorModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _authorService = Startup.AutofacContainer.Resolve<IAuthorService>();
        }

        public ListAuthorModel(IMapper mapper, IAuthorService authorService)
        {
            _mapper = mapper;
            _authorService = authorService;
        }

        internal object LoadModelData(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _authorService.GetAuthorData(
               dataTableModel.PageIndex,
               dataTableModel.PageSize,
               dataTableModel.SearchText,
               dataTableModel.GetSortText(new string[] { "Name", "DateOfBirth" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                           record.Name,
                           record.DateOfBirth.ToString(),
                           record.Id.ToString()
                        }).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _authorService.DeleteAuthor(id);
        }
    }
}
