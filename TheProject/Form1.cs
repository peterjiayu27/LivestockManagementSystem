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
using System.IO;

namespace TheProject
{
    //per year/per day/per month are all accepted
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }

        //Connect to database
        private void openDatabaseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.ShowDialog();
                Connect.conn_string = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + open.FileName + ";Persist Security Info=False;";
                Connect.conn = new OleDbConnection(Connect.conn_string);
                Connect.conn.Open();
                disconnectToolStripMenuItem.Enabled = true;
                openDatabaseFileToolStripMenuItem.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                label1.Text = "Database connected!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Disconnect
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Connect.conn.Close();
                disconnectToolStripMenuItem.Enabled = false;
                openDatabaseFileToolStripMenuItem.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                label1.Text = "Database disconnected! Thank you for using!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Open ID query form
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
            
        }

        //Disconnect to database when press the close button
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnectToolStripMenuItem.PerformClick();
        }

        //Open report generator
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.Show();
        }

        //Retrieve All data
        private void button4_Click(object sender, EventArgs e)
        {
            try {
                Connect.GetAllData();
                MessageBox.Show("Data retrieved!");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Generate the text file
        private void button2_Click(object sender, EventArgs e)
        {
            var ids = RatesAndPrices.SortByProfit();
            StreamWriter File = new StreamWriter("File.txt", false);
            
            foreach (var obj in ids)
            {
                File.WriteLine(obj.id);
            }
            File.Close();
            MessageBox.Show("File Generated!");
        }
        //Open the age ratio form
        private void button5_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
        }
    }
}
