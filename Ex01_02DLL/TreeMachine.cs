using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02DLL
{
    public class TreeMachine
    {
        public static void PrintTree(int i_HeightOfTree = 1, int printedLetters = 0)
        {
            if (i_HeightOfTree > 7)
                return;
            System.Console.Write($"{i_HeightOfTree}");
            if (i_HeightOfTree > 5)
            {
                System.Console.WriteLine($"                     |Z|                      ");
                PrintTree(i_HeightOfTree + 1, printedLetters);
                return;
            }

            int lowerBound = 7 - (i_HeightOfTree - 1);
            int upperBound = 7 + (i_HeightOfTree - 1);

            for (int i = 0; i < 14; i++)
            {
                if (i < lowerBound || i > upperBound)
                {
                    System.Console.Write("   ");
                }
                else
                {
                    System.Console.Write($" {(char)(65 + printedLetters)} ");
                    printedLetters++;
                }
            }
            System.Console.Write("\n");
            PrintTree(i_HeightOfTree + 1, printedLetters);
            return;
        }
    }
}
