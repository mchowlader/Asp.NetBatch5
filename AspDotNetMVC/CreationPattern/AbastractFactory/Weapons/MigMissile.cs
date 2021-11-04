using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastractFactory.Weapons
{
    public class MigMissile : IMissile
    {
        public double DemagePower { get; set; }
        public double velocity { get; set; }
    }
}
