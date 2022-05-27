using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class UiMethods
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to the slot machine!");
            Console.WriteLine("----------------------------");
        }

        public static double GetWager()
        {
            double Bet = 0;
            Console.Write("Place your bet: $ ");
            while (!double.TryParse(Console.ReadLine(), out Bet))
            {
                Console.Write("Invalid number, please insert a valid number: $ ");
            }
            return Bet;
        }

        public static string DisplayOptions()
        {
            Console.WriteLine("Select which line you would like to play: 'T' Top line, 'C' Center line, 'AH' all horizontal lines, 'AV' All Vertical lines, 'D' Diagonal lines, 'TH' Two horizontal lines:");
            string response = Convert.ToString(Console.ReadLine().ToUpper());
            return response;
        }

        public static void InValidInput()
        {
            Console.WriteLine("Valid input please");
        }

        public static void DisplaySlotMatrix(int[,] Matrix)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write("{0}\t", Matrix[row, col]);
                }
                Console.Write("\n");
            }

        }
        public static bool PlayMore()
        {
            string Answer;
            Console.WriteLine("Do you want to play again Y or N: ");
            Answer = Console.ReadLine().ToUpper();
            if (Answer == "Y")
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public static void WinTotal(double WinningTotal)
        {
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("Here are your winnings: $ " + WinningTotal);
            Console.WriteLine("--------------------------------------");
        }

        public static void EndMessage()
        {
            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }


        public enum GameOptions
        {
            TopLine,
            CentreLine,
            AllHorizontalLines,
            TwoHorizontalLines,
            AllVerticalLines,
            DiagonalLines
        }


        public static void SlotMachineGameOptions(GameOptions gameOptions)
        {
            double Winnings;
            double Odds = 2;
            double Wager;
            double DuoCombo = 2;
            double TrioCombo = 3;
            int[,] Grid = LogicMethods.GenerateGrid();

            //DisplayOptions();
            //GetWager();
                        
            //GameOptions option = (GameOptions)Enum.Parse(typeof(GameOptions), res);

            Wager = GetWager();

            switch (gameOptions)
            {
                case GameOptions.TopLine:
                    //Console.WriteLine("The top line only has been played");
                   Winnings = LogicMethods.CalculateRowWinnings(Odds, Wager, Grid, 0);
                    break;
                case GameOptions.CentreLine:
                    { 
                    Winnings = LogicMethods.CalculateRowWinnings(Odds, Wager, Grid, 1);
                    }
                    break;
                case GameOptions.AllHorizontalLines:
                    Winnings = LogicMethods.CalculateHorizontalWinnings(Odds, Wager, Grid, TrioCombo);
                    break;
                case GameOptions.TwoHorizontalLines:
                    Winnings = LogicMethods.CalculateHorizontalWinnings(Odds, Wager, Grid, DuoCombo);
                    break;
                case GameOptions.AllVerticalLines:
                    Winnings = LogicMethods.CalculateAllVerticalWinnings(Odds, Wager, Grid, TrioCombo);
                    break;
                case GameOptions.DiagonalLines:
                    Winnings = LogicMethods.CalculateDiagWinnings(Odds, Wager, Grid, TrioCombo);
                    break;
                default:
                    throw new Exception("Invalid choice");
            }
           WinTotal(Winnings);
        }


    }
}
