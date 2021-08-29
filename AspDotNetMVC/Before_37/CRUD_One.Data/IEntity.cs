using System;

namespace CRUD_One.Data
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
