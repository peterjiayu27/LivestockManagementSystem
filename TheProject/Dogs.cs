using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject
{
    class Dogs : Livestock
    {
        public Dogs(int id, double amtWater, double cost, double weight, int age, string color) : base(id, amtWater, cost, weight, age, color)
        {
            type = "Dog";
        }
        public override string print()
        {
            return "ID: " + this.id + "\r\nType:" + type + "\r\nAmount Of Water: " + this.amtWater + "\r\nCost: " + this.cost + "\r\nWeight:  " + this.weight + "\r\nAge: " + this.age + "\r\nColor: " + this.color;
        }
        public override double profit()
        {
            double wt = amtWater * RatesAndPrices.waterPrice;
            double ls = cost + tax() + wt;
            return ls;
        }
    }
}