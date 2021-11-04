using AbastractFactory.Fighters;
using AbastractFactory.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastractFactory
{
    public class F16WeaponFactory : IWeaponFactory
    {
        public IFighter GetFighter()
        {
            return new F16Fighter();
        }
        public IMachineGun GetMachineGun()
        {
            return new F16macineGun();
        }

        public IMissile GetMissile()
        {
            return new F16Missile();
        }
    }
}
