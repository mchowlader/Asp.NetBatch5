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
    public class CreateAuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public CreateAuthorModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _authorService = Startup.AutofacContainer.Resolve<IAuthorService>();
        }

        public CreateAuthorModel(IMapper mapper, IAuthorService authorService)
        {
            _mapper = mapper;
            _authorService = authorService;
        }

        internal void CreateAuthor()
        {
            var author = _mapper.Map<Author>(this);
            _authorService.CreateAuthor(author);
        }

    }
}
