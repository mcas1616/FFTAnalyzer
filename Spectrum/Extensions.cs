using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum
{
    public static class Extensions
    {
        public static byte ToMin(this byte[] bytes)
        {
            byte minValue = new byte();

            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] < minValue)
                {
                    minValue = bytes[i];
                }
            }
            return minValue;
        }

        public static byte ToMax(this byte[] bytes)
        {
            byte maxValue = new byte();

            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] > maxValue)
                {
                    maxValue = bytes[i];
                }
            }
            return maxValue;
        }

        public static string ToStr(this byte[] bytes)
        {
            string retrnString = "";
            foreach (var value in bytes)
            {
                retrnString += value + "/";
            }
            return retrnString;
        }

        public static byte[] ToByteArray(this BitArray bits)
        {
            int numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;

            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }

            return bytes;
        }

        public static string ToStr(this BitArray randBitArray)
        {
            string retrnString = "";

            for (int i = 0; i < randBitArray.Length; i++)
            {
                if (randBitArray[i] == true)
                {
                    retrnString += "1";
                }
                else
                {
                    retrnString += "0";
                }

                if (i % 8 == 7)
                {
                    retrnString += "/";
                }
            }
            return retrnString;
        }

        public static double[] ToDoubleArray(this byte[] bytes)
        {
            double[] doubles = new double[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
                doubles[i] = Convert.ToDouble(bytes[i]);
            return doubles;
        }
    }
}
