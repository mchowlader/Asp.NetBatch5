using Autofac;
using AutoMapper;
using DataImporter.Common.Utilities;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Transfer.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Models.Imports
{
    public class CreateImportModel
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string DateTo { get; set; }
        public string DateFrom { get; set; }
        public IFormFile XlsFile { get; set; }
        public string FilePath { get; set; }
        public string GroupName { get; set; }
        public string ExcelFileName { get; set; }
        public DateTime ImportDate { get; set; }
        public IList<string> lists { get; set; }
        public IList<Group> groupsList { get; set; }


        private IMapper _mapper;
        private ILifetimeScope _scope;
        private IDateTimeUtility _dateTimeUtility;
        private IImportService _importService;
        private IGroupService _groupService;
        private IWebHostEnvironment _webHostEnvironment;
        private UploadModel  _Upload;

        public CreateImportModel()
        {

        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _groupService = _scope.Resolve<IGroupService>();
            _mapper = _scope.Resolve<IMapper>();
            _importService = _scope.Resolve<IImportService>();
            _dateTimeUtility = _scope.Resolve<IDateTimeUtility>();
            _webHostEnvironment = _scope.Resolve<IWebHostEnvironment>();
        }
        public CreateImportModel(IMapper mapper, IDateTimeUtility dateTimeUtility,
            IImportService importService, IGroupService groupService,
            IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _groupService = groupService;
            _dateTimeUtility = dateTimeUtility;
            _importService = importService;
            _webHostEnvironment = webHostEnvironment;
        }


        //public void CreateImportHistory(int groupId)
        //{
        //    var directoryPathInfo = _Upload.DirectoryPath(xlsFile);

        //    var importsData = new Import()
        //    {
        //        GroupId = GroupId,
        //        ImportDate = _dateTimeUtility.Now,
        //        ExcelFileName = directoryPathInfo.excelFileName,
        //        FilePath = directoryPathInfo.filePath,
        //    };
        //    _importService.UploadExcelFile(importsData);
        //}
    }
}
