using System;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the slot machine!");

            //Random number generator
            Random random = new Random();
            int num1 = random.Next(9);
            int num2 = random.Next(9);
            int num3 = random.Next(9);
            int num4 = random.Next(9);
            int num5 = random.Next(9);
            int num6 = random.Next(9);
            int num7 = random.Next(9);
            int num8 = random.Next(9);
            int num9 = random.Next(9);

            int[,] array = new int[3, 3] { 
                { num1, num2, num3 }, 
                { num4, num5, num6 }, 
                { num7, num7, num8 } }; 

        }

    }
}