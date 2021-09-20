using DataImporter.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.Entities
{
    public class ExcelData
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public DateTime UploadDate { get; set; }
        public string ExcelFileName { get; set; }
        public Group Group { get; set; }
        public List<ExcelFieldData> ExcelFieldDatas { get; set; }


    }
}
