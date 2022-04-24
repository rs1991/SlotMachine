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


                Console.WriteLine("Select which line you would like to play: 'T' Top line, 'C' Center line, 'AH' all horizontal lines, 'AV' All Vertical lines, 'D' Diagonal lines: ");
                var LineToPlay = Console.ReadLine().ToUpper();

                switch (LineToPlay)
                {
                    case "T":
                        for (int row = 0; row > 3; row++)
                        {
                            if (rows[row, 0] == rows[row, 1] &&
                                rows[row, 0] == rows[row, 2])
                            {
                                //do something (add 2 coins to your winning)
                                Winnings = (Wager * Odds) + 1;
                            }
                        }
                        break;
                    case "C":
                        for (int row = 0; row < 3; row++)
                        {
                            if (rows[row, 0] == rows[row, 1] &&
                                rows[row, 1] == rows[row, 2])
                            {
                                Winnings = (Wager * Odds) + 1;
                            }
                        }
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
                        break;
                    case "AV":
                        for (int col = 0; col < 3; col++)
                        {
                            if (rows[col, 0] == rows[col, 0] &&
                                rows[col, 0] == rows[col, 0])
                            {
                                //do something (add 2 coins to your winning)
                                Winnings = (Wager * Odds) + 2;
                            }
                        }
                        break;
                    case "D":
                        for (int row = 0; row < 3; row++)
                        {
                            if (rows[row, 0] == rows[row, 1] &&
                                rows[row, 1] == rows[row, 2])
                            {
                                //do something (add 2 coins to your winning)
                                Winnings = (Wager * Odds) + 1;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("please enter a valid choice");
                        break;



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