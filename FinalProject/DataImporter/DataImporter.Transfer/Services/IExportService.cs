﻿using DataImporter.ExcelFileReader;
using DataImporter.Transfer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.Services
{
    public interface IExportService
    {
        List<ExcelFieldData> GetTableData(int groupId);
    }
}
