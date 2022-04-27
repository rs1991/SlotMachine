using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Winnings = 0, Odds = 2;
            bool PlayAgain = true;

            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to the slot machine!");
            Console.WriteLine("----------------------------");

            //Random number generator
            Random rng = new Random();

            //Grid array
            int[,] rows = new int[3, 3];

            while (PlayAgain)
            {
                
                Console.WriteLine("----------------");
                Console.Write("Place your wager: $ ");
                var UserWager = Console.ReadLine();

                double Wager;
                while (!double.TryParse(UserWager, out Wager) || Wager < 0)
                {
                    Console.Write("Please insert a valid number to continue: $ ");
                    UserWager = Console.ReadLine();
                }

                //Grid to generate random numbers
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        rows[row, col] = rng.Next(9);
                    }
                }

                bool InvalidInput = true;
                while (InvalidInput)
                {
                    Console.WriteLine("Select which line you would like to play: 'T' Top line, 'C' Center line, 'AH' all horizontal lines, 'AV' All Vertical lines, 'D' Diagonal lines: ");
                    var LineToPlay = Console.ReadLine().ToUpper();
                    switch (LineToPlay)
                    {
                        case "T":
                            if (rows[0, 0] == rows[0, 1] &&
                                rows[0, 1] == rows[0, 2])
                            {
                                //do something (add 2 coins to your winning)
                                Winnings = (Wager * Odds) + 1;
                            }
                            InvalidInput = false;
                            break;
                        case "C":
                            if (rows[1, 0] == rows[1, 1] &&
                                rows[1, 1] == rows[1, 2])
                            {
                                Winnings = (Wager * Odds) + 1;
                            }
                            InvalidInput = false;
                            break;
                        case "AH":
                            for (int row = 0; row < 3; row++)
                            {
                                if (rows[row, 0] == rows[row, 1] &&
                                    rows[row, 1] == rows[row, 2])
                                {
                                    //do something (add 2 coins to your winning)
                                    Winnings = (Wager * Odds) + 1;
                                }
                            }
                            InvalidInput = false;
                            break;
                        case "AV":
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (rows[0, 0] == rows[1, 0] &&
                                        rows[0, 1] == rows[1, 1] &&
                                        rows[1, 1] == rows[2, 1] &&
                                        rows[0, 2] == rows[1, 2] &&
                                        rows[1, 2] == rows[2, 2])
                                    {
                                        //do something (add 2 coins to your winning)
                                        Winnings = (Wager * Odds) + 2;
                                    }
                                }
                            }
                            InvalidInput = false;
                            break;
                        case "D":
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (rows[0, 0] == rows[1, 1] &&
                                        rows[1, 1] == rows[2, 2]||
                                        rows[2,0] == rows[1, 1]&&
                                        rows[1,1] == rows[0,2])
                                    {
                                        Winnings = (Wager * Odds) + 1;
                                    }
                                }
                            }
                            InvalidInput = false;
                            break;
                        default:
                            InvalidInput = true;
                            break;
                    }
                    if (InvalidInput)
                    {
                        Console.WriteLine("Valid input please");
                    }
                }

                //display grid and winnings
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        Console.Write("{0}\t", rows[row, col]);
                    }
                    Console.Write("\n");
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
