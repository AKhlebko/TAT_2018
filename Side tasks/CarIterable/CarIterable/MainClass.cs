using System;                 

namespace CarIterable
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[]
            {
            new Car("A", "BMW"),
            new Car("A", "BMW"),
            new Car("A", "BMW"),
            new Car("D", "BMW"),
            new Car("E", "BMW")
            };

            AutoHouse house = new AutoHouse("company", cars);
            foreach (var car in house)
            {
                Console.WriteLine(car);
            }
        }
    } 
}
