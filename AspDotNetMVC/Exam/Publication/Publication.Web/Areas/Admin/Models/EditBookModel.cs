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
    public class EditBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public EditBookModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
        }

        public EditBookModel(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        internal void LoadModelData(int id)
        {
            var book = _bookService.GetBooks(id);
            _mapper.Map(book, this);
        }

        internal void UpdateBook()
        {
            var book = _mapper.Map<Book>(this);
            _bookService.UpdateBook(book);
        }
        
    }
    
}
