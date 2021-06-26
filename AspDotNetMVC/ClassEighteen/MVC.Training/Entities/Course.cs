using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public double Fees { get; set; }

        public DateTime StartDate { get; set; }

        public IList<Topic> Topic { get; set; }
    }
}
