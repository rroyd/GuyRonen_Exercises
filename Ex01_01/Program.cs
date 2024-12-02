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
            printExchangesNumber(firstNumBinaryFormat, secondNumBinaryFormat, thirdNumBinaryFormat);
            printMostZeroesAndOnes(firstNumBinaryFormat, secondNumBinaryFormat, thirdNumBinaryFormat);
          
        }

        private static void printMostZeroesAndOnes(string i_FirstNumBinary, string i_SecondNumBinary, string i_ThirdNumBinary)
        {
            int maxZeroesCount;
            int maxZeroesDecimalNumber;
            string maxZeroesBinaryNumber;
            int firstNumZeroesCount = countZerosInNum(i_FirstNumBinary);
            maxZeroesCount = firstNumZeroesCount;
            maxZeroesBinaryNumber = i_FirstNumBinary;
            int secondNumZeroesCount = countZerosInNum(i_SecondNumBinary);
            if(secondNumZeroesCount > maxZeroesCount)
            {
                maxZeroesCount = secondNumZeroesCount;
                maxZeroesBinaryNumber = i_SecondNumBinary;
            }
            int thirdNumZeroesCount = countZerosInNum(i_ThirdNumBinary);
            if (thirdNumZeroesCount > maxZeroesCount)
            {
                maxZeroesCount = thirdNumZeroesCount;
                maxZeroesBinaryNumber = i_ThirdNumBinary;
             }
            maxZeroesDecimalNumber = parseBinaryToDecimalNumber(maxZeroesBinaryNumber);
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

        private static void printExchangesNumber(string i_FirstNumBinary, string i_SecondNumBinary, string i_ThirdNumBinary)
        {
            Console.WriteLine($"({i_FirstNumBinary}): {exchangesNumber(i_FirstNumBinary)}");
            Console.WriteLine($"({i_SecondNumBinary}): {exchangesNumber(i_SecondNumBinary)}");
            Console.WriteLine($"({i_ThirdNumBinary}): {exchangesNumber(i_ThirdNumBinary)}");
        }

        private static int exchangesNumber(string i_BinaryNum)
        {
            int exchanges = 0;
            for (int i = 1; i < i_BinaryNum.Length; i++)
            {
                if (i_BinaryNum[i - 1] != i_BinaryNum[i])
                {
                    exchanges++;
                }
            }
            return exchanges;
        }

        private static void printLargestSequenceBits(string i_FirstNumBinary, string i_SecondNumBinary, string i_ThirdNumBinary)
        {
            int mostSqeuenceBits;
            int tempSqeuenceBits;
            string mostSqeuenceBitsNumber;
            mostSqeuenceBits = findSequenceBits(i_FirstNumBinary);
            mostSqeuenceBitsNumber = i_FirstNumBinary;
            tempSqeuenceBits = findSequenceBits(i_SecondNumBinary);
            if(tempSqeuenceBits > mostSqeuenceBits)
            {
                mostSqeuenceBits = tempSqeuenceBits;
                mostSqeuenceBitsNumber = i_SecondNumBinary;
            }
            tempSqeuenceBits = findSequenceBits(i_ThirdNumBinary);
            if (tempSqeuenceBits > mostSqeuenceBits)
            {
                mostSqeuenceBits = tempSqeuenceBits;
                mostSqeuenceBitsNumber = i_ThirdNumBinary;
            }
            Console.WriteLine($"{mostSqeuenceBitsNumber}:{mostSqeuenceBits}");
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
                    if(sequence > maxSequence)
                    {
                        maxSequence = sequence;
                    }
                    sequence = 1;
                }
            }
            if (sequence > maxSequence)
            {
                maxSequence = sequence;
            }
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

        private static int parseBinaryToDecimalNumber(string i_StringBinaryNumber)
        {
            int integerBinaryNumber;
            int powerOfTwo = 1;
            int DechimalNumber = 0;
            int firstDigit;
            integerBinaryNumber = int.Parse(i_StringBinaryNumber);
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
