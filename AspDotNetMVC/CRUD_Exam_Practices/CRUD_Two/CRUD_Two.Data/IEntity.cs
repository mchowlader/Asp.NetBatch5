using System;

namespace CRUD_Two.Data
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
