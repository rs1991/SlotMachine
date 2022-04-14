using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Winnings = 0, Odds = 2;
            string LineToPlay;
            bool PlayAgain = true;

            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to the slot machine!");
            Console.WriteLine("----------------------------");

            //Random number generator
            Random rng = new Random();

            int[,] rows = new int[3, 3];

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    // Console.WriteLine($"i: {i} j: {j}");
                    rows[row, col] = rng.Next(9);
                }
            }


            while (PlayAgain)
            {

                Console.Write("Place your wager: ");
                var UserWager = Console.ReadLine();

                double Wager;
                while(!double.TryParse(UserWager, out Wager))
                {
                    Console.WriteLine("Please insert a valid number to continue: ");
                    UserWager = Console.ReadLine();
                }
                
                Console.WriteLine("Select which line you would like to play: 'T' Top line, 'C' Center line, 'AH' all horizontal lines, 'AV' All Vertical lines, 'D' Diagonal lines");
                LineToPlay = Console.ReadLine().ToUpper();
            

                switch (LineToPlay)
                {
                    case "T":

                        for (int row = 0; row < 3; row++)
                        {
                            for (int col = 0; col < 3; col++)
                            {

                                rows[row, col] = rng.Next(9);
                            }
                        }

                        Console.WriteLine(rows[0, 0]);
                        Console.WriteLine(rows[0, 1]);
                        Console.WriteLine(rows[0, 2]);

                        if (rows[0, 0] == rows[0, 1] && rows[0, 0] == rows[0, 2])
                        {
                            Winnings = Wager * Odds;
                        }
                        break;

                    case "C":

                        for (int row = 0; row < 3; row++)
                        {
                            for (int col = 0; col < 3; col++)
                            {

                                rows[row, col] = rng.Next(9);
                            }
                        }

                        Console.WriteLine(rows[1, 0]);
                        Console.WriteLine(rows[1, 1]);
                        Console.WriteLine(rows[1, 2]);

                        if (rows[1, 0] == rows[1, 1] && rows[1, 1] == rows[1, 2])
                        {

                            Winnings = Wager * Odds;
                        }
                        break;

                    case "AH":

                        for (int row = 0; row < 3; row++)
                        {
                            for (int col = 0; col < 3; col++)
                            {
                                rows[row, col] = rng.Next(9);
                            }
                        }

                        Console.WriteLine("Line 1");
                        Console.WriteLine(rows[0, 0]);
                        Console.WriteLine(rows[0, 1]);
                        Console.WriteLine(rows[0, 2]);
                        Console.WriteLine("Line 2");
                        Console.WriteLine(rows[1, 0]);
                        Console.WriteLine(rows[1, 1]);
                        Console.WriteLine(rows[1, 2]);
                        Console.WriteLine("Line 3");
                        Console.WriteLine(rows[2, 0]);
                        Console.WriteLine(rows[2, 1]);
                        Console.WriteLine(rows[2, 2]);


                        if (rows[0, 0] == rows[0, 1] && rows[0, 0] == rows[0, 2])
                        {

                            Winnings = Wager * Odds;
                        }

                        if (rows[1, 0] == rows[1, 1] && rows[1, 0] == rows[1, 2])
                        {

                            Winnings = Wager * Odds;
                        }

                        if (rows[2, 0] == rows[2, 1] && rows[2, 1] == rows[2, 2])
                        {

                            Winnings = Wager * Odds;
                        }

                        break;

                    case "AV":
                        Console.WriteLine("Play all vertical lines");

                        for (int row = 0; row < 3; row++)
                        {
                            for (int col = 0; col < 3; col++)
                            {
                                rows[row, col] = rng.Next(9);
                            }
                        }

                        Console.WriteLine("Line 1");
                        Console.WriteLine(rows[0, 0]);
                        Console.WriteLine(rows[1, 0]);
                        Console.WriteLine(rows[2, 0]);

                        Console.WriteLine("Line 2");
                        Console.WriteLine(rows[0, 1]);
                        Console.WriteLine(rows[1, 1]);
                        Console.WriteLine(rows[2, 1]);

                        Console.WriteLine("Line 3");
                        Console.WriteLine(rows[0, 2]);
                        Console.WriteLine(rows[1, 2]);
                        Console.WriteLine(rows[2, 2]);


                        if (rows[0, 0] == rows[1, 0] && rows[0, 0] == rows[2, 0])
                        {

                            Winnings = Wager * Odds;
                        }
                        break;

                    case "D":

                        for (int row = 0; row < 3; row++)
                        {
                            for (int col = 0; col < 3; col++)
                            {
                                rows[row, col] = rng.Next(9);
                            }
                        }

                        Console.WriteLine(rows[0, 0]);
                        Console.WriteLine(rows[1, 1]);
                        Console.WriteLine(rows[2, 2]);

                        if (rows[0, 0] == rows[1, 1] && rows[0, 0] == rows[2, 2])
                        {

                            Winnings = Wager * Odds;
                        }

                        break;
                }
                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("Here are your winnings: $ " + Winnings);
                Console.WriteLine("--------------------------------------");

                string Answer = "";
                Console.Write("Do you want to play again: ");
                Answer = Console.ReadLine().ToUpper();

                if (Answer == "Y")
                {
                    PlayAgain = true;
                }
                else
                {
                    PlayAgain = false;
                }
            }

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }

    }
}
