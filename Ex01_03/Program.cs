using Ex01_02;
namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            string heightOfTreeStr;
            int heightOfTree;
            while (true)
            {
                System.Console.WriteLine("Please enter the height of the tree you wish to print: ");
                heightOfTreeStr = System.Console.ReadLine();

                heightOfTree = int.Parse(heightOfTreeStr);

                if (heightOfTree < 0 || heightOfTree > 15)
                {
                    System.Console.WriteLine("Please enter a valid height of the tree (0-15): ");
                }
                else break;
            }

            Ex02.PrintTree(heightOfTree);
        }
    }
}
