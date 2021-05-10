using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class SampleView
    {
        public string Name { get; set; }
        public string NewText { get; set; }

        public SampleView()
        {
            Name = "Hello";
            NewText = "This only for Privacy!!";
        }
    }
}
