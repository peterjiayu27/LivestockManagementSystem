using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject
{
    class Livestock
    {
        //Declare variables
        public int id;
        public double amtWater;
        public double cost;
        public double weight;
        public int age;
        public string type;
        public string color;

        //Constructor for Livestock
        public Livestock(int id, double amtWater, double cost, double weight, int age, string color)
        {
            this.id = id;
            this.amtWater = amtWater;
            this.cost = cost;
            this.weight = weight;
            this.age = age;
            this.color = color;
            type = "";
        }

        //Print information
        public virtual string print()
        {
            return "ID: " + this.id + "\r\nType:" + type + "\r\nCost: " + this.cost + "\r\nWeight:  " + this.weight + "\r\nAge: " + this.age + "\r\nColor: " + this.color;
        }
        //Profit calculator(virtual)
        public virtual double profit()
        {
            return 0;
        }
        //Tax calculator(virtual)
        public virtual double tax()
        {
            double t = 0;
            return t + RatesAndPrices.govTax * weight;
        }
    }
}
