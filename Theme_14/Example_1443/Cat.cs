using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1443
{
    /// <summary>
    /// Ходят слухи, что все любят котиков...
    /// </summary>
    //class Cat : IComparable
    class Cat : IComparable<Cat>
    {

        public event Action<string> MewEvent;

        public Person owner;

        public Person Owner
        {
            set
            {
                this.owner = value;
                this.owner.CatFood += s => this.ToEat(s);
            }
        }

        /// <summary>
        /// Создание экземпляра котика
        /// </summary>
        /// <param name="Nickname">Кличка</param>
        /// <param name="Breed">Порода</param>
        public Cat(string Nickname, string Breed, int Weight)
        {
            this.Nickname = Nickname;
            this.breed = Breed;
            this.weight = Weight;
        }

        /// <summary>
        /// Порода
        /// </summary>
        private string breed;

        /// <summary>
        /// Вес
        /// </summary>
        private int weight;

        /// <summary>
        /// Вес
        /// </summary>
        private int Weight { get { return this.weight; } }

        /// <summary>
        /// Свойство, описываюее кличку
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Свойство, описываюее породу
        /// </summary>
        public string Breed { get { return "Порода: " + this.breed; } }

        /// <summary>
        /// Метод, определеющий логику игры котика
        /// </summary>
        public void ToPlay() { Console.WriteLine($"{this.Nickname} играет..."); }

        /// <summary>
        /// Метод, определеющий логику сна котика
        /// </summary>
        public void ToSleep() { Console.WriteLine($"{this.Nickname} спит..."); }

        /// <summary>
        /// Метод, определеющий логику питания котика
        /// </summary>
        public void ToEat(string food) { Console.WriteLine($"{this.Nickname} кушает...{food}"); }

        /// <summary>
        /// Мяуканье котика
        /// </summary>
        public void ToMew()
        {
            Console.WriteLine($"Мяу!");
            MewEvent?.Invoke($"Котик {this.Nickname} издал \"Мяу\"");
        }

        public override string ToString()
        {
            return $"{Nickname,10} {breed,10} {Weight,3}";
        }

        //public int CompareTo(object obj)
        //{
        //    var other = (Cat)obj;
        //    if (this.weight > other.weight) return 1;
        //    else if (this.weight < other.weight) return -1;
        //    else return 0;
        //}

        public int CompareTo(Cat other)
        {
            if (this.weight > other.weight) return 1;
            else if (this.weight < other.weight) return -1;
            else return 0;
        }
    }
}
