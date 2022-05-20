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


        public static void GenerateGrid(int[,] Grid)
        {
            //Random number generator
            Random rng = new Random();
            int max = 9;
            //Grid array
            int[,] Grid1 = new int[3, 3];
            //Grid to generate random numbers
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Grid[row, col] = rng.Next(max + 1);
                }
            }
        }

    }
}
