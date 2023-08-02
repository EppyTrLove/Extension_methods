//TODO: 1 Реализовать метод расширения для всех типов, реализующий ToString.
//Через рефлексию пройди по всем публичным полям и свойствам, с доступным геттером, вывести значения в формате:
//{"Property1Name": "Property1Value"...}
//2 Хочу чтобы автор типа, на котором будет вызываться  .ToString() мог контролировать порядок следования членов в строке,
//посредством указания порядка через атрибут.

namespace Extensions
{

    public class Dog
    {
        public Dog(string name, string color)
        {
            Name = name;
            Color = color;
        }
        [StringOrder(1)]
        public string Name { get; set; }
        [StringOrder(2)]
        public string Color { get; set; }
        [StringOrder(3)]
        public int age { get; set; } = 21;
    }

}
