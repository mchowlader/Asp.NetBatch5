using AutoMapper;
using Publication.Publisher.BusinessObjects;
using Publication.Publisher.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publication.Publisher.Services
{
    public class BookService : IBookService
    {
        private readonly IPublisherUnitOfWork _publisherUnitOfWork;
        private readonly IMapper _mapper;

        public BookService(IMapper mapper, IPublisherUnitOfWork publisherUnitOfWork)
        {
            _mapper = mapper;
            _publisherUnitOfWork = publisherUnitOfWork;
        }

        public void CreateBook(Book book)
        {
            _publisherUnitOfWork.Books.Add(
                _mapper.Map<Entities.Book>(book));

            _publisherUnitOfWork.Save();
        }

        public void DeleteBook(int id)
        {
            _publisherUnitOfWork.Books.Remove(id);
            _publisherUnitOfWork.Save();
        }

        public (IList<Book> records, int total, int totalDisplay) GetBookData(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var resultData = _publisherUnitOfWork.Books.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Title.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var resultBook = (from data in resultData.data
                                select _mapper.Map<Book>(data)).ToList();

            return (resultBook, resultData.total, resultData.totalDisplay);
        }

        public Book GetBooks(int id)
        {
            var books = _publisherUnitOfWork.Books.GetById(id);
            return _mapper.Map<Book>(books);
        }

        public void UpdateBook(Book book)
        {
            if (book == null)
                throw new InvalidOperationException();
            var bookEntity = _publisherUnitOfWork.Books.GetById(book.Id);

            if (bookEntity != null)
            {
                _mapper.Map(book, bookEntity);
                _publisherUnitOfWork.Save();
            }
        }
    }
}
