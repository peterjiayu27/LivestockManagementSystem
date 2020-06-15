using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheProject
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
//1. Reports as listed in Table 4 60 marks
//1 ID query: Done, 7 marks
//2 Display the total profitability/loose of the farm per day: Done, 5 marks
//3 Display the total tax paid to the government per month: Done, 5 marks
//4 Display the total amount of milk per day for goats and cows: Done, 5 marks
//5 Display the average age of all animal farms(dog excluded): Done, 4 marks
//6 Display the average profitability of “Goats and Cow” Vs. Sheep: Done, 5 marks
//7 Display the ratio of Dogs’ cost compared to the total cost: Done, 5 marks
//8 Generate the required text file: Done, 7 marks
//9 Display the ratio of livestock with the color red: Done, 4 marks
//10 Display the total tax paid for Jersey Cows: Done, 5 marks
//11 Age threshold ratio: Done, 4 marks
//12 Display the total profitability of all Jersey Cows: Done, 4 marks

//2. Demonstration of inheritance 2/2 marks
//3. Demonstration of polymorphism 3/3 marks
//4. Error handling 3/5 marks
//5. Comments and indentation 2 marks
//6. Short methods 1 mark
//7. Good object oriented practice 5 marks
//8. Efficient algorithms(use of hash table and sorting algorithm) 7 marks
//9. Appropriate number of classes 5 marks
//10. Evidence of testing all functions of the program: Show screenshots. Not Done
//11. Self-marking 2 marks
//Bonus. Multithreading: Not Done

//total 60 + 2 + 3 + 3 + 2 + 1 + 5 + 7 + 5 + 2 = 90 marks
