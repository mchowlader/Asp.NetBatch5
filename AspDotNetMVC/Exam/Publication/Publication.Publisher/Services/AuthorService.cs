using AutoMapper;
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
    }
}
