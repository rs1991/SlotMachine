using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Winnings = 0, Odds = 2, TrioCombo = 3, DuoCombo = 2;

            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to the slot machine!");
            Console.WriteLine("----------------------------");

            //Random number generator
            Random rng = new Random();
            int max = 9;

            //Grid array
            int[,] Grid = new int[3, 3];

            bool PlayAgain = true;

            while (PlayAgain)
            {

                Console.WriteLine("----------------");
                Console.Write("Place your wager: $ ");
                var UserWager = Console.ReadLine();

                double Wager;
                while (!double.TryParse(UserWager, out Wager) || Wager < 0)
                {
                    Console.Write("Please insert a valid number to continue: $ ");
                    UserWager = Console.ReadLine();
                }

                //Grid to generate random numbers
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        Grid[row, col] = rng.Next(max + 1);
                    }
                }
                                
                bool InvalidInput = true;
                while (InvalidInput)
                {
                    Console.WriteLine("Select which line you would like to play: 'T' Top line, 'C' Center line, 'AH' all horizontal lines, 'AV' All Vertical lines, 'D' Diagonal lines, 'TH' Two horizontal lines: ");
                    var LineToPlay = Console.ReadLine().ToUpper();
                    InvalidInput = false;
                    switch (LineToPlay)
                    {
                        case "T":
                            int TopRow = 0;
                            int WinningTopRowCnt = 0;
                            
                            for(TopRow = 0; TopRow < 3; TopRow++)
                            {
                                if (Grid[0, 0] == Grid[0, 1] &&
                                Grid[0, 1] == Grid[0, 2])
                                {
                                    WinningTopRowCnt++;
                                }
                                if(WinningTopRowCnt == 3)
                                {
                                    Winnings = (Wager * Odds) + 1;
                                }
                            }
                            break;
                        case "C":
                            int CentralRow = 0;
                            int CentralWinRowCnt = 0;

                            for(CentralWinRowCnt = 0; CentralWinRowCnt < 3; CentralWinRowCnt++)
                            {
                                if (Grid[1, 0] == Grid[1, 1] &&
                                Grid[1, 1] == Grid[1, 2])
                                {
                                    CentralWinRowCnt++;
                                }
                                if(CentralRow == 3)
                                {
                                    Winnings = (Wager * Odds) + 1;
                                }
                            }                            
                            break;
                        case "AH":
                            int WinningRowcnt = 0;
                            int SelectedRow = 0;
                            for(SelectedRow = 0; SelectedRow < 3; SelectedRow++)
                            {
                                if(Grid[SelectedRow, 0] == Grid[SelectedRow, 1] && Grid[SelectedRow, 2] == Grid[SelectedRow, 2])
                                {
                                    WinningRowcnt++;
                                }
                            }
                            if(WinningRowcnt == 3)
                            {
                                Winnings = (Wager * Odds * TrioCombo) + 1;
                            }
                            break;
                        case "TH":
                            int WinningRowCnt = 0;
                            int SelectedRw = 0;
                            for (SelectedRw = 0; SelectedRw < 3; SelectedRw++)
                            {
                                if (Grid[SelectedRw, 0] == Grid[SelectedRw, 1] &&
                                     Grid[SelectedRw, 1] == Grid[SelectedRw, 2])
                                {
                                    WinningRowCnt++;

                                }
                                if(WinningRowCnt == 3)
                                {
                                    Winnings = (Wager * Odds * DuoCombo) + 1;
                                }
                            }
                            break;
                        case "AV":
                            int WinningColCnt = 0;
                            int SelectedCol = 0;
                            for (SelectedCol = 0; SelectedCol < 3; SelectedCol++)
                            {
                                if (Grid[0,SelectedCol] == Grid[1, SelectedCol] && Grid[1, SelectedCol] == Grid[2, SelectedCol])
                                   {
                                    WinningColCnt++;
                                   }
                                if (WinningColCnt == 3)
                                {
                                    Winnings = (Wager * Odds * TrioCombo) + 1;
                                }
                            }
                            break;
                        case "D":
                            int WinningDiagCnt = 0;
                            int SelectedDiag = 0;
                            for (SelectedDiag = 0; SelectedDiag < 3; SelectedDiag++)
                            {
                                    if (Grid[SelectedDiag, 0] == Grid[SelectedDiag, 1] &&
                                        Grid[SelectedDiag, 1] == Grid[SelectedDiag, 2])
                                    {
                                        WinningDiagCnt++;
                                    }
                                    if(WinningDiagCnt == 3)
                                    {
                                        Winnings = (Wager * Odds * TrioCombo) + 1;
                                    }
                            }
                            break;
                        default:
                            InvalidInput = true;
                            break;
                    }
                    if (InvalidInput)
                    {
                        Console.WriteLine("Valid input please");
                    }
                }

                //display grid and winnings
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        Console.Write("{0}\t", Grid[row, col]);
                    }
                    Console.Write("\n");
                }

                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("Here are your winnings: $ " + Winnings);
                Console.WriteLine("--------------------------------------");

                string Answer = "";
                Console.Write("Do you want to play again: ");
                Answer = Console.ReadLine().ToUpper();

                PlayAgain = (Answer == "Y");

      
            }
            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }
    }
}