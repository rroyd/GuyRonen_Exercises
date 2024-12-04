using System;
namespace Ex01_05
{
    class Program
    {
        public static void Main(string[] args)
        {
            int x;
            Console.WriteLine(int.TryParse("5dssddsd6", out x));
            Console.WriteLine(x);
        }
    }
}
