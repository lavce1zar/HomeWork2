using System;
using System.Data;

namespace HomeWork2.SmartCalc
{
    internal class Program
    {
        static DataTable Table { get; } = new DataTable();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the smart calculator program!");

            PrintMenu();

            Console.WriteLine("Good bye! See you again next time!");
        }

        static void PrintMenu()
        {
            Console.WriteLine("Please, enter expression:");

            string? expression = Console.ReadLine();

            if(CheckAndAdjustString(ref expression))
            {
                try
                {
                    Console.WriteLine($"Result of expression = {Calc(expression)}");
                }
                catch(Exception)
                {
                    ProcessIncorrectInput();
                }
            }

            Console.WriteLine("Do you want to continue? Enter Y to continue:");
            var isContinue = Console.ReadLine()?.ToUpperInvariant() == "Y";
            Console.WriteLine();

            if (isContinue)
            {
                PrintMenu();
            }
        }

        static bool CheckAndAdjustString(ref string? str)
        {
            if (str == null || str == string.Empty)
            {
                ProcessIncorrectInput();
                return false;
            }

            foreach(char ch in str)
            {
                if (char.IsLetter(ch))
                {
                    ProcessIncorrectInput();
                    return false;
                }
            }

            str = str.Trim();
            str = str.Replace(" ", "");
            str = str.Replace("=", "");

            return true;
        }

        static double Calc(string? Expression)
        {
            var result = Convert.ToDouble(Table.Compute(Expression, string.Empty));
            return result;
        }

        static void ProcessIncorrectInput()
        {
            Console.WriteLine($"Incorrect input{Environment.NewLine}");
        }
    }
}