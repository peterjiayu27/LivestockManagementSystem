using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject
{
    class Sheep : Livestock
    {
        public double amtWool;
        public Sheep(int id, double amtWater, double cost, double weight, int age, string color, double amtWool) : base(id, amtWater, cost, weight, age, color) // inherit id from LiveStock
        {
            this.amtWool = amtWool;
            type = "Sheep";
        }
        public override string print()
        {
            return "ID: " + this.id + "\r\nType:" + type + "\r\nCost: " + this.cost + "\r\nWeight:  " + this.weight + "\r\nAge: " + this.age + "\r\nColor: " + this.color + "\r\nAmount of Wool: " + this.amtWool;
        }
        public override double profit()
        {
            double pf = amtWool * RatesAndPrices.sheepWoolPrice;
            double tax = RatesAndPrices.govTax * weight;
            double wt = amtWater * RatesAndPrices.waterPrice;
            double ls = cost + tax + wt;
            return pf - ls;
        }
    }
}
