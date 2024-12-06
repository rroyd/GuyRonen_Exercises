using System;
using System.Text;

namespace Ex01_02
{
    public class Ex02
    {
       public static void Main()
       {
            Ex2();
        }
        public static void Ex2()
        {
            StringBuilder treeLetters = new StringBuilder();
            int height = 7;
            makeLettersTree(ref treeLetters, height);
            Console.WriteLine(treeLetters.ToString());
        }
        public static void makeLettersTree(ref StringBuilder io_TreeLetters, int i_Height,int i_CurrentHeight = 0)
        {
            int currentAsci = i_CurrentHeight*i_CurrentHeight;
            if (i_Height-2 == i_CurrentHeight)
            {
                addTrunk(ref io_TreeLetters, i_CurrentHeight,currentAsci);
                return;
            }
            io_TreeLetters.Append(string.Format("{0,-3}",(i_CurrentHeight + 1).ToString() + "."));
            addSpaces(ref io_TreeLetters,i_Height-i_CurrentHeight, i_CurrentHeight);
            for (int i = 0;i <= i_CurrentHeight*2; i++)
            {
                io_TreeLetters.Append((char)('A' + (currentAsci++ % 26)));

            }
            io_TreeLetters.AppendLine("");
            makeLettersTree(ref io_TreeLetters, i_Height, i_CurrentHeight+1);
           
        }

        private static void addTrunk(ref StringBuilder io_TreeLetters, int i_CurrentHeight,int i_CurrentAsci)
        {
            io_TreeLetters.Append(string.Format("{0,-3}", (i_CurrentHeight + 1).ToString() + "."));
            addSpaces(ref io_TreeLetters, i_CurrentHeight + 1, i_CurrentHeight + 1);
            io_TreeLetters.Append("|" + (char)('A' + (i_CurrentAsci % 26)) + "|");
            io_TreeLetters.AppendLine("");
            io_TreeLetters.Append(string.Format("{0,-3}", (i_CurrentHeight + 2).ToString() + "."));
            addSpaces(ref io_TreeLetters, i_CurrentHeight + 1, i_CurrentHeight + 2);
            io_TreeLetters.Append("|"+ (char)('A' + (i_CurrentAsci % 26))+ "|");
        }
        private static void addSpaces(ref StringBuilder io_TreeLetters, int i_SpaceLength,int i_CurrentHeight)
        {
            for (int i = 0; i < i_SpaceLength; i++)
            {
                io_TreeLetters.Append(" ");
            }

        }
    }
}
