using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Wager = 0, Winnings = 0, Odds = 2;
            string LineToPlay;
            bool Decision = true;

            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to the slot machine!");
            Console.WriteLine("----------------------------");

            //Random number generator
            Random random = new Random();
            int num1 = random.Next(9);
            int num2 = random.Next(9);
            int num3 = random.Next(9);
            int num4 = random.Next(9);
            int num5 = random.Next(9);
            int num6 = random.Next(9);
            int num7 = random.Next(9);
            int num8 = random.Next(9);
            int num9 = random.Next(9);

            int[,] rows = new int[3, 3] {
                { num1, num2, num3 },
                { num4, num5, num6 },
                { num7, num8, num9 } };


            while (Decision)
            {

                string Answer = "";

                Console.Write("Place your wager: ");
                Wager = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Select which line you would like to play: 'T' Top line, 'C' Center line, 'AH' all horizontal lines, 'AV' All Vertical lines, 'D' Diagonal lines");
                LineToPlay = Console.ReadLine().ToUpper();

                switch (LineToPlay)
                {
                    case "T":

                        Console.WriteLine($"{num1} {num2} {num3}");

                        if (num1 == num2 && num2 == num3)
                        {

                            Winnings = Wager * Odds;
                        }
                        break;

                    case "C":

                        Console.WriteLine($"{num4} {num5} {num6}");

                        if (num4 == num5 && num5 == num6)
                        {

                            Winnings = Wager * Odds;
                        }
                        break;

                    case "AH":
                        Console.WriteLine("Play all horizontal lines");
                        Console.WriteLine($"{num1} {num2} {num3}");
                        Console.WriteLine($"{num4} {num5} {num6}");
                        Console.WriteLine($"{num7} {num8} {num9}");

                        if (num1 == num2 && num2 == num3)
                        {
                            Winnings = Wager * Odds;
                        }
                        if (num4 == num5 && num5 == num6)
                        {
                            Winnings = Wager * Odds;
                        }
                        if (num7 == num8 && num8 == num9)
                        {
                            Winnings = Wager * Odds;
                        }
                        break;

                    case "AV":
                        Console.WriteLine("Play all vertical lines");
                        if (num1 == num4 && num4 == num7)
                        {
                            Winnings = Wager * Odds;
                        }
                        if (num2 == num5 && num5 == num8)
                        {
                            Winnings = Wager * Odds;
                        }
                        if (num3 == num6 && num6 == num9)
                        {
                            Winnings = Wager * Odds;
                        }
                        break;

                    case "D":
                        Console.WriteLine($"{num1} {num5} {num9}");

                        if (num1 == num5 && num5 == num9)
                        {
                            Winnings = Wager * Odds;
                        }
                        break;
                }
                Console.WriteLine("Here are your winnings: $ " + Winnings);


                Console.Write("Do you want to play again: ");
                Answer = Console.ReadLine().ToUpper();

                if (Answer == "Y")
                {
                    Decision = true;
                }
                else
                {
                    Decision = false;
                }
            }

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }

    }

}