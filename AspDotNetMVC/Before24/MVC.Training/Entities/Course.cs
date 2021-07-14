using MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Entities
{
    public class Course : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Fees { get; set; }
        public DateTime StartDate { get; set; }
    }
}
