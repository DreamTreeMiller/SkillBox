namespace Example_1324
{
    interface IInterface1 { int Property1 { get; set; } }

    interface IInterface2 { int Property2 { get; set; } }

    interface IInterface3<T> { T Property3 { get; set; } }
}