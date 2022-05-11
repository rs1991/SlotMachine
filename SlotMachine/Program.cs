using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Winnings = 0, Odds = 2, TrioCombo = 3, DuoCombo = 2;
            double Wager = 0;

            WelcomeMessage();

            //Random number generator
            Random rng = new Random();
            int max = 9;

            //Grid array
            int[,] Grid = new int[3, 3];

            bool PlayAgain = true;

            while (PlayAgain)
            {

                /*
                Console.Write("Place your wager: $ ");
                var UserWager = Console.ReadLine();

                //double Wager;
                while (!double.TryParse(UserWager, out Wager) || Wager < 0)
                {
                    Console.Write("Please insert a valid number to continue: $ ");
                    UserWager = Console.ReadLine();
                }
                */

                PlaceBet();

                //Grid to generate random numbers
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        Grid[row, col] = rng.Next(max + 1);
                    }
                }

                bool InvalidInput = true;
                while (InvalidInput)
                {
                    DisplayOptions();
                    var LineToPlay = Console.ReadLine().ToUpper();

                    InvalidInput = false;

                    switch (LineToPlay)
                    {
                        case "T":
                            if (Grid[0, 0] == Grid[0, 1] && Grid[0, 1] == Grid[0, 2])
                            {
                                Winnings = CalculateSingleLineWinnings(Wager, Odds);
                            }
                            break;
                        case "C":
                            if (Grid[0, 0] == Grid[0, 1] && Grid[0, 1] == Grid[0, 2])
                            {
                                Winnings = CalculateSingleLineWinnings(Wager, Odds);
                            }
                            break;
                        case "AH":
                            int WinningRowcnt = 0;
                            int SelectedRow = 0;
                            for (SelectedRow = 0; SelectedRow < 3; SelectedRow++)
                            {
                                if (Grid[SelectedRow, 0] == Grid[SelectedRow, 1] && Grid[SelectedRow, 2] == Grid[SelectedRow, 2])
                                {
                                    WinningRowcnt++;
                                }
                            }
                            if (WinningRowcnt == 3)
                            {
                                Winnings = CalculateWinningsAH(Wager, Odds, TrioCombo);
                            }
                            break;
                        case "TH":
                            int WinningRowCnt = 0;
                            int SelectedRw = 0;
                            for (SelectedRw = 0; SelectedRw < 3; SelectedRw++)
                            {
                                if (Grid[SelectedRw, 0] == Grid[SelectedRw, 1] &&
                                     Grid[SelectedRw, 1] == Grid[SelectedRw, 2])
                                {
                                    WinningRowCnt++;
                                }
                                if (WinningRowCnt == 3)
                                {
                                    Winnings = CalculateWinningsTH(Wager, Odds, DuoCombo);
                                }
                            }
                            break;
                        case "AV":
                            int WinningColCnt = 0;
                            int SelectedCol = 0;
                            for (SelectedCol = 0; SelectedCol < 3; SelectedCol++)
                            {
                                if (Grid[0, SelectedCol] == Grid[1, SelectedCol] && Grid[1, SelectedCol] == Grid[2, SelectedCol])
                                {
                                    WinningColCnt++;
                                }
                                if (WinningColCnt == 3)
                                {
                                    Winnings = CalculateWinningsAV(Wager, Odds, TrioCombo);
                                }
                            }
                            break;
                        case "D":
                            int WinningDiagCnt = 0;
                            int SelectedDiag = 0;
                            for (SelectedDiag = 0; SelectedDiag < 3; SelectedDiag++)
                            {
                                if (Grid[SelectedDiag, 0] == Grid[SelectedDiag, 1] &&
                                    Grid[SelectedDiag, 1] == Grid[SelectedDiag, 2])
                                {
                                    WinningDiagCnt++;
                                }
                                if (WinningDiagCnt == 3)
                                {
                                    Winnings = CalculateWinningsD(Wager, Odds, TrioCombo);
                                }
                            }
                            break;
                        default:
                            InvalidInput = true;
                            break;
                    }
                    if (InvalidInput)
                    {
                        InValidInput();
                    }
                }

                //Display the grid
                DisplaySlotMatrix(Grid);

                WinTotal(Winnings);

                string Answer = "";

                PlayMore(Answer);
                PlayAgain = (Answer == "Y");

            }
            EndMessage();
        }

        static void PlaceBet()
        {
            double Wager = 0;
                Console.Write("Place your wager: $ ");
                var UserWager = Console.ReadLine();

                //double Wager;
                while (!double.TryParse(UserWager, out Wager) || Wager < 0)
                {
                    Console.Write("Please insert a valid number to continue: $ ");
                    UserWager = Console.ReadLine();
                }
                
        }

        /// <summary>
        /// This method simply displays the welcome message
        /// </summary>
        static void WelcomeMessage()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to the slot machine!");
            Console.WriteLine("----------------------------");
        }

        /// <summary>
        /// This method asks the user if they wish to play again after placing first bet
        /// </summary>
        /// <param name="Response">Does the user want to play again? Yes or No</param>
        /// <returns></returns>
        static string PlayMore(string Response)
        {
            string Answer = "";
            Console.Write("Do you want to play again: ");
            Response = Console.ReadLine().ToUpper();
            return Answer;
        }

        /// <summary>
        /// The amount of money the user wishes to bet when playing the slot machine
        /// </summary>
        /// <param name="Wager">The amount the user wishes to bet</param>
        /// <returns>The bet placed by the user</returns>
        static double PlaceBet(double Wager)
        {
            Console.Write("Place your wager: $ ");
            var UserWager = Console.ReadLine();

            while (!double.TryParse(UserWager, out Wager) || Wager < 0)
            {
                Console.Write("Please insert a valid number to continue: $ ");
                UserWager = Console.ReadLine();
            }
            return Wager;
        }

        static double WinTotal(double WinningTotal)
        {
            
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("Here are your winnings: $ " + WinningTotal);
            Console.WriteLine("--------------------------------------");

            return WinningTotal;

        }
                
        /// <summary>
        /// Makes sure that the user selects one of the listed game options
        /// </summary>
        static void InValidInput()
        {
            Console.WriteLine("Valid input please");
        }

        /// <summary>
        /// Displays the options that the user can play
        /// </summary>           
        static void DisplayOptions()
        {
            Console.WriteLine("Select which line you would like to play: 'T' Top line, 'C' Center line, 'AH' all horizontal lines, 'AV' All Vertical lines, 'D' Diagonal lines, 'TH' Two horizontal lines:");
        }

        /// <summary>
        /// Displays a message to thank the user for playing
        /// </summary>
        static void EndMessage()
        {
            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }

        /// <summary>
        /// This method shows the slot machine after a wager has been placed and a play option has been selected
        /// </summary>
        /// <param name="Matrix"></param>
        static void DisplaySlotMatrix(int[,] Matrix)
        {
            int[,] Grid = new int[3, 3];

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write("{0}\t", Matrix[row, col]);
                }
                Console.Write("\n");
            }

        }

        /// <summary>
        /// Calculates the winnings when either one row is identincal  
        /// </summary>
        /// <param name="Bet"></param>
        /// <param name="Odd"></param>
        /// <returns>When a row matches, the total money won is added up based on the bet that the user puts in plus the odds</returns>
        static double CalculateSingleLineWinnings(double Bet, double Odd)
        {
            double Total = 0;
            Total = Bet * Odd + 1;
            return Total;
        }

        /// <summary>
        /// Calculates the winnings for when the user selects the all horizontal lines option
        /// </summary>
        /// <param name="Bet">The bet the user places</param>
        /// <param name="Odd">The odds calculation if the user wins</param>
        /// <param name="Trio">All three lines are played so winning are tripled</param>
        /// <returns>The winnings from when the user plays all the horizontal options</returns>

        static double CalculateWinningsAH(double Bet, double Odd, double Trio)
        {
            double Total = 0;
            Total = Bet * Odd * Trio + 1;
            return Total;
        }

        /// <summary>
        /// Calculates the winnings if user chooses to play two horizontal lines
        /// </summary>
        /// <param name="Bet">The bet the user places</param>
        /// <param name="Odd">The odds calculation if the user wins</param>
        /// <param name="Duo">Two horizontal lines are played so winning are doubled</param>
        /// <returns>The winnings from when the user plays the two horizontal options</returns>

        static double CalculateWinningsTH(double Bet, double Odd, double Duo)
        {
            double Total = 0;
            Total = Bet * Odd * Duo + 1;
            return Total;
        }

        /// <summary>
        /// Calculates the winnings if user chooses to play all vertical lines
        /// </summary>
        /// <param name="Bet">The bet the user places</param>
        /// <param name="Odd">The odds calculation if the user wins</param>
        /// <param name="Trio">Three vertical lines are played so winnings are tripled</param>
        /// <returns>The winnings for when the user plays all three vertical options</returns>

        static double CalculateWinningsAV(double Bet, double Odd, double Trio)
        {
            double Total = 0;
            Total = Bet * Odd * Trio + 1;
            return Total;
        }

        /// <summary>
        /// Calculates the winnings for when diagonal lines are played
        /// </summary>
        /// <param name="Bet">The bet the user places</param>
        /// <param name="Odd">The odds calculation if the user wins</param>
        /// <param name="Duo"></param>
        /// <returns>The winnings for when user play the diagonal option</returns>

        static double CalculateWinningsD(double Bet, double Odd, double Duo)
        {
            double Total = 0;
            Total = Bet * Odd * Duo + 1;
            return Total;
        }
    }
}