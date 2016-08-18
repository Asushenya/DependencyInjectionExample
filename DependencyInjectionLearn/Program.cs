using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject.Modules;
using Ninject;
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
            Console.WriteLine("Chuk-chuck");
        }
    }

    public class Warrior
    {
        readonly IWeapon Weapon;

        public Warrior(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void Kill()
        {
            Weapon.Kill();
        }
    }

    public class WeaponNinjectModule: NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWeapon>().To<Sword>();
        }
    }

    public class AnotherWarrior
    {
        [Inject]
        public IWeapon Weapon { get; set; }
        

        public void Kill()
        {
            Weapon.Kill();
        }
    }
    /// <summary>
    /// теперь Schedule
    /// </summary>
    /// 
    
    class Program
    {
       // public static Ninject.IKernel AppKernel;
        static void Main(string[] args)
        {
            Ninject.IKernel AppKernel = new StandardKernel(new WeaponNinjectModule());
            var warrior = AppKernel.Get<AnotherWarrior>();
            warrior.Kill();

        }
    }
}
