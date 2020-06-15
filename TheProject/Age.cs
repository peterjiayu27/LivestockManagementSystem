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
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                age(int.Parse(textBox1.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void age(int age)
        {
            label2.Text = "The ratio is: " + RatesAndPrices.ratioAge(age).ToString() + "/" + RatesAndPrices.countAll.ToString();
        }

    }
}
