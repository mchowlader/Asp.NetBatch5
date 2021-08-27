using CRUD_Two.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Two.Training.Entities
{
    public class Teacher : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Designatioin { get; set; }
        public string Address { get; set; }
    }
}
