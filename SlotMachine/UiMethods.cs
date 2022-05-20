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
            while(!double.TryParse(Console.ReadLine(), out Bet))
            {
                Console.Write("Invalid number, please insert a valid number: $ ");
            }
            return Bet;
        }

        public static string DisplayOptions()
        {
            Console.WriteLine("Select which line you would like to play: 'T' Top line, 'C' Center line, 'AH' all horizontal lines, 'AV' All Vertical lines, 'D' Diagonal lines, 'TH' Two horizontal lines:");
            string response = Console.ReadLine().ToUpper();
            return response;
        }

        public static void InValidInput()
        {
            Console.WriteLine("Valid input please");
        }

        public static void DisplaySlotMatrix(int[,] Matrix)
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
        public static string PlayMore()
        {
 
            string Answer = "";
            Console.WriteLine("Do you want to play again Y or N: ");
            Answer = Console.ReadLine().ToUpper();
            return Answer;
        }

        public static double WinTotal(double WinningTotal)
        {

            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("Here are your winnings: $ " + WinningTotal);
            Console.WriteLine("--------------------------------------");
            return WinningTotal;
        }

        public static void EndMessage()
        {
            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }
    }
}
