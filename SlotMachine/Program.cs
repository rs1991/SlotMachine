using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double Winnings = 0;
            //, Wager = 0, Odds = 2;

            UiMethods.WelcomeMessage();        
            
            bool PlayAgain = true;
                   

            while (PlayAgain)
            {
                //PlaceBet();
                //Wager = UiMethods.GetWager();
                int[,] Grid = LogicMethods.GenerateGrid();

                bool InvalidInput = true;
                while (InvalidInput)
                {
                    string LineToPlay = UiMethods.DisplayOptions();
                    
                    InvalidInput = false;

                    switch (LineToPlay)
                    {
                        case "T": //Plays the top line
                            UiMethods.SlotMachineGameOptions(UiMethods.GameOptions.TopLine);
                            break;
                        case "C": //Plays the central line
                            UiMethods.SlotMachineGameOptions(UiMethods.GameOptions.CentreLine);
                            break;
                        case "AH": //All Horizontal!
                            UiMethods.SlotMachineGameOptions(UiMethods.GameOptions.AllHorizontalLines);
                            break;
                        case "TH": //Two Horizontal
                            UiMethods.SlotMachineGameOptions(UiMethods.GameOptions.TwoHorizontalLines);
                            break;
                        case "AV": //Plays all vertical line
                            UiMethods.SlotMachineGameOptions(UiMethods.GameOptions.AllVerticalLines);
                            break;
                        case "D": // Plays all diagonal lines                                            
                            UiMethods.SlotMachineGameOptions(UiMethods.GameOptions.DiagonalLines);
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
