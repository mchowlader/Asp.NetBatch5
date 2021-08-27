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
    public class AuthorService : IAuthorService
    {
        private readonly IPublisherUnitOfWork _publisherUnitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IMapper mapper, IPublisherUnitOfWork publisherUnitOfWork)
        {
            _mapper = mapper;
            _publisherUnitOfWork = publisherUnitOfWork;
        }

        public void CreateAuthor(Author author)
        {
            _publisherUnitOfWork.Authors.Add(
               _mapper.Map<Entities.Author>(author));

            _publisherUnitOfWork.Save();
        }

        public (IList<Author> records, int total, int totalDisplay) GetAuthorData(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var resultData = _publisherUnitOfWork.Authors.GetDynamic(
               string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
               sortText, string.Empty, pageIndex, pageSize);

            var resultAuthor = (from data in resultData.data
                              select _mapper.Map<Author>(data)).ToList();

            return (resultAuthor, resultData.total, resultData.totalDisplay);
        }
    }
}
