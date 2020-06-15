using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TheProject
{
    class Connect
    {
        public static String conn_string = "";//Connection string
        public static String q = ""; //query string
        public static OleDbConnection conn = null;//Connection to database
        public static Dictionary<int, Livestock> allLivestock = new Dictionary<int, Livestock>();//Create a new dictionary for livestocks
        public static Dictionary<int, Livestock> allDogs = new Dictionary<int, Livestock>();//Create a new dictionary for dogs
        public static Dictionary<int, Cow> allCows = new Dictionary<int, Cow>();//Create a new dictionary for dogs

        //Data reader
        public static string getData(OleDbDataReader reader, string tableName)
        {
            string result = "";
            using (reader)
            {
                DataTable columnTable = Connect.conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName.ToString(), null });  //Get table data by table name

                //Read all data using the reader

                while (reader.Read())
                {
                    for (int i = 0; i < columnTable.Rows.Count; i++)
                    {
                        result += reader[i].ToString() + "\t";
                    }
                    result += "\r\n";
                }
                return result;
            }
        }

        //Retrieve all data
        public static void GetAllData()
        {
            //initialise all values in RatesAndPrices
            RatesAndPrices.goatMilkPrice = 0;
            RatesAndPrices.cowMilkPrice = 0;
            RatesAndPrices.sheepWoolPrice = 0;
            RatesAndPrices.waterPrice = 0;
            RatesAndPrices.govTax = 0;
            RatesAndPrices.jerseyTax = 0;
            RatesAndPrices.totalAmtMilk = 0;
            RatesAndPrices.countGoatsCows = 0;
            RatesAndPrices.countSheep = 0;
            RatesAndPrices.dogsCost = 0;
            RatesAndPrices.totalCost = 0;
            RatesAndPrices.countAll = 0;
            allLivestock.Clear();
            allDogs.Clear();
            Connect.allCows.Clear();
            DataTable allTables = Connect.conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });// Read all tables in the database

            foreach (DataRow tbls in allTables.Rows)
            {
                var tbName = tbls["TABLE_NAME"].ToString();//Retrieve table names

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + tbName + "]", Connect.conn); //Select all data from each table

                var resultGroup = getData(cmd.ExecuteReader(), tbls["TABLE_NAME"].ToString()).Split(new string[] { "\r\n" }, StringSplitOptions.None); //Split table names into rows

                foreach (var line in resultGroup)
                {
                    var lineobj = line.Split(new string[] { "\t" }, StringSplitOptions.None); //store data for each columns

                    if (lineobj.Length < 2) break;

                    //Retrieve data from different tables

                    //Add items to dictionaries using Dictionary.Add(Index, Object)

                    switch (tbName)
                    {
                        case "Commodity Prices":
                            //Put every price value from RatesAndPrices into the "Commodity Prices" table
                            RatesAndPrices.goatMilkPrice = double.Parse(lineobj[0]);
                            RatesAndPrices.cowMilkPrice = double.Parse(lineobj[1]);
                            RatesAndPrices.sheepWoolPrice = double.Parse(lineobj[2]);
                            RatesAndPrices.waterPrice = double.Parse(lineobj[3]);
                            RatesAndPrices.govTax = double.Parse(lineobj[4]);
                            RatesAndPrices.jerseyTax = double.Parse(lineobj[5]);
                            break;
                        case "Cows":
                            //add everything
                            //
                            allLivestock.Add(int.Parse(lineobj[0]), new Cow(int.Parse(lineobj[0]), double.Parse(lineobj[1]), double.Parse(lineobj[2]), int.Parse(lineobj[3]), int.Parse(lineobj[4]), lineobj[5], double.Parse(lineobj[6]), bool.Parse(lineobj[7])));
                            allCows.Add(int.Parse(lineobj[0]), new Cow(int.Parse(lineobj[0]), double.Parse(lineobj[1]), double.Parse(lineobj[2]), int.Parse(lineobj[3]), int.Parse(lineobj[4]), lineobj[5], double.Parse(lineobj[6]), bool.Parse(lineobj[7])));
                            RatesAndPrices.totalAmtMilk += double.Parse(lineobj[6]);
                            RatesAndPrices.countGoatsCows++;
                            RatesAndPrices.totalCost += double.Parse(lineobj[2]);
                            RatesAndPrices.countAll++;
                            break;
                        case "Dogs":
                            allLivestock.Add(int.Parse(lineobj[0]), new Dogs(int.Parse(lineobj[0]), double.Parse(lineobj[1]), double.Parse(lineobj[2]), double.Parse(lineobj[3]), int.Parse(lineobj[4]), lineobj[5]));
                            allDogs.Add(int.Parse(lineobj[0]), new Dogs(int.Parse(lineobj[0]), double.Parse(lineobj[1]), double.Parse(lineobj[2]), double.Parse(lineobj[3]), int.Parse(lineobj[4]), lineobj[5]));
                            RatesAndPrices.totalCost += double.Parse(lineobj[2]);
                            RatesAndPrices.dogsCost += double.Parse(lineobj[2]);
                            RatesAndPrices.countAll++;
                            break;
                        case "Sheep":
                            allLivestock.Add(int.Parse(lineobj[0]), new Sheep(int.Parse(lineobj[0]), double.Parse(lineobj[1]), double.Parse(lineobj[2]), double.Parse(lineobj[3]), int.Parse(lineobj[4]), lineobj[5], double.Parse(lineobj[6])));
                            RatesAndPrices.countSheep++;
                            RatesAndPrices.totalCost += double.Parse(lineobj[2]);
                            RatesAndPrices.countAll++;
                            break;
                        case "Goats":
                            allLivestock.Add(int.Parse(lineobj[0]), new Goat(int.Parse(lineobj[0]), double.Parse(lineobj[1]), double.Parse(lineobj[2]), double.Parse(lineobj[3]), int.Parse(lineobj[4]), lineobj[5], double.Parse(lineobj[6])));
                            RatesAndPrices.totalAmtMilk += double.Parse(lineobj[6]);
                            RatesAndPrices.countGoatsCows++;
                            RatesAndPrices.totalCost += double.Parse(lineobj[2]);
                            RatesAndPrices.countAll++;
                            break;
                    }
                }
            }

        }
    }

}
