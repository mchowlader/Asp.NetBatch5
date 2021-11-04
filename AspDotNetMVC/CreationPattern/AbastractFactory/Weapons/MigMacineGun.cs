using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastractFactory.Weapons
{
    public class MigMacineGun : IMachineGun
    {
        public double DemagePower { get ; set; }
        public int ShortPerRound { get; set; }
    }
}
