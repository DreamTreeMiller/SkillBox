namespace Example_1323
{
    abstract class A
    {
        public int Property { get; set; } = 0;

        public string GetProperty()
        {
            return $"Property = {Property}";
        }
    }


    class B : A { }
    class C : A { }
    class D : B { }
    class E : C { }
    class F : E { }
}
