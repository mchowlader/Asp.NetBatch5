using AutoMapper;
using DataImporter.Transfer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.Services
{
    public class ExportService : IExportService
    {
        private readonly IMapper _mapper;
        private readonly IExportService  _exportService;
        private readonly ITransferUnitOfWork _transferUnitOfWork;


        public ExportService(IMapper mapper, ITransferUnitOfWork transferUnitOfWork,
             IExportService exportService)
        {
            _mapper = mapper;
            _exportService = exportService;
            _transferUnitOfWork = transferUnitOfWork;
        }
    }
}
