using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1131
{
    /// <summary>
    /// Герой
    /// </summary>
    class Druid
    {
        static uint defIndexName;
        static Random randomize;
        static List<string> dbNames;
        static Druid()
        {
            defIndexName = 1;
            randomize = new Random();
            dbNames = new List<string>();
        }

        byte level;
        uint hitPoint;
        uint maxHitPoint;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Уровень
        /// </summary>
        public byte Level { get { return this.level; } }
        
        /// <summary>
        /// Запас здоровья
        /// </summary>
        public uint HitPoint 
        { get 
            { return this.hitPoint; } }

        /// <summary>
        /// Создание героя
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Level">Уровень</param>
        /// <param name="HitPoint">Запас здоровья</param>
        public Druid(string Name, byte Level, uint HitPoint)
        {
            if(Name==String.Empty || Druid.dbNames.Contains(Name))
            {
                Name = $"{Guid.NewGuid().ToString().Substring(0,5)} #{Druid.defIndexName++}";
            }

            this.Name = Name;
            Druid.dbNames.Add(Name);
            this.level = Level;

            HitPoint = HitPoint != 0 ? HitPoint : (uint)Druid.randomize.Next(100, 400);
            this.hitPoint = HitPoint;
            this.maxHitPoint = HitPoint;
        }

        /// <summary>
        /// Создание героя с автопараметрами
        /// </summary>
        public Druid() : this("", 1, 0)
        {
        }

        /// <summary>
        /// Метод, определяющий логику лечения
        /// </summary>
        public void Treatment(uint Hp = 10)
        {
            Hp = (uint)(Hp * 1.5);
            if (this.hitPoint == 0) Console.WriteLine($"Лечение невозможно, {this.Name} в таверне");
            else { this.hitPoint = this.hitPoint + Hp <= this.maxHitPoint ? this.hitPoint + Hp : this.maxHitPoint; }
        }

        /// <summary>
        /// Лечение
        /// </summary>
        /// <returns></returns>
        public uint Heal()
        {
            return (uint)Druid.randomize.Next(5, 10);
        }

        /// <summary>
        /// Метод, определяющий логику атаки
        /// </summary>
        public uint Attack() { return 10; }

        /// <summary>
        /// Метод, определяющий логики в случае атаки другим героем
        /// </summary>
        public void Attacked(uint Damage)
        {
            if (this.hitPoint == 0)
            {
                this.Tavern();
            }
            else
            {
                if (this.hitPoint - Damage <= 0)
                {
                    this.hitPoint = 0;
                    this.Die();
                }
                else
                {
                    this.hitPoint -= Damage;
                }
            }
        }

        /// <summary>
        /// Логика отправки героя в таверну
        /// </summary>
        private void Die()
        {
            Console.WriteLine($"У {this.Name} Критический уровень запаса жизни");
            this.Tavern();
        }

        /// <summary>
        /// Информация о нахождении в таверне
        /// </summary>
        private void Tavern()
        {
            Console.WriteLine($"Герой {this.Name} в таверне");
        }

        /// <summary>
        /// Информация о герое
        /// </summary>
        /// <returns></returns>
        public string HeroInformation()
        {
            return String.Format("Name:{0,10} |  Level:{1,4} |  HitPoint:{2,6} |  Type:{3,12}",
                this.Name,
                this.Level,
                this.HitPoint,
                this.GetType().Name
                );
        }

    }
}
