//TODO: 1 Реализовать метод расширения для всех типов, реализующий ToString.
//Через рефлексию пройди по всем публичным полям и свойствам, с доступным геттером, вывести значения в формате:
//{"Property1Name": "Property1Value"...}
//2 Хочу чтобы автор типа, на котором будет вызываться  .ToString() мог контролировать порядок следования членов в строке,
//посредством указания порядка через атрибут.

using System.Reflection;
namespace Extensions
{
    
    public static class TypePropInfoExtension
    {
        public static void ToStringExtension<T>(this T obj)
        {
            var list1 = new SortedList<int, string>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                var attr = prop.GetCustomAttributes<StringOrderAttribute>().Select(x => x.Order).FirstOrDefault();
                list1.Add(attr, $"\"{prop.Name}\":\"{prop.GetValue(obj)}\"");
            }
            foreach (var i in list1)
                Console.WriteLine(i.Value);

        }
    }

}
