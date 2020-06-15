using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheProject
{
    class RatesAndPrices
    {
        //government tax per kilogram per year
        //should be 1 or 2 cents
        //if it is too high, then every profitability could be negative
        public static int countAll = 0;//count all animals
        public static double goatMilkPrice = 0;//set milk price for goat
        public static double cowMilkPrice = 0;//set milk price for cow
        public static double sheepWoolPrice = 0;//set wool price for sheep
        public static double waterPrice = 0;//set water price
        public static double govTax = 0;//per kg per year
        public static double jerseyTax = 0;//(additional tax) per Jersey Cow
        public static double totalAmtMilk = 0;//count total amount of milk
        public static int countGoatsCows = 0;//to calculate goats and cows
        public static int countSheep = 0;//count sheep quantity
        public static int countdogs = 0;//coutn dogs quantity
        public static double totalCost = 0;//count total cost
        public static double dogsCost = 0;//count dogs cost

        //Calculate total profit of a type of animal
        public static double profitType(string t)
        {
            var total = 0.0; //total profit
            foreach (KeyValuePair<int, Livestock> a in Connect.allLivestock)
            {
                if (a.Value.type == t)
                {
                    total += a.Value.profit();
                }
            }
            return total;
        }

        //Count the quantity of a type of an animal
        public static int countType(string t)
        {
            var count = 0;
            foreach (KeyValuePair<int, Livestock> a in Connect.allLivestock)
            {
                if (a.Value.type == t)
                {
                    count++;
                }
            }
            return count;
        }

        //Calculate the total profit
        public static double totalProfit(Dictionary<int, Livestock> a)
        {
            var p = 0.0;
            foreach (KeyValuePair<int, Livestock> ls in a)

            {
                p += ls.Value.profit();
            }
            return p;
        }
        
        //Calculate total tax
        public static double totalTax(Dictionary<int, Livestock> a)
        {
            var t = 0.0;
            foreach (KeyValuePair<int, Livestock> ls in a)

            {
                t += ls.Value.tax();
            }
            return t;
        }
        //calculate the average age without dogs
        public static double avgAgeNoDogs()
        {
            var tAge = 0.0;
            var count = 0.0;
            var avg = 0.0;
            foreach (KeyValuePair<int, Livestock> a in Connect.allLivestock)
            {
                if (a.Value.type != "Dog")
                {
                    tAge += a.Value.age;
                    count++;
                }
            }
            avg = tAge / count;
            return avg;
        }
        //calculate the ratio of dog's cost
        public static double ratioCalc()
        {
            var r1 = 0.0;
            var r2 = 0.0;
            r1 = totalCost + totalTax(Connect.allLivestock);
            r2 = dogsCost + totalTax(Connect.allDogs);
            return r2 / r1;
        }
        //Calculate the goats's average profit VS. cows and sheep
        public static double goatsAvgProfitVsCowSheep()
        {
            double totalGC = profitType("Goat") + profitType("Cow");
            double totalS = profitType("Sheep");
            int countGC = countType("Goat") + countType("Cow");
            int countS = countType("Sheep");
            double avgGC = totalGC / countGC;
            double avgS = totalS / countS;
            double average = avgGC / avgS;
            return average;
        }
        //calculate the ratio of red animals
        public static double ratioRed()
        {
            var countAll = 0.0;
            var countRed = 0.0;
            foreach (KeyValuePair<int, Livestock> a in Connect.allLivestock)
            {
                if (a.Value.color == "red" || a.Value.color == "Red")
                {
                    countRed++;
                    countAll++;
                }
                else
                {
                    countAll++;
                }
            }
            return countRed / countAll;
        }

        //Calculate ratio by age
        public static int ratioAge(int age)
        {
            int count = 0;

            foreach (KeyValuePair<int, Livestock> a in Connect.allLivestock)
            {

                if (a.Value.age > age)
                {
                    count++;
                }
            }
            return count;
        }
        //sort the animals by profit
        public static List<Livestock> SortByProfit(bool reverse = true)
        {
            var idList = new List<Livestock>();

            foreach (var a in Connect.allLivestock.Values)
            {
                if(a.type == "Dog")
                {
                    continue;
                }

                if (idList.Count == 0)
                {
                    idList.Add(a);
                    continue;
                }

                var indexKey = 0;

                for(int i = 0; i < idList.Count; i++)
                {
                    if(a.profit() > idList[i].profit())
                    {
                        indexKey = i + 1;
                    }
                }
                idList.Insert(indexKey, a);
            }
            if (reverse) idList.Reverse();
            return idList;
        }
        //Calculate Jersey profit and Jersey tax
        public static void jerseyStuff(Dictionary<int, Cow> c, RichTextBox r)
        {
            Dictionary<int, Livestock> Jersey = new Dictionary<int, Livestock>();
            foreach(Cow cow in c.Values)
            {
                if(cow.isJersey == true)
                {
                    Jersey.Add(cow.id, cow);
                }
            }
            double jProfit = totalProfit(Jersey);
            double jTax = totalTax(Jersey);
            r.AppendText("Total profit for Jersey Cow: " + jProfit.ToString() + "\r\nTotal tax paid by Jersey Cow: " + jTax.ToString());
        }
    }

}





