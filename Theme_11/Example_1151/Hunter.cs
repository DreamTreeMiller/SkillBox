using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1151
{
    /// <summary>
    /// Герой "Hunter"
    /// </summary>
    class Hunter : Hero
    {
        /// <summary>
        /// Девиз
        /// </summary>
        public override void Motto() { Console.WriteLine($"{this.Name}: Охота началась!"); }


        /// <summary>
        /// Создание героя
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Level">Уровень</param>
        /// <param name="HitPoint">Запас здоровья</param>
        public Hunter(string Name, byte Level, uint HitPoint)
              : base(Name, Level, HitPoint)
        {
            
        }

        /// <summary>
        /// Создание героя с автопараметрами
        /// </summary>
        public Hunter() : this("", 1, 0)
        {
        }

        /// <summary>
        /// Бонусный выстрел
        /// </summary>
        public uint HeadShot()
        {
            return (Hunter.randomize.Next(4) != 0) ?
                        this.Attack() :
                        this.Attack() + (uint)Hunter.randomize.Next(10, 20);
        }
    }
}
