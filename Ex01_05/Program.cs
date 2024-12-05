using System;
namespace Ex01_05
{
    class Program
    {
        public static void Main(string[] args)
        {
            Ex5();
        }

        public static void Ex5()
        {
            string userInput;

            validateAndGetInput(out userInput);

            printResults(userInput);
        }

        private static void validateAndGetInput(out string o_UserInput)
        {
            while (true)
            {
                Console.WriteLine("Please enter a number with 9 digits: ");
                o_UserInput = Console.ReadLine();

                if (o_UserInput.Length != 9)
                {
                    Console.WriteLine("Wrong Input.");
                    continue;
                }
                   

                int userInput;
                bool isNumber = int.TryParse(o_UserInput, out userInput);

                if (isNumber) {
                    break;
                }
                Console.WriteLine("Wrong Input.");
            }
        }

        private static int numberOfDigitsBiggerThanUnitDigit(string i_UserInput)
        {
            char unitDigit = i_UserInput[8];
            int numberOfBiggerDigits = 0;

            for (int indexOfDigit = 0; indexOfDigit < 8; indexOfDigit++)
            {
                char currentDigit = i_UserInput[indexOfDigit];

                if (currentDigit > unitDigit)
                {
                    numberOfBiggerDigits++;
                }
            }

            return numberOfBiggerDigits;
        }

        private static int numberOfDigitsDivideByFour(string i_UserInput)
        {
            int numberOfDigitsDivideByFour = 0;

            for (int indexOfDigit = 0; indexOfDigit < 9; indexOfDigit++)
            {
                char currentDigit = i_UserInput[indexOfDigit];

                if ((currentDigit - '0') % 4 == 0)
                {
                    numberOfDigitsDivideByFour++;
                }
            }

            return numberOfDigitsDivideByFour;
        }

        private static float ratioBetweenBiggestAndSmallestDigit(string i_UserInput)
        {
            float ratioBetweenBiggestAndSmallestDigit;
            char biggestDigit, smallestDigit = '0';
            biggestDigit = i_UserInput[0];

            int indexOfDigit;

            for (indexOfDigit = 0; indexOfDigit < 9; indexOfDigit++)
            {
                char currentDigit = i_UserInput[indexOfDigit];

                if (currentDigit != '0')
                {
                    smallestDigit = currentDigit;
                    break;
                }
            }

            if(smallestDigit == '0')
                return 0;

            for (indexOfDigit = 0; indexOfDigit < 9; indexOfDigit++)
            {
                char currentDigit = i_UserInput[indexOfDigit];

                if (smallestDigit > currentDigit && currentDigit != '0')
                    smallestDigit = currentDigit;

                if (currentDigit > biggestDigit)
                    biggestDigit = currentDigit;
            }

            ratioBetweenBiggestAndSmallestDigit = (float)(biggestDigit - '0') / (smallestDigit - '0');
            return ratioBetweenBiggestAndSmallestDigit;
        }

        private static int numberOfSimilarPairDigits(string i_UserInput)
        {
            int countSimilarDigit = 0;
            char previousDigit = i_UserInput[0];
            int indexOfDigit;

            int numberOfSimilarPairDigits = 0;

            for (indexOfDigit = 0; indexOfDigit < 9; indexOfDigit++)
            { 
                char currentDigit = i_UserInput[indexOfDigit];

                if (currentDigit == previousDigit)
                    countSimilarDigit++;
                else
                {
                    numberOfSimilarPairDigits += (countSimilarDigit * (countSimilarDigit - 1)) / 2;
                    countSimilarDigit = 1;
                }

                previousDigit = currentDigit;
            }

            numberOfSimilarPairDigits += (countSimilarDigit * (countSimilarDigit - 1)) / 2;

            return numberOfSimilarPairDigits;
        }

        private static void printResults(string i_UserInput)
        {
            Console.WriteLine($"a. Number of digits bigger than the unit digit : {numberOfDigitsBiggerThanUnitDigit(i_UserInput)}");
            Console.WriteLine($"b. Number of digits divide by 4: {numberOfDigitsDivideByFour(i_UserInput)}");
            Console.WriteLine($"c. Ratio between the biggest digit and the smallest digit: {Math.Floor(ratioBetweenBiggestAndSmallestDigit(i_UserInput) * 100) / 100}");
            Console.WriteLine($"d. Number of similar digit pairs: {numberOfSimilarPairDigits(i_UserInput)}");
        }

    }
}
