using AutoMapper;
using DataImporter.Transfer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.Services
{
    public class ExcelDataService : IExcelDataService
    {
        private readonly IMapper _mapper;
        private readonly IExcelDataService _excelDataService;
        private readonly ITransferUnitOfWork _transferUnitOfWork;


        public ExcelDataService(IMapper mapper, ITransferUnitOfWork transferUnitOfWork,
            IExcelDataService excelDataService)
        {
            _mapper = mapper;
            _excelDataService = excelDataService;
            _transferUnitOfWork = transferUnitOfWork;
        }
    }
}
