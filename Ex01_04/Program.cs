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
            eStrType typeOfStr = eStrType.None;
            string userInput;
            userInput = getInputFromUser(out typeOfStr);
            Console.WriteLine(userInput);
            Console.WriteLine(typeOfStr);
            isPolindrome(userInput);

        }
        [Flags]
        enum eStrType
        {
            None = 0,
            IsEnglish = 1,
            IsNumber = 2,
            IsEnglishAndNum = IsNumber | IsEnglish
        }
        

        private static string getInputFromUser(out eStrType io_TypeOfString)
        {
            io_TypeOfString = eStrType.None;
            const int requiredInputLength = 10;
            bool validateInput = false;
            string userInput="";
            while (!validateInput)
            {
                io_TypeOfString = eStrType.None;
                validateInput = true;
                Console.WriteLine("please write valid string of 10 chars with english and numbers");
                userInput = Console.ReadLine();
                if (userInput.Length != requiredInputLength)
                {
                    validateInput = false;
                    continue;
                }
                for (int i = 0; i < userInput.Length; i++)
                {
                    validateInput = validateAndDetermineInputState(userInput[i], ref io_TypeOfString);
                    if (!validateInput)
                    {
                        Console.WriteLine("please enter valid string!");
                        io_TypeOfString = eStrType.None;
                        break;
                    }
                }
            }

            return userInput;
        }
        private static bool validateAndDetermineInputState(char i_InputChar, ref eStrType io_CourrentInputState)
        {
            bool isValidateChar = true;
            bool isEnglish = isEnglishLetter(i_InputChar);
            bool isDigit = char.IsDigit(i_InputChar);
            if (isEnglish)
            {
                io_CourrentInputState |= eStrType.IsEnglish;
            }
            if (isDigit)
            {
                io_CourrentInputState |= eStrType.IsNumber;
            }
            if (!isEnglish && !isDigit)
            {
                isValidateChar = false;
            }

            return isValidateChar;
        }
        private static bool isEnglishLetter(char letter)
        {
            return (letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z');
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

                if(currentLetter >= 'a' && currentLetter <= 'z' && previousLetter >= 'a' && previousLetter <= 'z')
                {
                    if(previousLetter > currentLetter)
                    {
                        continue;
                    }
                }

                if (currentLetter >= 'A' && currentLetter <= 'Z' && previousLetter >= 'A' && previousLetter <= 'Z')
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

    }
}
