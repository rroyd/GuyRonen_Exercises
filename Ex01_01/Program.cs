using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Ex01_01
{
    class Program
    {
        public static void Main() 
        {
            Ex01();
            Console.WriteLine("sahar");
        }
        public static void Ex01()
        {
            string firstNumBinaryFormat, secondNumBinaryFormat, thirdNumBinaryFormat;
            int firstNumDecimalFormat, secondNumDecimalFormat, thirdNumDecimalFormat;

            Console.WriteLine("please enter 3 binary number with 8 digits each");

            firstNumBinaryFormat = getBinaryNumberFromUser();
            secondNumBinaryFormat = getBinaryNumberFromUser();
            thirdNumBinaryFormat = getBinaryNumberFromUser();

            firstNumDecimalFormat = parseBinaryToDecimalNumber(firstNumBinaryFormat);
            secondNumDecimalFormat = parseBinaryToDecimalNumber(secondNumBinaryFormat);
            thirdNumDecimalFormat = parseBinaryToDecimalNumber(thirdNumBinaryFormat);

            printAscendingNumbers(firstNumDecimalFormat, secondNumDecimalFormat, thirdNumDecimalFormat);
            printAvg(firstNumDecimalFormat, secondNumDecimalFormat, thirdNumDecimalFormat);
            printLargestSequenceBits(firstNumBinaryFormat, secondNumBinaryFormat, thirdNumBinaryFormat);
            printNumberOfBitExchanges(firstNumBinaryFormat, secondNumBinaryFormat, thirdNumBinaryFormat);
            printMostZeroesNumber(firstNumBinaryFormat, secondNumBinaryFormat, thirdNumBinaryFormat);
        }

        private static void printMostZeroesNumber(string i_FirstNumBinary, string i_SecondNumBinary, string i_ThirdNumBinary)
        {
            int maxZeroesCount;
            int maxZeroesDecimalNumber;
            string maxZeroesBinaryNumStr;
            int firstNumZeroesCount = countZerosInNum(i_FirstNumBinary);
            maxZeroesCount = firstNumZeroesCount;
            maxZeroesBinaryNumStr = i_FirstNumBinary;
            int secondNumZeroesCount = countZerosInNum(i_SecondNumBinary);
            if(secondNumZeroesCount > maxZeroesCount)
            {
                maxZeroesCount = secondNumZeroesCount;
                maxZeroesBinaryNumStr = i_SecondNumBinary;
            }
            int thirdNumZeroesCount = countZerosInNum(i_ThirdNumBinary);
            if (thirdNumZeroesCount > maxZeroesCount)
            {
                maxZeroesCount = thirdNumZeroesCount;
                maxZeroesBinaryNumStr = i_ThirdNumBinary;
             }
            maxZeroesDecimalNumber = parseBinaryToDecimalNumber(maxZeroesBinaryNumStr);
            Console.WriteLine($"{maxZeroesDecimalNumber}: {maxZeroesCount}");
        }

        private static int countZerosInNum(string i_BinaryNum)
        {
            int count = 0;
            foreach(char c in i_BinaryNum)
            {
                if (c == '0')
                {
                    count++;
                }
            }

            return count;
        }

        private static void printNumberOfBitExchanges(string i_FirstNumBinary, string i_SecondNumBinary, string i_ThirdNumBinary)
        {
            Console.WriteLine($"({i_FirstNumBinary}): {numberOfBitExchanges(i_FirstNumBinary)}");
            Console.WriteLine($"({i_SecondNumBinary}): {numberOfBitExchanges(i_SecondNumBinary)}");
            Console.WriteLine($"({i_ThirdNumBinary}): {numberOfBitExchanges(i_ThirdNumBinary)}");
        }

        private static int numberOfBitExchanges(string i_BinaryNum)
        {
            int numOfExchanges = 0;
            for (int i = 1; i < i_BinaryNum.Length; i++)
            {
                if (i_BinaryNum[i - 1] != i_BinaryNum[i])
                {
                    numOfExchanges++;
                }
            }
            return numOfExchanges;
        }

        private static void printLargestSequenceBits(string i_FirstNumBinary, string i_SecondNumBinary, string i_ThirdNumBinary)
        {
            int mostSqeuenceBits;
            int tempSqeuenceBits;
            string mostSqeuenceBitsNumStr;
            mostSqeuenceBits = findSequenceBits(i_FirstNumBinary);
            mostSqeuenceBitsNumStr = i_FirstNumBinary;
            tempSqeuenceBits = findSequenceBits(i_SecondNumBinary);
            if(tempSqeuenceBits > mostSqeuenceBits)
            {
                mostSqeuenceBits = tempSqeuenceBits;
                mostSqeuenceBitsNumStr = i_SecondNumBinary;
            }
            tempSqeuenceBits = findSequenceBits(i_ThirdNumBinary);
            if (tempSqeuenceBits > mostSqeuenceBits)
            {
                mostSqeuenceBits = tempSqeuenceBits;
                mostSqeuenceBitsNumStr = i_ThirdNumBinary;
            }
            Console.WriteLine($"{mostSqeuenceBitsNumStr}:{mostSqeuenceBits}");
        }

        private static int findSequenceBits(string i_BinaryNum)
        {
            int maxSequence = 0;
            int sequence = 1;
            for(int i = 1; i < i_BinaryNum.Length; i++)
            {
                if (i_BinaryNum[i - 1] == i_BinaryNum[i])
                {
                    sequence++;
                }
                else
                {
                    maxSequence = Math.Max(maxSequence, sequence);
                    sequence = 1;
                }
            }
            maxSequence = Math.Max(maxSequence, sequence);

            return maxSequence;
        }

        private static void printAvg(int firstNum, int secondNum, int thirdNum)
        {
            float avgNumber = ((firstNum + secondNum + thirdNum) / 3f);
            Console.WriteLine($"the avg number is:{avgNumber:F2}");
        }

        private static void printAscendingNumbers(int firstNum, int secondNum, int thirdNum)
        {
            int min = Math.Min(firstNum, Math.Min(secondNum, thirdNum));
            int max = Math.Max(firstNum, Math.Max(secondNum, thirdNum));
            int mid = (firstNum + secondNum + thirdNum - min - max);
            Console.WriteLine($"sorted numbers: {min}, {mid}, {max}");
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
                    continue;
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

        private static int parseBinaryToDecimalNumber(string i_StringBinaryNumber)
        {
            int integerBinaryNumber;
            int powerOfTwo = 1;
            int decimalNumber = 0;
            int currentDigit; 
            integerBinaryNumber = int.Parse(i_StringBinaryNumber);
            while (integerBinaryNumber > 0)
            {
                currentDigit = integerBinaryNumber % 10;
                decimalNumber += powerOfTwo * currentDigit;
                integerBinaryNumber /= 10;
                powerOfTwo = (int)Math.Pow(powerOfTwo, 2);
            }

            return decimalNumber;
        }
    }
}
