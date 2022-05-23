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


        public static int[,] GenerateGrid()
        {
            //Random number generator
            Random rng = new Random();
            //int max = 9;
            //Grid array
            int[,] Grid1 = new int[3, 3];
            //Grid to generate random numbers
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    //Grid1[row, col] = rng.Next(max + 1);
                }
            }

            return Grid1;
        }

        public static double CalculateRowWinnings(double Odds, double Wager, int[,] Grid, int row)
        {
            double Winnings = 0;
            if (Grid[row, 0] == Grid[row, 1] && Grid[row, 1] == Grid[row, 2])
            {
                Winnings = LogicMethods.CalculateSingleLineWinnings(Wager, Odds);
            }
            return Winnings;
        }

        public static double CalculateHorizontalWinnings(double Odds, double Wager, int[,] Grid, double TrioCombo)
        {
            int WinningRowcnt = 0;
            int SelectedRow;
            for (SelectedRow = 0; SelectedRow < 3; SelectedRow++)
            {
                if (Grid[SelectedRow, 0] == Grid[SelectedRow, 1] && Grid[SelectedRow, 2] == Grid[SelectedRow, 2])
                {
                    WinningRowcnt++;
                }
            }
            double Winnings = 0;
            if (WinningRowcnt == 3)
            {
                Winnings = LogicMethods.CalculateOtherWinnings(Wager, Odds, TrioCombo);
            }
            return Winnings;
        }

        public static double CalculateAllVerticalWinnings(double Odds, double Wager, int[,] Grid, double TrioCombo)
        {
            int WinningRowcnt = 0;
            int SelectRw;
            for (SelectRw = 0; SelectRw < 3; SelectRw++)
            {
                if (Grid[0, SelectRw] == Grid[1, SelectRw] && Grid[1, SelectRw] == Grid[2, SelectRw])
                {
                    WinningRowcnt++;
                }
            }
            double Winnings = 0;
            if (WinningRowcnt == 3)
            {
                Winnings = LogicMethods.CalculateOtherWinnings(Wager, Odds, TrioCombo);
            }
            return Winnings;
        }

        public static double CalculateDiagWinnings(double Odds, double Wager, int[,] Grid, double TrioCombo)
        {
            int WinningDiagCnt = 0;
            int SelectedDiag;
            for (SelectedDiag = 0; SelectedDiag < 3; SelectedDiag++)
            {
                if (Grid[SelectedDiag, 0] == Grid[SelectedDiag, 1] &&
                    Grid[SelectedDiag, 1] == Grid[SelectedDiag, 2])
                {
                    WinningDiagCnt++;
                }
            }
            double Winnings = 0;
            if (WinningDiagCnt == 3)
            {
                Winnings = LogicMethods.CalculateOtherWinnings(Wager, Odds, TrioCombo);
            }
            return Winnings;
        }

    }
}


