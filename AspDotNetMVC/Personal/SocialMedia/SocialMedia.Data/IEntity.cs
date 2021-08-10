﻿using System;

namespace SocialMedia.Data
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
