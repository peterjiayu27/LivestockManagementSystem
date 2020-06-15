using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TheProject
{
    //per year/per day/per month are all accepted
    public partial class Form4 : Form
    {   
        public Form4()
        {
            InitializeComponent();
        }
        
        //Generate report
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("Total profitability/loose: " + RatesAndPrices.totalProfit(Connect.allLivestock).ToString() + "\r\n");
            richTextBox1.AppendText("Total Tax paid to government: " + RatesAndPrices.totalTax(Connect.allLivestock).ToString() + "\r\n");
            richTextBox1.AppendText("Total amount of milk: " + RatesAndPrices.totalAmtMilk.ToString() + "\r\n");
            richTextBox1.AppendText("Average age excluded dogs: " + RatesAndPrices.avgAgeNoDogs().ToString() + "\r\n");
            richTextBox1.AppendText("Ratio of dog's cost compared to total cost : " + RatesAndPrices.ratioCalc().ToString() + "\r\n");
            richTextBox1.AppendText("Average profitability of \"Goats and Cow\" Vs. Sheep: " + RatesAndPrices.goatsAvgProfitVsCowSheep().ToString() + "\r\n");
            richTextBox1.AppendText("Ratio of livestock with the color red: " + RatesAndPrices.ratioRed().ToString() + "\r\n");
            RatesAndPrices.jerseyStuff(Connect.allCows, richTextBox1);
        }
    }
}
