using System;
using System.Text;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            Ex03();
        }

        private static void Ex03()
        {
            StringBuilder lettersTree = new StringBuilder();
            int treeHeight = getInputFromUser();
            Ex01_02.Program.makeLettersTree(ref lettersTree, treeHeight);
            Console.WriteLine(lettersTree.ToString());
        }

        private static int getInputFromUser()
        {
            bool validInput;
            int treeHeight;
            string userInput;
            do 
            {
                Console.WriteLine("Please write height tree between 1-15");
                userInput = Console.ReadLine();
                validInput = int.TryParse(userInput, out treeHeight);
            }
            while (!validInput);
            return treeHeight;
        }
    }

}
