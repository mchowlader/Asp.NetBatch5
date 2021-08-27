using Publication.Publisher.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publication.Publisher.Services
{
    public interface IAuthorService
    {
        void CreateAuthor(Author author);
        (IList<Author> records, int total, int totalDisplay) GetAuthorData(int pageIndex, 
            int pageSize, string searchText, string sortText);
       
    }
}
