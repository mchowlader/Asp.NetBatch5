using Autofac;
using AutoMapper;
using DataImporter.Common.Utilities;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Transfer.Services;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
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
        public string FilePath { get; set; }
        public string GroupName { get; set; }
        public string ExcelFileName { get; set; }
        public DateTime ImportDate { get; set; }
        public IList<string> lists { get; set; }
        public IList<Group> groupsList { get; set; }

        public List<TableData> ColumnList = new List<TableData>();



        private IMapper _mapper;
        private ILifetimeScope _scope;
        private IDateTimeUtility _dateTimeUtility;
        private IImportService _importService;
        private IColumnDataService _columnDataService;
        private IWebHostEnvironment _webHostEnvironment;

        public CreateImportModel()
        {

        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _mapper = _scope.Resolve<IMapper>();
            _importService = _scope.Resolve<IImportService>();
            _columnDataService = _scope.Resolve<IColumnDataService>();
            _dateTimeUtility = _scope.Resolve<IDateTimeUtility>();
            _webHostEnvironment = _scope.Resolve<IWebHostEnvironment>();
        }
        public CreateImportModel(IMapper mapper, IDateTimeUtility dateTimeUtility,
            IImportService importService, IColumnDataService  columnDataService,
            IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _columnDataService = columnDataService;
            _dateTimeUtility = dateTimeUtility;
            _importService = importService;
            _webHostEnvironment = webHostEnvironment;
        }


        public void CreateImportHistory(int id, string filePath, string excelFileName)
        {

            var importsData = new Import
            {
                GroupId = id,
                ImportDate = _dateTimeUtility.Now,
                ExcelFileName = excelFileName,
                FilePath = filePath,
                Status = "Pending"
            };
            _importService.UploadExcelFile(importsData);
        }

        public bool FileMatching(int groupId, string filePath)
        {
            List<string> columnList = new List<string>();

            columnList = _columnDataService.FileMatching(groupId);

            if (columnList != null)
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var excelReader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = excelReader.AsDataSet();

                        DataTable dataTable = result.Tables[0];

                        for (var i = 0; i < 1; i++)
                        {
                            var array = new string[dataTable.Columns.Count];

                            for (var j = 0; j < array.Length; j++)
                            {
                                array[j] = dataTable.Rows[i][j].ToString();
                            }
                            ColumnList.Add(new TableData { ColumnData = array });


                            for (var m = 0; m < columnList.Count; m++)
                            {
                                if (array.Length == columnList.Count && array[m] == columnList[m])
                                {
                                    continue;
                                }
                                else
                                    throw new InvalidProgramException("Excel Column Dose not Match");
                            }

                        }

                    }
                }

                return true;
            }

            else
                return false;

        }

        public void InsertTableHeader(int id, string filePath)
        {

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var excelReader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = excelReader.AsDataSet();

                    DataTable dataTable = result.Tables[0];


                    for (var i = 0; i < 1; i++)
                    {
                        var array = new string[dataTable.Columns.Count];

                        for (var j = 0; j < array.Length; j++)
                        {
                            array[j] = dataTable.Rows[i][j].ToString();

                        }
                        ColumnList.Add(new TableData { ColumnData = array });

                    }

                }
            }


            for (var m = 0; m < ColumnList[0].ColumnData.Count; m++)
            {
                var column = new ColumnData()
                {
                    GroupId = id,
                    ColumnName = ColumnList[0].ColumnData[m],
                    ColumnNumber = m
                };

                _columnDataService.InsertColumnHeader(column);

            }

        }
    }
}
