using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class LogicMethods
    {

        public static double CalculateSingleLineWinnings(double Bet, double Odd)
        {
            double Total = 0;
            Total = Bet * Odd + 1;
            return Total;
        }

        public static double CalculateOtherWinnings(double Bet, double Odd, double Trio)
        {
            double Total = 0;
            Total = Bet * Odd * Trio + 1;
            return Total;
        }

        public static double WinTotal(double WinningTotal)
        {

            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("Here are your winnings: $ " + WinningTotal);
            Console.WriteLine("--------------------------------------");
            return WinningTotal;
        }
    }
}
