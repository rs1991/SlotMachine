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
            Bet = double.Parse(Console.ReadLine());
            return Bet;
        }
    }
}
