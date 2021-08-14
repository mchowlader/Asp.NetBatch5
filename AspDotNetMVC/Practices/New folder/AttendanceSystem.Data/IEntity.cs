using System;

namespace AttendanceSystem.Data
{
    public interface IEntity<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
