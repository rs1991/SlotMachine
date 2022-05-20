using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Winnings = 0, Odds = 2, TrioCombo = 3, DuoCombo = 2;
            double Wager = 0;

            UiMethods.WelcomeMessage();
                        
            //Grid array
            int[,] Grid = new int[3, 3];

            bool PlayAgain = true;

            while (PlayAgain)
            {

                // PlaceBet();
                Wager = UiMethods.GetWager();
                            
                LogicMethods.GenerateGrid(Grid);

                bool InvalidInput = true;
                while (InvalidInput)
                {
                    string LineToPlay = UiMethods.DisplayOptions();

                    InvalidInput = false;

                    switch (LineToPlay)
                    {
                        case "T":
                            if (Grid[0, 0] == Grid[0, 1] && Grid[0, 1] == Grid[0, 2])
                            {
                                Winnings = LogicMethods.CalculateSingleLineWinnings(Wager, Odds);
                            }
                            break;
                        case "C":
                            if (Grid[1, 0] == Grid[1, 1] && Grid[1, 1] == Grid[1, 2])
                            {
                                Winnings = LogicMethods.CalculateSingleLineWinnings(Wager, Odds);
                            }
                            break;
                        case "AH":
                            int WinningRowcnt = 0;
                            int SelectedRow;
                            for (SelectedRow = 0; SelectedRow < 3; SelectedRow++)
                            {
                                if (Grid[SelectedRow, 0] == Grid[SelectedRow, 1] && Grid[SelectedRow, 2] == Grid[SelectedRow, 2])
                                {
                                    WinningRowcnt++;
                                }
                            }
                            if (WinningRowcnt == 3)
                            {
                                Winnings = LogicMethods.CalculateOtherWinnings(Wager, Odds, TrioCombo);
                            }
                            break;
                        case "TH":
                            int WinningRowCnt = 0;
                            int SelectedRw;
                            for (SelectedRw = 0; SelectedRw < 3; SelectedRw++)
                            {
                                if (Grid[SelectedRw, 0] == Grid[SelectedRw, 1] &&
                                     Grid[SelectedRw, 1] == Grid[SelectedRw, 2])
                                {
                                    WinningRowCnt++;
                                }
                                if (WinningRowCnt == 3)
                                {
                                    Winnings = LogicMethods.CalculateOtherWinnings(Wager, Odds, DuoCombo);
                                }
                            }
                            break;
                        case "AV":
                            int WinningColCnt = 0;
                            int SelectedCol;
                            for (SelectedCol = 0; SelectedCol < 3; SelectedCol++)
                            {
                                if (Grid[0, SelectedCol] == Grid[1, SelectedCol] && Grid[1, SelectedCol] == Grid[2, SelectedCol])
                                {
                                    WinningColCnt++;
                                }
                                if (WinningColCnt == 3)
                                {
                                    Winnings = LogicMethods.CalculateOtherWinnings(Wager, Odds, TrioCombo);
                                }
                            }
                            break;
                        case "D":
                            int WinningDiagCnt = 0;
                            int SelectedDiag;
                            for (SelectedDiag = 0; SelectedDiag < 3; SelectedDiag++)
                            {
                                if (Grid[SelectedDiag, 0] == Grid[SelectedDiag, 1] &&
                                    Grid[SelectedDiag, 1] == Grid[SelectedDiag, 2])
                                {
                                    WinningDiagCnt++;
                                }
                                if (WinningDiagCnt == 3)
                                {
                                    Winnings = LogicMethods.CalculateOtherWinnings(Wager, Odds, TrioCombo);
                                }
                            }
                            break;
                        default:
                            InvalidInput = true;
                            break;
                    }
                    if (InvalidInput)
                    {
                        UiMethods.InValidInput();
                    }
                }

                //Display the grid
                UiMethods.DisplaySlotMatrix(Grid);
                UiMethods.WinTotal(Winnings);

                //string Answer = 
                    
                UiMethods.PlayMore();

                //PlayAgain = (Answer == "Y");

            }
            UiMethods.EndMessage();
        }
        
    }
}