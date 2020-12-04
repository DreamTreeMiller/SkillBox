using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1121
{
    /// <summary>
    /// Герой
    /// </summary>
    class Hero
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Уровень
        /// </summary>
        public byte Level { get; set; }
        
        /// <summary>
        /// Запас здоровья
        /// </summary>
        public int HitPoint { get; set; }

        /// <summary>
        /// Создание героя
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Level">Уровень</param>
        /// <param name="HitPoint">Запас здоровья</param>
        public Hero(string Name, byte Level, int HitPoint)
        {
            this.Name = Name;
            this.Level = Level;
            this.HitPoint = HitPoint;
        }

        /// <summary>
        /// Метод, определяющий логику лечения
        /// </summary>
        public void Treatment() 
        { this.HitPoint += 10; }

        /// <summary>
        /// Метод, определяющий логику атаки
        /// </summary>
        public int Attack() { return 10; }

        /// <summary>
        /// Метод, определяющий логики в случае атаки другим героем
        /// </summary>
        public void Attacked(int Damage ) 
        { this.HitPoint -= Damage; }

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
