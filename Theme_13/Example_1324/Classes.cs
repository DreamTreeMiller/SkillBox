namespace Example_1324
{
    class A : IInterface1
    {
        public int Property1 { get; set; }
    }

    class B : IInterface2
    {
        public int Property2 { get; set; }
    }

    class C : IInterface3<string>
    {
        public string Property3 { get; set; }
    }

    class D : IInterface3<int>
    {
        public int Property3 { get; set; }
    }

    class E : IInterface1, IInterface2, IInterface3<string>
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
        public string Property3 { get; set; }
    }

}
