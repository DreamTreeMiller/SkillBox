using System;

namespace Example_1311
{
    class Temporary<Template>
    {
        public Temporary(Template Value)
        {
            Property = Value;
        }

        public Template Property { get; set; }

        public void GetPropertyInformation()
        {
            Console.WriteLine($"type: {Property.GetType(),14} value:{Property,7}");
        }
    }
}
