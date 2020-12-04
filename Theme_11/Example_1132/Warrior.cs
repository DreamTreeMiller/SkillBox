using System;

namespace Example_1132
{
    
    /// <summary>
    /// Герой "Warrior"
    /// </summary>
    class Warrior : Hero
    {

        public new void Motto() { Console.WriteLine($"{this.Name}: Мой молот готов служить всезнающему!"); }

        uint blockDamage;

        /// <summary>
        /// Создание героя
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Level">Уровень</param>
        /// <param name="HitPoint">Запас здоровья</param>
        public Warrior(string Name, byte Level, uint HitPoint) 
            : base(Name, Level,HitPoint)
        {
            this.blockDamage = 2;
        }

        /// <summary>
        /// Создание героя с автопараметрами
        /// </summary>
        public Warrior() : this("", 1, 0)
        {

        }

        public new void Attacked(uint Damage)
        {
            base.Attacked(Damage / blockDamage);
        }

    }
}
