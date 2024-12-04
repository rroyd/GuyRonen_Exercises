using System;

namespace Ex01_04
{
    class Program
    {
        public static void Main()
        {
            Ex4();
        }

        public static void Ex4()
        {
        }

        private static string getInputFromUser()
        {
        }

        private static bool isPolindrome(string i_Str) {
            int i_LeftIterator = 0, i_RightIterator = i_Str.Length - 1;

            while (i_LeftIterator < i_RightIterator)
            {
                if (i_Str[i_LeftIterator] != i_Str[i_RightIterator])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool checkIfDividesByFourIfNumber(int i_Num, out bool o_DividesByFour) {

        }

        private static bool numberOfLowercaseLettersIfEnglish(string i_Str, out int o_NumOfLowercaseLetters)
        {

        }

        private static bool checkIfAlphabetDescendingIfEnglish(string i_Str, out bool o_IsAlphabetDescending) {

        }


    }
}
