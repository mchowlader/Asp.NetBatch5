using ExamTimeChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Training.Entities
{
    public class Course : IEntity<int>
    {
        public int Id { get; set; }
        public int Fees { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
    }
}
