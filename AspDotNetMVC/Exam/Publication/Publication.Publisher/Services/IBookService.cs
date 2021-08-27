using Publication.Publisher.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publication.Publisher.Services
{
    public interface IBookService
    {
        void CreateBook(Book book);
        (IList<Book> records, int total, int totalDisplay) GetBookData(int pageIndex, int pageSize, 
            string searchText, string sortText);
        Book GetBooks(int id);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
