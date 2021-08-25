using System;

namespace ExamTimeChallengeTwo.Data
{
    public interface IEntity<Tkey>
    {
        public int Id { get; set; }
    }
}
