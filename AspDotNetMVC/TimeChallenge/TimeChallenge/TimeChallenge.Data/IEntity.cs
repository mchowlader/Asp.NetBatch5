using System;

namespace TimeChallenge.Data
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
