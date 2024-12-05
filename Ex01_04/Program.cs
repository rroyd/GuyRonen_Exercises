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

            printResults(userInput, typeOfStr);
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
                char firstInputChar = userInput[1];
                if (userInput.Length != 10 || (!char.IsDigit(firstInputChar) && !isEnglishLetter(firstInputChar)))
                {
                    validateInput = false;
                    continue;
                }
                if (char.IsDigit(userInput[1]))
                {
                    io_TypeOfString = eStrType.IsNumber;
                }
                else
                {
                    io_TypeOfString = eStrType.IsEnglish;
                }
                validateInput = true;
                for (int i = 0; i < userInput.Length; i++)
                {

                    if (!char.IsDigit(userInput[i]) && !isEnglishLetter(userInput[i]))
                    {
                        Console.WriteLine("please enter valid string!");
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
                if (i_Input[i_LeftIterator++] != i_Input[i_RightIterator--])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool checkIfDividesByFourIfNumber(string i_Input) {
            int inputNum;
            bool isNumber = int.TryParse(i_Input, out inputNum);

            return inputNum % 4 == 0;
        }

        private static int numberOfLowercaseLettersIfEnglish(string i_Input)
        {
            int numOfLowerCaseLetters = 0;

            for (int i = 0;i<10;i++)
            {
                char currentLetter = i_Input[i];
                if (currentLetter >= 'a' && currentLetter <= 'z')
                    numOfLowerCaseLetters++;
            }

            return numOfLowerCaseLetters;
        }

        private static bool checkIfAlphabetDescendingIfEnglish(string i_Input) {
            bool isAlphabetDescending = true;  

            for (int i = 1; i < 10; i++)
            {
                char currentLetter = i_Input[i], previousLetter = i_Input[i-1];

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

                isAlphabetDescending = false;
            }

            return isAlphabetDescending;
        }

        private static bool isLowerCase(char i_Letter)
        {
            return (i_Letter >= 'a' && i_Letter <= 'z');
        }

        private static bool isUpperCase(char i_Letter)
        {
            return (i_Letter >= 'A' && i_Letter <= 'Z');
        }

        private static void printResults(string i_UserInput, eStrType i_Type)
        {
            if (isPolindrome(i_UserInput))
            {
                Console.WriteLine("1. Is the string polindrome: Yes");
            }
            else Console.WriteLine("1. Is the string polindrome: No");

            if (i_Type == eStrType.IsNumber)
                {
                    if (checkIfDividesByFourIfNumber(i_UserInput))
                    {
                        Console.WriteLine("2. Is divided by 4 without remainder: Yes");
                    } else Console.WriteLine($"2. Is divided by 4 without remainder: No");
                }
            else
            {
                 Console.WriteLine($"2. Number of lowercase letters: {numberOfLowercaseLettersIfEnglish(i_UserInput)}");
                 if(checkIfAlphabetDescendingIfEnglish(i_UserInput))
                 {
                     Console.WriteLine($"3. Is sorted alphabetically descending: Yes");
                 }
                 else Console.WriteLine($"3. Is sorted alphabetically descending: No");
            }
        }
    }
}
