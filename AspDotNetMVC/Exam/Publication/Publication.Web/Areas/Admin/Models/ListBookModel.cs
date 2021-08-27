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
    public class ListBookModel
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public ListBookModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
        }

        public ListBookModel(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        internal object LoadModelData(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _bookService.GetBookData(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] { "Title", "Price", "Barcode" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                           record.Title,
                           record.Price.ToString(),
                           record.Barcode,
                           record.Id.ToString()
                        }).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _bookService.DeleteBook(id);
        }

    }
}
