using Autofac;
using AutoMapper;
using DataImporter.Common.Utilities;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Transfer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Models.Imports
{
    public class ListImportModel
    {
        public int Id { get; set; }
        public string DateTo { get; set; }
        public string DateFrom { get; set; }

        private IMapper _mapper;
        private ILifetimeScope _scope;
        private IDateTimeUtility _dateTimeUtility;
        private IImportService  _importService;

        public ListImportModel()
        {

        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _mapper = _scope.Resolve<IMapper>();
            _importService = _scope.Resolve<IImportService>();
            _dateTimeUtility = _scope.Resolve<IDateTimeUtility>();
        }
        public ListImportModel(IMapper mapper, IDateTimeUtility dateTimeUtility,
            IImportService importService)
        {
            _mapper = mapper;
            _dateTimeUtility = dateTimeUtility;
            _importService = importService;
        }
        //public IList<Group> groupsList { get; set; }
        //internal void LoadGroupProperty(Guid id)
        //{
        //    groupsList = _importService.LoadGroupProperty(id);
        //}



        public object GetImportsData(DataTablesAjaxRequestModel importDataTable, Guid id)
        {
            var data = _importService.GetImportsData(
               importDataTable.PageIndex,
               importDataTable.PageSize,
               importDataTable.SearchText,
               importDataTable.GetSortText(new string[] { "GroupName", "ExcelFileName", "ImportDate" }),id);

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.GroupName,
                                record.ExcelFileName,
                                record.ImportDate.ToString(),
                        }
                    ).ToArray()
            };
        }
    }
}
