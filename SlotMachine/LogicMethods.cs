using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class LogicMethods
    {
        /// <summary>
        /// Adds up the winnings of a single line bet
        /// </summary>
        /// <param name="Bet">The bet that the user places</param>
        /// <param name="Odd">The odds added to the equation if user wins</param>
        /// <returns>The winnings of a single line bet</returns>
        public static double CalculateSingleLineWinnings(double Bet, double Odd)
        {
            return Bet * Odd + 1;
        }

        /// <summary>
        /// Calculate the winnings for when three lines are played
        /// </summary>
        /// <param name="Bet">The bet that the user places</param>
        /// <param name="Odd">The odds added to the equation if user wins</param>
        /// <param name="TrioCombo">TrioCombo used when there are three winning lines</param>
        /// <returns>The winnings for when three lines are played</returns>
        public static double CalculateTripleLineWinnings(double Bet, double Odd, double TrioCombo)
        {
            return Bet * Odd * TrioCombo + 1;
        }

        /// <summary>
        /// Generates the random grid
        /// </summary>
        /// <returns>Randomly generated grid</returns>
        public static int[,] GenerateGrid()
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
                    //Grid1[row, col] = rng.Next(max + 1);
                }
            }
            return Grid1;
        }

        /// <summary>
        /// Calculates winnings for individual rows
        /// </summary>
        /// <param name="Odds">The odds added to the equation if user wins</param>
        /// <param name="Wager">The wager that the user places</param>
        /// <param name="Grid">If statement checks through the grid to see if numbers match</param>
        /// <param name="row"></param>
        /// <returns>Calculates the winnings for the individual rows</returns>
        public static double CalculateRowWinnings(double Odds, double Wager, int[,] Grid, int row)
        {
            double Winnings = 0;
            if (Grid[row, 0] == Grid[row, 1] && Grid[row, 1] == Grid[row, 2])
            {
                Winnings = LogicMethods.CalculateSingleLineWinnings(Wager, Odds);
            }
            return Winnings;
        }

        /// <summary>
        /// Calculates the horizontal winnings  
        /// </summary>
        /// <param name="Odds">Odds used to calculate the winnings</param>
        /// <param name="Wager">Wager placed by user</param>
        /// <param name="Grid">If statement checks through the grid to see if a winning combination is found</param>
        /// <param name="TrioCombo">If three lines match then winnings are tripled</param>
        /// <returns>Winnings for the horizontal lines played</returns>
        public static double CalculateHorizontalWinnings(double Odds, double Wager, int[,] Grid, double TrioCombo)
        {
            int WinningRowcnt = 0;
            int SelectedRow;
            for (SelectedRow = 0; SelectedRow < 3; SelectedRow++)
            {
                if (Grid[SelectedRow, 0] == Grid[SelectedRow, 1] && Grid[SelectedRow, 1] == Grid[SelectedRow, 2])
                {
                    WinningRowcnt++;
                }
            }
            double Winnings = 0;
            if (WinningRowcnt == 3)
            {
                Winnings = LogicMethods.CalculateTripleLineWinnings(Wager, Odds, TrioCombo);
            }
            return Winnings;
        }

        /// <summary>
        /// Calculates winnings for vertical lines  
        /// </summary>
        /// <param name="Odds">Odds added to the winnings calculation</param>
        /// <param name="Wager">User wager</param>
        /// <param name="Grid">If statement checks through the grid to see if a winning combination is found</param>
        /// <param name="TrioCombo">TrioCombo used when there are three winning lines</param>
        /// <returns>Vertical winnings</returns>
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
                Winnings = LogicMethods.CalculateTripleLineWinnings(Wager, Odds, TrioCombo);
            }
            return Winnings;
        }

        /// <summary>
        /// Winning calculation for diagonal lines
        /// </summary>
        /// <param name="Odds">Odds added to the winnings calculation</param>
        /// <param name="Wager">Wager that user places</param>
        /// <param name="Grid">If statement checks through the grid to see if a winning combination is found</param>
        /// <param name="TrioCombo">TrioCombo used when there are three winning lines</param>
        /// <returns>Winnings from when the diagonal lines are played</returns>
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
                Winnings = LogicMethods.CalculateTripleLineWinnings(Wager, Odds, TrioCombo);
            }
            return Winnings;
        }

        
    }
}