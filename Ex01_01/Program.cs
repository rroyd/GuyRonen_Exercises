using System;
using System.Linq;

namespace Ex01_01
{
    class Program
    {
        public static void Main() 
        {
            Ex01();
        }
        public static void Ex01()
        {
            string firstNumBinaryFormat, secondNumBinaryFormat, thirdNumBinaryFormat;
            int firstNumDecimalFormat, secondNumDecimalFormat, thirdNumDecimalFormat;

            Console.WriteLine("please enter 3 binary number with 8 digits each");

            firstNumBinaryFormat = getBinaryNumberFromUser();
            secondNumBinaryFormat = getBinaryNumberFromUser();
            thirdNumBinaryFormat = getBinaryNumberFromUser();

            firstNumDecimalFormat = ParseBinaryToDecimal(firstNumBinaryFormat);
            secondNumDecimalFormat = ParseBinaryToDecimal(secondNumBinaryFormat);
            thirdNumDecimalFormat = ParseBinaryToDecimal(thirdNumBinaryFormat);

            Console.WriteLine($"{firstNumBinaryFormat} = {firstNumDecimalFormat}");
            Console.WriteLine($"{secondNumBinaryFormat} = {secondNumDecimalFormat}");
            Console.WriteLine($"{thirdNumBinaryFormat} = {thirdNumDecimalFormat}");
        }

        private static string getBinaryNumberFromUser()
        {
            string inputNumber = "";
            bool isProperNum = false;
            while (!isProperNum)
            {
                isProperNum = true;
                inputNumber = Console.ReadLine();
                if (inputNumber.Length != 8)
                {
                    Console.WriteLine("The number must be exactly 8 digits. Please try again.");
                    isProperNum = false;
                }
                for (int i = 0; i < inputNumber.Length; i++)
                {
                    if (inputNumber[i] != '0' && inputNumber[i] != '1')
                    {
                        Console.WriteLine("The number must be binary number.");
                        isProperNum = false;
                        break;
                    }
                }
            }

            return inputNumber;

        }

        private static bool isBinaryNumber(int i_BinaryNumber)
        {
            int lastDigit;
            while(i_BinaryNumber > 0)
            {
                lastDigit = i_BinaryNumber % 10;
                if( lastDigit > 1 )
                {
                    return false;
                }
                i_BinaryNumber /= 10;
            }

            return true;

        }

        private static int ParseBinaryToDecimal(string i_StringBinaryNumber)
        {
            int integerBinaryNumber;
            integerBinaryNumber = int.Parse(i_StringBinaryNumber);
            int powerOfTwo = 1;
            int DechimalNumber = 0;
            int firstDigit;
            while (integerBinaryNumber > 0)
            {
                firstDigit = integerBinaryNumber % 10;
                DechimalNumber += powerOfTwo * firstDigit;
                integerBinaryNumber /= 10;
                powerOfTwo *= 2;
            }

            return DechimalNumber;
        }
    }
}
