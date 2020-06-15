using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject
{
    class Goat : Livestock
    {
        public double amtMilk;
        public Goat(int id, double amtWater, double cost, double weight, int age, string color, double amtMilk) : base(id, amtWater, cost, weight, age, color) // inherit id from LiveStock
        {
            this.amtMilk = amtMilk;
            type = "Goat";
        }
        public override string print()
        {
            return "ID: " + this.id + "\r\nType:" + type + "\r\nCost: " + this.cost + "\r\nWeight:  " + this.weight + "\r\nAge: " + this.age + "\r\nColor: " + this.color + "\r\nAmount of Milk: " + this.amtMilk;
        }
        public override double profit()
        {
            double pf = amtMilk * RatesAndPrices.goatMilkPrice;
            //double tax = RatesAndPrices.govTax * weight;
            double wt = amtWater * RatesAndPrices.waterPrice;
            double ls = cost + tax();
            return pf - ls;
        }
    }
}
