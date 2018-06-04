using System;
using System.Collections;

namespace Spectrum
{
    class RandomData
    {
        public BitArray GetRandomData(int bitLength)
        {
            Random rnd = new Random();
            //BitArray bits = new BitArray(32768, false);
            BitArray bits = new BitArray(bitLength, false);
            for (int i = 0; i < bits.Length; i++)
            {
                bits.Set(i, rnd.Next(2) == 1 ? true : false);
            }
            return bits;
        }
    }
}
