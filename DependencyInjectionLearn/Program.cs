using Ninject;
using Ninject.Modules;
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

    public class WeaponNinjectModule :NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWeapon>().To<Bazuka>();
        }
    }
    
    class Program
    {
        public static IKernel AppKernel;
        static void Main(string[] args)
        {
            AppKernel = new StandardKernel(new WeaponNinjectModule());

            var warrior = AppKernel.Get<Warrior>();

            warrior.Kill();

        }
    }
}
