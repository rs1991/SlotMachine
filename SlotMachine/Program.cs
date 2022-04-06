using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Wager = 0, Winnings = 0;
            string TopLine, CenterLine, AllHorizontal, AllVertical, Diagonal, LineToPlay;

            Console.WriteLine("Welcome to the slot machine!");

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
                { num7, num7, num8 } };

            Console.WriteLine("Place your wager: ");
            Wager = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select which line you would like to play: 'T' Top line, 'C' Center line, 'AH' all horizontal lines, 'AV' All Vertical lines, 'D' Diagonal lines");
            LineToPlay = Console.ReadLine().ToUpper();


            switch (LineToPlay)
            {
                case "T":
                    Console.WriteLine("Play the top line");
                    break;

                case "C":
                    Console.WriteLine("Play the center line");
                    break;

                case "AH":
                    Console.WriteLine("Play all horizontal lines");
                    break;

                case "AV":
                    Console.WriteLine("Play all vertical lines");
                    break;

                case "D":
                    Console.WriteLine("Play diagonal lines");
                    break;

                    




            }

            /*if(LineToPlay == "T")
            {
                Console.WriteLine("Play the top line");
            }
            if (LineToPlay == "C")
            {
                Console.WriteLine("Play the center line");
            }
            */

        }

    }
}