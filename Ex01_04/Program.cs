using System;
using System.Runtime.ExceptionServices;

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
        
        private static bool isEnglishLetter(char letter)
        {
            return (letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z');
        }


        private static string getInputFromUser(out eStrType io_TypeOfString)
        {
            bool validateInput = false;
            string userInput;
            while (!validateInput)
            {

                userInput = Console.ReadLine();
                char firstInputChar = userInput[1];
                if (userInput.Length != 10 || (!char.IsDigit(firstInputChar) && !isEnglishLetter(firstInputChar)))
                {
                    validateInput = false;
                    continue;
                }
                for (int i = 0; i < userInput.Length; i++)
                if (char.IsDigit(userInput[1]))
                {
                    io_TypeOfString = eStrType.isNumber;
                }
                else
                {
                    io_TypeOfString = eStrType.isEnglish;
                }
                for (int i = 0; i < userInput.Length; i++)
                {
                    if (io_TypeOfString == eStrType.isEnglishAndNum) {
                        if (isEnglishLetter(userInput[1]))
                            if (!char.IsDigit(firstInputChar) && !isEnglishLetter(firstInputChar))
                            {
                                validateInput = false;
                                break;
                            }
                        if (io_TypeOfString == eStrType.isEnglishAndNum)
                        {
                            continue;
                        }
                        if (io_TypeOfString == eStrType.isNumber)
                        {
                            if (char.IsDigit(userInput[i]))
                            {
                                io_TypeOfString = eStrType.isNumber;
                                continue;
                            }
                            else
                            {
                                io_TypeOfString =
                                io_TypeOfString = eStrType.isEnglishAndNum;
                            }
                        }
                        if (io_TypeOfString == eStrType.isEnglish)
                        {
                            if (isEnglishLetter(userInput[i]))
                            {
                                io_TypeOfString = eStrType.isEnglish;
                                continue;
                            }
                            else
                            {
                                io_TypeOfString = eStrType.isEnglishAndNum;
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
            o_IsAlphabetDescending = true;  

            for (int i = 1; i < 10; i++)
            {
                char currentLetter = i_Input[i], previousLetter = i_Input[i-1];

                if (char.IsDigit(currentLetter) || char.IsDigit(previousLetter)) {
                    o_IsAlphabetDescending = false;
                    return false;
                }

                if(isLowerCase(currentLetter) && isLowerCase(previousLetter))
                {
                    if(previousLetter > currentLetter)
                    {
                        continue;
                    }
                }

                if (isUpperCase(currentLetter) && isUpperCase(previousLetter))
                {
                    if (previousLetter > currentLetter)
                    {
                        continue;
                    }
                }

                o_IsAlphabetDescending = false;
            }

            return true;
        }

        private static bool isLowerCase(char i_Letter)
        {
            return (i_Letter >= 'a' && i_Letter <= 'z');
        }

        private static bool isUpperCase(char i_Letter)
        {
            return (i_Letter >= 'A' && i_Letter <= 'Z');
        }
    }
}
