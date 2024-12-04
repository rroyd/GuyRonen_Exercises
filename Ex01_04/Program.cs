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
            getInputFromUser();
        }
        enum eStrType
        {
            isEnglishAndNum = 0,
            isEnglish,
            isNumber
        }
        
        private static string getInputFromUser(out eStrType io_TypeOfString)
        {
            bool v_ValidateInput = true;

            string userInput;
            while (!v_ValidateInput)
            {
                userInput = Console.ReadLine();
                if (userInput.Length != 10)
                {
                    continue;
                }
                for (int i = 0; i < userInput.Length; i++) 
                {
                    if(io_TypeOfString == eStrType.isEnglishAndNum) {
                        if (isEnglishLetter(userInput[1]))
                        {
                            io_TypeOfString = 
                        }

                }
            }

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
