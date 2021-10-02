using Autofac;
using DataImporter.ExcelFileReader;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Transfer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Worker.Model
{
    public class ImportModel
    {
        private IImportService _importService;
        private IColumnDataService _columnDataService;
        private ILifetimeScope _scope;
        private HelperExcelDataRead _helperExcelDataRead;
        public ImportModel()
        {
            
        }
        public void Resolve(ILifetimeScope scope, IImportService importService, IColumnDataService columnDataService, 
            HelperExcelDataRead helperExcelDataRead)
        {
            _scope = scope;
            _columnDataService = columnDataService;
            _importService = _scope.Resolve<IImportService>();
            _helperExcelDataRead = _scope.Resolve<HelperExcelDataRead>();
        }

        public ImportModel(IImportService importService, IColumnDataService columnDataService, HelperExcelDataRead helperExcelDataRead)
        {
            _importService = importService;
            _columnDataService = columnDataService;
            _helperExcelDataRead = helperExcelDataRead;

        }

        List<Import> PendingItemList = new List<Import>();

        public void GetPendingItem()
        {
             PendingItemList = _importService.GetPendingItem();
        }




      








        public void DeleteFile()
        {

        }





        //public void ExcelValueUpload()
        //{
        //    string[] HeaderKey;
        //    string[] FieldValues;

        //    var path = @"D:\DevSkill\dotNet\Code\Asp.NetBatch5\FinalProject\DataImporter\DataImporter.Web\wwwroot\Uploads\FamilyDetails.xlsx";



        //   var columnList = _helperExcelDataRead.ReadExcelData(1, path);
               

        //        for (var i = 0; i < columnList[0].ColumnData.Count; i++)
        //        {
        //            FieldValues = new string[columnList[0].ColumnData.Count];
        //            HeaderKey = new string[columnList[0].ColumnData.Count];

        //            for (var j = 0; j < FieldValues.Length; j++)
        //            {
        //                if (i == 0)
        //                    HeaderKey[j] = columnList[0].ColumnData[i][j].ToString();
        //                else
        //                    FieldValues[j] = columnList[0].ColumnData[i][j].ToString();
        //            }

        //            IDictionary<string, string> ExcelDataRead = new Dictionary<string, string>();

        //            for (var j = 0; j < FieldValues.Length; j++)
        //            {
        //                ExcelDataRead.Add(HeaderKey[j], FieldValues[j]);
        //            }
        //        }
        //    }
        }
}
