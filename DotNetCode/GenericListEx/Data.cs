using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListEx
{
    public class Data
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public G Gender { get; set; }

        public List<Data> Info = new List<Data>()
        {
            new Data{Name = "Anna",Id = 1,Gender = G.Female},
            new Data{Name = "Migaly", Id = 2, Gender = G.Male},
            new Data{Name = "Francisca", Id = 1, Gender = G.Third}
        };

        public List<Data> studentInfo = new List<Data>();

        public void x()
        {
            studentInfo.Add(new Data
            {
                Name = "Janos",
                Id = 1,
                Gender = G.Male
            });

            studentInfo.Add(new Data
            {
                Name = "Maria",
                Id = 2,
                Gender = G.Male
            });
        }

    }

  

}
