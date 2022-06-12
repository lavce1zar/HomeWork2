using System;

namespace HomeWork2.Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator program!");
            var isDemostration = CheckDemonstrationCase();
            Console.WriteLine();

            if (isDemostration)
            {
                Demonstration();

                Console.WriteLine("Do you want to continue? Enter Y to continue:");
                var isContinue = Console.ReadLine()?.ToUpperInvariant() == "Y";
                Console.WriteLine();

                if (isContinue)
                {
                    PrintMenu();
                }
            }
            else
            {
                PrintMenu();
            }

            Console.WriteLine("Good bye! See you again next time!");
        }

        static void PrintMenu()
        {
            Console.WriteLine("Select option:");
            Console.WriteLine("1. Addition (X + Y)");
            Console.WriteLine("2. Subtraction (X - Y)");
            Console.WriteLine("3. Multiplication (X * Y)");
            Console.WriteLine("4. Division (X / Y)");
            Console.WriteLine("5. Exponentiation (X ^ Y)");
            Console.WriteLine("6. Factorial (X!)");
            Console.WriteLine("7. Exit program");

            var selectedOption = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(selectedOption, out int option))
            {
                switch (option)
                {
                    case 1:
                        AdditionCase();
                        break;
                    case 2:
                        SubtractionCase();
                        break;
                    case 3:
                        MultiplicationCase();
                        break;
                    case 4:
                        DivisionCase();
                        break;
                    case 5:
                        ExponentiationCase();
                        break;
                    case 6:
                        FacrotialCase();
                        break;
                    case 7:
                        return;
                    default:
                        ProcessIncorrectInput();
                        break;
                }
            }
            else
            {
                ProcessIncorrectInput();
            }

            Console.WriteLine("Do you want to continue? Enter Y to continue:");
            var isContinue = Console.ReadLine()?.ToUpperInvariant() == "Y";
            Console.WriteLine();

            if (isContinue)
            {
                PrintMenu();
            }
        }

        static void Demonstration()
        {
            Console.WriteLine($"Starting demonstration mode.{Environment.NewLine}");
            AdditionCase(true);
            SubtractionCase(true);
            MultiplicationCase(true);
            DivisionCase(true);
            ExponentiationCase(true);
            FacrotialCase(true);
            Console.WriteLine($"End of demonstration.{Environment.NewLine}");
        }

        static void AdditionCase(bool isDemonstration = false)
        {
            Console.WriteLine("Addition:");

            if (isDemonstration)
            {
                var number1 = GetRandomDoubleValue();
                var number2 = GetRandomDoubleValue();
                Console.WriteLine($"{number1:F3} + {number2:F3} = {GetAddition(number1, number2):F3}{Environment.NewLine}");
            }
            else
            {
                if (GetTwoDoubleNumbersFromUser(out double number1, out double number2))
                {
                    Console.WriteLine($"{number1} + {number2} = {GetAddition(number1, number2)}{Environment.NewLine}");
                }
                else
                {
                    ProcessIncorrectInput();
                }
            }
        }

        static double GetAddition(double number1, double number2)
        {
            var result = number1 + number2;
            if (double.IsInfinity(result))
            {
                Console.WriteLine("Result is Positive Infinity.");
            }
            return result;
        }

        static void SubtractionCase(bool isDemonstration = false)
        {
            Console.WriteLine("Subtraction:");

            if (isDemonstration)
            {
                var number1 = GetRandomDoubleValue();
                var number2 = GetRandomDoubleValue();
                Console.WriteLine($"{number1:F3} - {number2:F3} = {GetSubtraction(number1, number2):F3}{Environment.NewLine}");
            }
            else
            {
                if (GetTwoDoubleNumbersFromUser(out double number1, out double number2))
                {
                    Console.WriteLine($"{number1} - {number2} = {GetSubtraction(number1, number2)}{Environment.NewLine}");
                }
                else
                {
                    ProcessIncorrectInput();
                }
            }
        }

        static double GetSubtraction(double number1, double number2)
        {
            var result = number1 - number2;
            if (double.IsInfinity(result))
            {
                Console.WriteLine("Result is Negative Infinity.");
            }
            return result;
        }

        static void MultiplicationCase(bool isDemonstration = false)
        {
            Console.WriteLine("Multiplication:");

            if (isDemonstration)
            {
                var number1 = GetRandomDoubleValue();
                var number2 = GetRandomDoubleValue();
                Console.WriteLine($"{number1:F3} * {number2:F3} = {GetMultiplication(number1, number2):F3}{Environment.NewLine}");
            }
            else
            {
                if (GetTwoDoubleNumbersFromUser(out double number1, out double number2))
                {
                    Console.WriteLine($"{number1} * {number2} = {GetMultiplication(number1, number2)}{Environment.NewLine}");
                }
                else
                {
                    ProcessIncorrectInput();
                }
            }
        }

        static double GetMultiplication(double number1, double number2)
        {
            var result = number1 * number2;
            if (double.IsInfinity(result))
            {
                Console.WriteLine("Result is Positive Infinity.");
            }
            return result;
        }

        static void DivisionCase(bool isDemonstration = false)
        {
            Console.WriteLine("Division:");

            if (isDemonstration)
            {
                var number1 = GetRandomDoubleValue();
                var number2 = GetRandomDoubleValue();
                Console.WriteLine($"{number1:F3} / {number2:F3} = {GetDivision(number1, number2):F3}{Environment.NewLine}");
            }
            else
            {
                if (GetTwoDoubleNumbersFromUser(out double number1, out double number2))
                {
                    Console.WriteLine($"{number1} / {number2} = {GetDivision(number1, number2)}{Environment.NewLine}");
                }
                else
                {
                    ProcessIncorrectInput();
                }
            }
        }

        static double GetDivision(double number1, double number2)
        {
            if (number2 == 0)
            {
                Console.WriteLine("Error. Division by zero.");
                if (number1 == 0)
                {
                    Console.WriteLine("Result is NaN.");
                    return double.NaN;
                }
                else if (number1 < 0)
                {
                    Console.WriteLine("Result is Negative Infinity.");
                    return double.NegativeInfinity;
                }
                else
                {
                    Console.WriteLine("Result is Positive Infinity.");
                    return double.PositiveInfinity;
                }
            }
            else
            {
                return number1 / number2;
            }
        }

        static void ExponentiationCase(bool isDemonstration = false)
        {
            Console.WriteLine("Exponentiation:");

            if (isDemonstration)
            {
                var number1 = GetRandomPositiveIntValue();
                var number2 = GetRandomPositiveIntValue();
                Console.WriteLine($"{number1} ^ {number2} = {GetExponentiation(number1, number2):#.### E+0}{Environment.NewLine}");
            }
            else
            {
                if (GetTwoPositiveIntNumbersFromUser(out uint number1, out uint number2))
                {
                    Console.WriteLine($"{number1} ^ {number2} = {GetExponentiation(number1, number2)}{Environment.NewLine}");
                }
                else
                {
                    ProcessIncorrectInput();
                }
            }
        }

        static double GetExponentiation(uint number, uint exponent)
        {
            var result = Math.Pow(number, exponent);
            if (double.IsInfinity(result))
            {
                Console.WriteLine("Result is Positive Infinity.");
            }
            return result;
        }

        static void FacrotialCase(bool isDemonstration = false)
        {
            Console.WriteLine("Factorial");

            if (isDemonstration)
            {
                var randomNumber = GetRandomPositiveIntValue();
                var factorial = GetFactorial((uint)randomNumber);
                if (double.IsInfinity(factorial))
                {
                    Console.WriteLine("Result is Positive Infinity.");
                }
                Console.WriteLine($"{randomNumber}! = {factorial:#.### E+0}{Environment.NewLine}");
            }
            else
            {
                Console.WriteLine("Please, enter a positive number:");

                if (uint.TryParse(Console.ReadLine(), out uint positiveNumber))
                {
                    var factorial = GetFactorial(positiveNumber);
                    if (double.IsInfinity(factorial))
                    {
                        Console.WriteLine("Result is Positive Infinity.");
                    }
                    Console.WriteLine($"{positiveNumber}! = {factorial}{Environment.NewLine}");
                }
                else
                {
                    ProcessIncorrectInput();
                }
            }
        }

        static double GetFactorial(uint number)
        {
            if (number == 0)
            {
                return 1;
            }

            if (number == 1)
            {
                return number;
            }

            return (double)number * (GetFactorial(number - 1));
        }

        static bool GetTwoDoubleNumbersFromUser(out double number1, out double number2)
        {
            Console.WriteLine("Please, enter a first number:");
            var isNumber1 = double.TryParse(Console.ReadLine(), out number1);
            Console.WriteLine("Please, enter a second number:");
            var isNumber2 = double.TryParse(Console.ReadLine(), out number2);

            return isNumber1 && isNumber2;
        }

        static bool GetTwoPositiveIntNumbersFromUser(out uint number1, out uint number2)
        {
            Console.WriteLine("Please, enter a first number:");
            var isNumber1 = uint.TryParse(Console.ReadLine(), out number1);
            Console.WriteLine("Please, enter a second number:");
            var isNumber2 = uint.TryParse(Console.ReadLine(), out number2);

            return isNumber1 && isNumber2;
        }

        static double GetRandomDoubleValue()
        {
            var randomDoubleNumber = new Random().NextDouble() * new Random().Next(-100000, 100000);
            Console.WriteLine($"Your random double number is {randomDoubleNumber:F3}");
            return randomDoubleNumber;
        }

        static uint GetRandomPositiveIntValue()
        {
            var randomIntNumber = new Random().Next(170);
            Console.WriteLine($"Your random positive int number is {randomIntNumber}");
            return (uint)randomIntNumber;
        }

        static bool CheckDemonstrationCase()
        {
            Console.WriteLine("Do you want to use random numbers for demonstration? Enter Y if you want:");
            return Console.ReadLine()?.ToUpperInvariant() == "Y";
        }

        static void ProcessIncorrectInput()
        {
            Console.WriteLine($"Incorrect input{Environment.NewLine}");
        }
    }
}