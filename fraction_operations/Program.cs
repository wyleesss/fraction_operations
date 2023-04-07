using Fractions;
using System.Text;

namespace Program
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Fraction First = new Fraction();
            Fraction Second = new Fraction();
            Fraction Result = new Fraction();
            char sign = '\0';
            int Next = 0;


            string SFirst = string.Empty;
            string SSecond = string.Empty;

            Console.WriteLine("(i)\tФОРМАТИ ВВОДУ:" +
                "\n\t1. [ціле число] [чисельник]/[знаменник]" +
                "\n\t2. [чисельник]/[знаменник]" +
                "\n\t3. [ціле число]" +
                "\n\t!зауважте, ви можете також вводити знак дробу" +
                "\n\nнатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
            Console.Clear();

            do
            {
                Console.Clear();
                Next = 0;

                while (Next != 3)
                {

                    try
                    {
                        if (Next == 0)
                        {
                            Console.Write("\n\nвведіть перший дріб\n-> ");
                            First = Fraction.Parse(new string(Console.ReadLine()));

                            SFirst = First.ToString();

                            Next++;
                        }

                        else if (Next == 1)
                        {
                            Console.Write($"{First}\n\nвведіть другий дріб\n-> ");
                            Second = Fraction.Parse(new string(Console.ReadLine()));

                            SSecond = Second.ToString();

                            Next++;
                        }

                        else if (Next == 2)
                        {
                            Console.Write($"{First}   {Second}\n\nвведіть операцію (+-/*)\n-> ");

                            sign = Console.ReadKey().KeyChar;

                            if (!"+-/*".Contains(sign))
                            {
                                Console.WriteLine("невірний ввід");
                                continue;
                            }

                            switch (sign)
                            {
                                case '+':
                                    Result = First + Second;
                                    break;

                                case '-':
                                    Result = First - Second;
                                    break;

                                case '/':
                                    Result = First / Second;
                                    break;

                                case '*':
                                    Result = First * Second;
                                    break;
                            }

                            Next++;
                        }

                        Console.Clear();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.Clear();
                Console.Write($"результат:\n{SFirst} {sign} {SSecond} = {Result}");

                Console.WriteLine("\n\nдля продовження - будь-яка клавіша\nінакше - ESC");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}