using System;

namespace HomeWork2.SmartCalcWithPars
{
    internal class Program
    {
        static char[] Operators = {'+', '-', '*', '/'};

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

            if (CheckAndAdjustString(ref expression))
            {
                try
                {
                    Console.WriteLine($"Result of expression = {Calc(expression)}");
                }
                catch (Exception)
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

        static double Calc(string? str)
        {
            if (double.TryParse(str, out var number))
            {
                return number;
            }

            int countStartOfABracket = 0;
            int countEndOfABracket = 0;
            int startIndex = 0;

            for (int i = 0; i < str?.Length; i++)
            {
                if (str[i] == '(')
                {
                    countStartOfABracket++;
                    if (countStartOfABracket == 1)
                    {
                        startIndex = i;
                    }
                }

                if (str[i] == ')')
                {
                    countEndOfABracket++;
                }

                if (countStartOfABracket != 0 && (countStartOfABracket == countEndOfABracket))
                {
                    var bracketString = str[startIndex..(i + 1)];
                    double resultBracket = Calc(str[(startIndex + 1)..i]);
                    str = str.Replace(bracketString, resultBracket.ToString());
                    i = startIndex;
                    countStartOfABracket = 0;
                    countEndOfABracket = 0;
                }
            }

            List<double> numbers = new List<double>();
            List<char> operators = new List<char>();

            int startOfANumber = 0;

            for (int i = 1; i < str?.Length; i++)
            {
                if (Operators.Contains(str[i]))
                {
                    numbers.Add(Convert.ToDouble(str[startOfANumber..i]));
                    operators.Add(str[i]);
                    startOfANumber = i + 1;
                    i++;
                }
            }
            numbers.Add(Convert.ToDouble(str?[startOfANumber..]));

            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == '*' || operators[i] == '/')
                {
                    double temp = GetResultOfOperation(numbers[i], numbers[i + 1], operators[i]);
                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    numbers[i] = temp;
                    i--;
                }
            }

            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == '+' || operators[i] == '-')
                {
                    double temp = GetResultOfOperation(numbers[i], numbers[i + 1], operators[i]);
                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    numbers[i] = temp;
                    i--;
                }
            }

            return numbers[0];
        }

        static double GetResultOfOperation(double number1, double number2, char operation)
        {
            switch(operation)
            {
                case '+':
                    return number1 + number2;
                case '-':
                    return number1 - number2;
                case '*':
                    return number1 * number2;
                case '/':
                    return number1 / number2;
                default:
                    ProcessIncorrectInput();
                    return 0;
            }
        }

        static bool CheckAndAdjustString(ref string? str)
        {
            if (str == null || str == string.Empty)
            {
                ProcessIncorrectInput();
                return false;
            }

            foreach (char ch in str)
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

        static void ProcessIncorrectInput()
        {
            Console.WriteLine($"Incorrect input{Environment.NewLine}");
        }
    }
}