using Autofac;
using AutoMapper;
using Publication.Publisher.BusinessObjects;
using Publication.Publisher.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Web.Areas.Admin.Models
{
    public class CreateBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public CreateBookModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
        }

        public CreateBookModel(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        internal void CreateBook()
        {
            var book = _mapper.Map<Book>(this);
            _bookService.CreateBook(book);
        }
    }
}
