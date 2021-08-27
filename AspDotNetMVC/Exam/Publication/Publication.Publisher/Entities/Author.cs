﻿using Publication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publication.Publisher.Entities
{
    public class Author : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<BookAuthor> WrittenBooks { get; set; }

    }
}
