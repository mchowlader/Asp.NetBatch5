using AbastractFactory.Fighters;
using AbastractFactory.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastractFactory
{
    public interface IWeaponFactory
    {
        IMissile GetMissile();
        IMachineGun GetMachineGun();
        IFighter GetFighter();
    }
}
