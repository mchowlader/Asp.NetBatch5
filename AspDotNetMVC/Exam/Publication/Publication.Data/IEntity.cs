using System;

namespace Publication.Data
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
