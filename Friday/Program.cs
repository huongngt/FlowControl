using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friday
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool DisplayMenu = true; 
            //while (DisplayMenu)
            //{
            //    DisplayMenu = MainMenu();
            //}

            MainMenu();
        }

        public static void MainMenu()
        {
            bool DisplayMenu = true;         
            while (DisplayMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the main menu:)");
                Console.WriteLine("Please enter your choice from 1 to 3:");
                Console.WriteLine("Enter 1 to print the price of cinema ticket");
                Console.WriteLine("Enter 2 to print a string ten times");
                Console.WriteLine("Enter 3 to find the third word in a string");
                Console.WriteLine("Enter 0 to exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        DisplayMenu = false;
                        break;
                    case "1":
                        CinemaTicket();
                        DisplayMenu = true;
                        break;
                    case "2":
                        PrintString();
                        DisplayMenu = true;
                        break;
                    case "3":
                        FindThirdWord();
                        DisplayMenu = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect choice");
                        Console.ReadLine();
                        DisplayMenu = true;
                        break;
                }
            }
        }

        private static void FindThirdWord()
        {
            Console.Clear();
            Console.WriteLine("This program will print out the third word in your inputed string");
            Console.Write("Please input your string with more than 3 words:");
            string input = Console.ReadLine();
            input = input.Trim();
            //split string to separate words, remove the empty words
            char[] delimiterChars = new char[] { ' ', ',', '.', ':', '\t', ';' };
            string[] array = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            while (array.Length < 3)
            {
                Console.WriteLine("Inputed string is less than 3 words. Please input again.");
                input = Console.ReadLine();
                array = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            }            
            Console.WriteLine("The third words: " + array[2]);
            Console.ReadLine();
        }

        private static void PrintString()
        {
            Console.Clear();
            Console.WriteLine("This program will print out your inputed string ten times");
            Console.Write("Please input your string:");
            string input = Console.ReadLine();
            string output = null;
            for (int i = 0; i < 10; i++)
            {
                output += (i + 1).ToString() + "." + input + ", ";
            }
            output = output.Substring(0, output.Length - 2);
            Console.WriteLine(output);
            Console.ReadLine();
        }

        private static void CinemaTicket()
        {
            Console.Clear();
            Console.WriteLine("This program will print out your cinema price");
            Console.Write("Number of person to buy:");
            uint n; // number of person in group
            int total = 0;
            string input;
            byte age; // age
            if (UInt32.TryParse(Console.ReadLine(), out n))
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Please input the age of person " + (i + 1).ToString() + ":");
                    input = Console.ReadLine();
                    if (!Byte.TryParse(input, out age))
                    {
                        Console.WriteLine("Invalid age, please try again");
                        i--;
                    }
                    else
                        total += Price(age);
                }
                Console.WriteLine("-----Total price--------");
                Console.WriteLine("{0:C}", total);
            }
            else
                Console.WriteLine("Incorrect number of persons");
            Console.ReadLine();

        }

        private static int Price(byte age)
        {
            int price = 0;
            if (age <= 2 || age > 100)
            {                
                Console.WriteLine("Free ticket");
                price = 0;
            }
            else if (age < 20)
            {
                Console.WriteLine("Kids deal: 80kr");
                price = 80;
            }
            else if (age > 64)
            {
                Console.WriteLine("Senior Citizen Discount: 90kr");
                price = 90;
            }
            else
            {
                Console.WriteLine("Standard price: 120kr");
                price = 120;
            }
            return price;
        }


    }
}
