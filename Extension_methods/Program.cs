﻿//TODO: 1 Реализовать метод расширения для всех типов, реализующий ToString.
//Через рефлексию пройди по всем публичным полям и свойствам, с доступным геттером, вывести значения в формате:
//{"Property1Name": "Property1Value"...}
//2 Хочу чтобы автор типа, на котором будет вызываться  .ToString() мог контролировать порядок следования членов в строке,
//посредством указания порядка через атрибут.

namespace Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            var doggy = new Dog("Sam", "White");
            doggy.ToStringExtension(); 

        }
    }

}
