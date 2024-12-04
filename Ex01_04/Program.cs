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
                    if (io_TypeOfString == eStrType.isEnglishAndNum)
                    {
                        if (isEnglishLetter(userInput[i]))
                        {
                            io_TypeOfString
                        }

                    }
                }

            }
        }

        private static bool isPolindrome(string i_Input) {
            int i_LeftIterator = 0, i_RightIterator = 9;

            while (i_LeftIterator < i_RightIterator)
            {
                if (i_Input[i_LeftIterator] != i_Input[i_RightIterator])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool checkIfDividesByFourIfNumber(string i_Input, out bool o_DividesByFour) {
            int inputNum;
            bool isNumber = int.TryParse(i_Input, out inputNum);

            if(!isNumber)
            {
                o_DividesByFour = false;
                return false;
            }

            o_DividesByFour = true;
            return inputNum % 4 == 0;
        }

        private static bool numberOfLowercaseLettersIfEnglish(string i_Input, out int o_NumOfLowercaseLetters)
        {
            o_NumOfLowercaseLetters = 0;

            for (int i = 0;i<10;i++)
            {
                char currentLetter = i_Input[i];
                if (char.IsDigit(currentLetter))
                {
                    return false;
                }
                if (currentLetter >= 'a' && currentLetter <= 'z')
                    o_NumOfLowercaseLetters++;
            }

            return true;
        }

        private static bool checkIfAlphabetDescendingIfEnglish(string i_Input, out bool o_IsAlphabetDescending) {

        }


    }
}
