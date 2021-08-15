﻿using System;

namespace SchoolManagement.Data
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
