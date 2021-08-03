using System;

namespace SocialNetwork.Data
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
