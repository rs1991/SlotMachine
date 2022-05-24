using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Winnings = 0, Odds = 2, TrioCombo = 3, DuoCombo = 2;
            double Wager;

            UiMethods.WelcomeMessage();

            //Grid array
            //_ = new int[3, 3];

            bool PlayAgain = true;

            while (PlayAgain)
            {
                // PlaceBet();
                Wager = UiMethods.GetWager();
                int[,] Grid = LogicMethods.GenerateGrid();

                bool InvalidInput = true;
                while (InvalidInput)
                {
                    string LineToPlay = UiMethods.DisplayOptions();

                    InvalidInput = false;

                    switch (LineToPlay)
                    {
                        case "T": //Plays the top line 
                            Winnings = LogicMethods.CalculateRowWinnings(Odds, Wager, Grid, 0);
                            break;

                        case "C": //Plays the central line
                            Winnings = LogicMethods.CalculateRowWinnings(Odds, Wager, Grid, 1);
                            break;

                        case "AH": //All Horizontal!
                            Winnings = LogicMethods.CalculateHorizontalWinnings(Odds, Wager, Grid, TrioCombo);
                            break;

                        case "TH": //Two Horizontal
                            Winnings = LogicMethods.CalculateHorizontalWinnings(Odds, Wager, Grid, DuoCombo);
                            break;

                        case "AV": //Plays all vertical lines 
                            Winnings = LogicMethods.CalculateAllVerticalWinnings(Odds, Wager, Grid, TrioCombo);
                            break;

                        case "D": // Plays all diagonal lines                                            
                            Winnings = LogicMethods.CalculateDiagWinnings(Odds, Wager, Grid, TrioCombo);
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


                if (UiMethods.PlayMore())
                {
                    PlayAgain = true;
                }
                else
                {
                    UiMethods.EndMessage();
                    break;
                }
            }

        }
    }
}
