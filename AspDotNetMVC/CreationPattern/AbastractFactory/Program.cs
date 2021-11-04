using AbastractFactory.Fighters;
using System;

namespace AbastractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Select Fighter: S");
            var fighterName = Console.ReadLine();
           

            var weaponFactory = GetWeaponFactory(fighterName);
             
            IFighter fighter = weaponFactory.GetFighter();
            fighter.Missile = weaponFactory.GetMissile();
            fighter.Gun = weaponFactory.GetMachineGun();
        }

        static IWeaponFactory GetWeaponFactory(string fighterName)
        {
            if (fighterName == "Mig")
            {

                return new MigWeaponFactory();
            }
            else
            {
                return new F16WeaponFactory();
            }
        }
    }
}
