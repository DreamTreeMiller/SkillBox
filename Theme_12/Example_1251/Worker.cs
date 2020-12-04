namespace Example_1251
{
    public class Worker
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartamentId { get; private set; }
        public int DepartamentName
        {
            get
            {
                // .....
            }
        }

        public Worker(string Name, int age, int DepId)
        {
            this.Name = Name;
            Age = age;
            this.DepartamentId = DepId;
        }

        //public override string ToString()
        //{
        //    return $"{Name,7} {Age,3} {DepartamentId,3}";
        //}
    }
}
