using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class DecoratorPattern
    {

        private interface IPizza
        {
            double Cost();
            string GetDescription();
        }

        private abstract class Pizza : IPizza
        {
            private string description;
            private double cost;
            public Pizza(string description, double cost)
            {
                this.description = description;
                this.cost = cost;
            }

            public string GetDescription()
            {
                return description;
            }

            public double Cost()
            {
                return cost;
            }
        }


        private class ThinCrustPizza : Pizza
        {
            public ThinCrustPizza(string description, double cost) : base(description, cost) { }
        }

        static void Main()
        {
            ThinCrustPizza thinCrustPizza = new ThinCrustPizza("thin crust pizza", 20.00);
            Console.WriteLine(thinCrustPizza.GetDescription());
            Console.ReadLine();
        }


    }
}
