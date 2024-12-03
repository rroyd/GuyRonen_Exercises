namespace Ex01_02
{
    public class Ex02
    {
       public static void Main()
       {
            PrintTree(7);
       }
        public static void PrintTree(int i_TotalHeightOfTree,int i_CurrentHeightOfTree = 1, int i_letterOffset = 0)
        {
            if (i_CurrentHeightOfTree > i_TotalHeightOfTree)
                return;
            
            if(i_CurrentHeightOfTree > 9)
            {
                System.Console.Write($"{i_CurrentHeightOfTree}");
            }
            else System.Console.Write($"{i_CurrentHeightOfTree} ");

            if (i_CurrentHeightOfTree > i_TotalHeightOfTree - 2)
            {
                for(int i = 0; i < i_letterOffset * 2; i++)
                {
                    if(i == (i_letterOffset / 2))
                    {
                        System.Console.Write($"|{(char)(65 + (i_letterOffset % 26))}|");
                    }
                    else System.Console.Write("  ");
                }
                System.Console.Write("\n");
                PrintTree(i_TotalHeightOfTree, i_CurrentHeightOfTree + 1, i_letterOffset);
                return;
            }

            int lowerBound = i_TotalHeightOfTree - (i_CurrentHeightOfTree - 1);
            int upperBound = i_TotalHeightOfTree + (i_CurrentHeightOfTree - 1);

            for (int i = 0; i < i_TotalHeightOfTree * 2; i++)
            {
                if (i < lowerBound || i > upperBound)
                {
                    System.Console.Write("   ");
                }
                else
                {
                    System.Console.Write($" {(char)(65 + (i_letterOffset % 26))} ");
                    i_letterOffset++;
                }
            }

            System.Console.Write("\n");
            PrintTree(i_TotalHeightOfTree, i_CurrentHeightOfTree + 1, i_letterOffset);
            return;
        }
    }
}
