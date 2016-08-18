using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionLearn
{
    public interface IWeapon
    {
        void Kill();
    }
    public class Bazuka: IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("BIG Badabum");
        }
    }

    public class Sword : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Chuch-chuck");
        }
    }

    public class Warrior
    {
        readonly IWeapon Weapon;
        public Warrior(IWeapon weapon)
        {
            Weapon = weapon;
        }
        public void Kill()
        {
            Weapon.Kill();
        }
    }
    class Program
    {   
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior(new Sword());
            warrior.Kill();

        }
    }
}
