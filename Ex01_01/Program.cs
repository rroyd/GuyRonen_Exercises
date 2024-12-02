using System;

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
            int firstNumBinaryFormat, secondNumBinaryFormat, thirdNumBinaryFormat;
            int firstNumDecimalFormat, secondNumDecimalFormat, thirdNumDecimalFormat;

            Console.WriteLine("please enter 3 binary number with 8 digits each");

            firstNumBinaryFormat = getBinaryNumberFromUser(out firstNumDecimalFormat);
            secondNumBinaryFormat = getBinaryNumberFromUser(out secondNumDecimalFormat);
            thirdNumBinaryFormat = getBinaryNumberFromUser(out thirdNumDecimalFormat);

            Console.WriteLine($"{firstNumBinaryFormat} = {firstNumDecimalFormat}");
            Console.WriteLine($"{secondNumBinaryFormat} = {secondNumDecimalFormat}");
            Console.WriteLine($"{thirdNumBinaryFormat} = {thirdNumDecimalFormat}");
        }

        private static int getBinaryNumberFromUser(out int o_NumDecimalFormat)
        {
            int binaryNumber = 0;
            o_NumDecimalFormat = 0;
            string inputNumber;
            bool isProperNum = false;
            bool isNumber = false;
            bool isBinary = false;
            while (!isProperNum)
            {
                inputNumber = Console.ReadLine();
                if(inputNumber.Length != 8)
                {
                    Console.WriteLine("The number must be exactly 8 digits. Please try again.");
                    continue;
                }
                isNumber = int.TryParse(inputNumber, out binaryNumber);
                if (!isNumber)
                {
                    Console.WriteLine("That's not a number.");
                    continue;
                }
                isBinary = TryParseBinaryToDecimal(binaryNumber,out o_NumDecimalFormat);

                if (!isBinary)
                {
                    Console.WriteLine("The number must be binary number.");
                    continue;
                }
                isProperNum = true;
            }
            return binaryNumber;
        }

        private static bool TryParseBinaryToDecimal(int i_BinaryNumber, out int io_DechimalNumber)
        {
            int powerOfTwo = 1;
            io_DechimalNumber = 0;
            int firstDigit;
            while (i_BinaryNumber > 0)
            {
                firstDigit = i_BinaryNumber % 10;
                if (firstDigit > 1)
                {
                    io_DechimalNumber = 0; //failed to parse
                    return false;
                }
                io_DechimalNumber += powerOfTwo * firstDigit;
                i_BinaryNumber /= 10;
                powerOfTwo *= 2;
            }

            return true;
        }
    }
}
