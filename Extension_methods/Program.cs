//TODO: 1 Реализовать метод расширения для всех типов, реализующий ToString.
//Через рефлексию пройди по всем публичным полям и свойствам, с доступным геттером, вывести значения в формате:
//{"Property1Name": "Property1Value"...}
//2 Хочу чтобы автор типа, на котором будет вызываться  .ToString() мог контролировать порядок следования членов в строке,
//посредством указания порядка через атрибут.

using System.Reflection;
namespace Extensions
{

    public class Dog
    {
        public Dog(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public string Name { get; set; }
        public string Color { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    class PropertyValueFirstAttribute : Attribute { }


    [PropertyValueFirst]
    public static class TypePropInfoExtension
    {
        public static void ToStringExtension(this object obj)
        {
            var attrs = typeof(TypePropInfoExtension).GetCustomAttributes(false);
            foreach (var attr in attrs)
                if (attr.GetType().Name == "PropertyValueFirst")
                    foreach (var prop in obj.GetType().GetProperties(BindingFlags.Public))
                    {
                        if (prop.CanRead)
                            Console.WriteLine($"PropertyValue: {prop.GetValue(prop.Name)}; PropertyName: {prop.Name}");

                    }
                else
                    foreach (var prop in obj.GetType().GetProperties(BindingFlags.Public))
                    {
                        if (prop.CanRead)
                            Console.WriteLine($"PropertyName: {prop.Name}; PropertyValue: {prop.GetValue(prop.Name)}");
                    }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var doggy = new Dog("Sam", "White");
            doggy.ToStringExtension();

        }
    }

}
