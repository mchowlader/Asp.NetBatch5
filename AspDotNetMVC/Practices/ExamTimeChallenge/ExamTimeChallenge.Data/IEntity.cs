using System;

namespace ExamTimeChallenge.Data
{
    public interface IEntity<Tkey>

    {
        public Tkey Id { get; set; }
    }
}
