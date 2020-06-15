using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject
{
    class Cow : Livestock
    {
        public double amtMilk;
        public bool isJersey;
        public Cow(int id, double amtWater, double cost, double weight, int age, string color, double amtMilk, bool isJersey) : base(id, amtWater, cost, weight, age, color)
        {
            this.amtMilk = amtMilk;
            this.isJersey = isJersey;
            type = "Cow";
        }
        public override string print()
        {
            return "ID: " + this.id + "\r\nType:" + type + "\r\nAmount Of Water: " + this.amtWater + "\r\nCost: " + this.cost + "\r\nWeight:  " + this.weight + "\r\nAge: " + this.age + "\r\nColor: " + this.color + "\r\nAmount of Milk: " + this.amtMilk + "\r\nIs Jersey: " + this.isJersey;
        }
        public override double tax()
        {
            double tax = 0;
            if (isJersey == true)
            {
                tax += RatesAndPrices.jerseyTax * weight;
            }
            tax = RatesAndPrices.govTax * weight;
            return tax;
        }
        public override double profit()
        {
            double pf = amtMilk * RatesAndPrices.cowMilkPrice;
            //double tax = 0;
            double wt = amtWater * RatesAndPrices.waterPrice;
            double ls = cost + tax() + wt;

            return pf - ls;
        }

    }
}
