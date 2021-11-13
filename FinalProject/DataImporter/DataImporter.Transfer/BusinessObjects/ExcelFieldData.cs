﻿using DataImporter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.BusinessObjects
{
    public class ExcelFieldData 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int ExcelDataId { get; set; }
        public IList<string> ColumnData { get; set; }


    }
}
