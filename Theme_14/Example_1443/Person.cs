using System;

namespace Example_1443
{
    class Person
    {
        public string Name { get; set; }

        //public event Action<string> CatFood;
        public delegate void CatFoodDelegate(string s);
        public event CatFoodDelegate CatFood;
        Cat cat;

        public Person(string Name, Cat PersonsCat)
        {
            this.Name           = Name;
            this.cat            = PersonsCat;
            this.cat.MewEvent  += 
                a => Console.WriteLine($"{a}\n{this.Name} пошёл кормить кота: {PersonsCat.Nickname}");
        }

        public void FeedTheCat()
        {
            Console.WriteLine($"{cat.Nickname}, кис, кис, кис кушать кодано! ");
            CatFood?.Invoke("Вкусняшка");
        }



    }
}
