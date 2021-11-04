using AbastractFactory.Fighters;
using AbastractFactory.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastractFactory
{
    public class MigWeaponFactory : IWeaponFactory
    {
        public IFighter GetFighter()
        {
            return new MigFighter();
        }

        public IMachineGun GetMachineGun()
        {
            return new MigMacineGun();
        }

        public IMissile GetMissile()
        {
            return new MigMissile();
        }
    }
}
