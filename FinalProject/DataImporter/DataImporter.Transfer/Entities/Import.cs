﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.Entities
{
    public class Import
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string ExcelFileName { get; set; }
        public DateTime ImportDate { get; set; }
        public Group Group { get; set; }
    }
}
