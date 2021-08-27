using CRUD_One.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_One.Training.Entities
{
    public class Course : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Fees { get; set; }
        public DateTime StartDate { get; set; }
    }
}
