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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                runIDQuery(int.Parse(textBox1.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void runIDQuery(int id)
        {

            var result = Connect.allLivestock[id];
            richTextBox1.Text = result.print();


        }

    }
}
