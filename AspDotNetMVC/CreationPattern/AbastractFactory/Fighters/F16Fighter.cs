using AbastractFactory.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastractFactory.Fighters
{
    public class F16Fighter : IFighter
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Speed { get; set; }
        public IMissile Missile { get; set; }
        public IMachineGun Gun { get; set; }
    }
}
