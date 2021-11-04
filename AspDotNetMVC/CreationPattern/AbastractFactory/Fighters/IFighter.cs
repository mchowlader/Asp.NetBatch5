using AbastractFactory.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastractFactory.Fighters
{
    public interface IFighter
    {
        string Name { get; set; }
        string Image { get; set; }
        double Speed { get; set; }

        IMissile Missile { get; set; }
        IMachineGun Gun { get; set; }

    }
}
