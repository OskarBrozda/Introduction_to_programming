using System;

namespace LedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj dowolną liczbę: ");
            string numberStr = Console.ReadLine();
            char[] numberX = numberStr.ToCharArray();
            int howMany = numberStr.Length;
            string numberSpace = string.Join(' ', numberX);
            var dane = numberSpace.Split(" ");
            int[] number = new int[howMany];
            for (int i = 0; i < howMany; i++)
            {
                number[i] = int.Parse(dane[i]);
            }

            for (int i = 0; i < howMany; i++)
            {
                if (number[i] == 0) Console.Write(" _ ");
                if (number[i] == 1) Console.Write("   ");
                if (number[i] == 2) Console.Write(" _ ");
                if (number[i] == 3) Console.Write(" _ ");
                if (number[i] == 4) Console.Write("   ");
                if (number[i] == 5) Console.Write(" _ ");
                if (number[i] == 6) Console.Write(" _ ");
                if (number[i] == 7) Console.Write(" _ ");
                if (number[i] == 8) Console.Write(" _ ");
                if (number[i] == 9) Console.Write(" _ ");
            }
            Console.WriteLine();
            for (int i = 0; i < howMany; i++)
            {
                if (number[i] == 0) Console.Write("| |");
                if (number[i] == 1) Console.Write("  |");
                if (number[i] == 2) Console.Write(" _|");
                if (number[i] == 3) Console.Write(" _|");
                if (number[i] == 4) Console.Write("|_|");
                if (number[i] == 5) Console.Write("|_ ");
                if (number[i] == 6) Console.Write("|_ ");
                if (number[i] == 7) Console.Write("  |");
                if (number[i] == 8) Console.Write("|_|");
                if (number[i] == 9) Console.Write("|_|");
            }
            Console.WriteLine();
            for (int i = 0; i < howMany; i++)
            {
                if (number[i] == 0) Console.Write("|_|");
                if (number[i] == 1) Console.Write("  |");
                if (number[i] == 2) Console.Write("|_ ");
                if (number[i] == 3) Console.Write(" _|");
                if (number[i] == 4) Console.Write("  |");
                if (number[i] == 5) Console.Write(" _|");
                if (number[i] == 6) Console.Write("|_|");
                if (number[i] == 7) Console.Write("  |");
                if (number[i] == 8) Console.Write("|_|");
                if (number[i] == 9) Console.Write("  |");
            }
        }
    }
}