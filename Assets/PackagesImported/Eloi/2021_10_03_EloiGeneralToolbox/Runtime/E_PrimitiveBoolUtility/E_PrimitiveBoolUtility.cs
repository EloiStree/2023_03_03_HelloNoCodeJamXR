using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{

    public class E_PrimitiveBoolUtility
    {

        public static void SetBit(ref int theInt, in int bitPosition, in bool value)
        {
            if (value) theInt |= (1 << bitPosition);
            else theInt &= ~(1 << bitPosition);
        }
        public static void Set(ref byte theInt, in int bitPosition, in bool value)
        {
            int temp = theInt;
            if (value) temp |= (1 << bitPosition);
            else temp &= ~(1 << bitPosition);
            theInt = (byte)temp;

        }

        private static int[] _0to8 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        public static void ByteTo8Bits(in byte byteToParse, 
            out bool v0, 
            out bool v1, 
            out bool v2, 
            out bool v3, 
            out bool v4, 
            out bool v5,
            out bool v6, 
            out bool v7)
        {
            v0 = GetBit(in byteToParse, in _0to8[0]);
            v1 = GetBit(in byteToParse, in _0to8[1]);
            v2 = GetBit(in byteToParse, in _0to8[2]);
            v3 = GetBit(in byteToParse, in _0to8[3]);
            v4 = GetBit(in byteToParse, in _0to8[4]);
            v5 = GetBit(in byteToParse, in _0to8[5]);
            v6 = GetBit(in byteToParse, in _0to8[6]);
            v7 = GetBit(in byteToParse, in _0to8[7]);
        }

        public static bool GetBit(in byte b, in int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;
        }
        public static bool GetBit(in int b, in int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;
        }

        public static void TwoBytesToUshort(in byte first, in byte second, out ushort value) {

           value =  BitConverter.ToUInt16(new byte[2] { first, second }, 0);
        }
        public static void UshortToTwoBytes(in ushort value, out byte b1, out byte b2)
        {
            b1 = (byte)(value & 0xFF);
            b2 = (byte)((value >> 8) & 0xFF);
        }

        public static void IntToFourBytes(in int value, out byte b1, out byte b2, out byte b3, out byte b4)
        {
            b1 = (byte)(value & 0xFF);
            b2 = (byte)((value >> 8) & 0xFF);
            b3 = (byte)((value >> 16) & 0xFF);
            b4 = (byte)((value >> 24) & 0xFF);

        }

      

        public static void IntToFourBytes(in uint value, out byte b1, out byte b2, out byte b3, out byte b4)
        {
            b1 = (byte)(value & 0xFF);
            b2 = (byte)((value >> 8) & 0xFF);
            b3 = (byte)((value >> 16) & 0xFF);
            b4 = (byte)((value >> 24) & 0xFF);

        }


        public static void FourBytesToInt(in byte b1, in byte b2, in byte b3, in byte b4, out int value)
        {
            value = 0;
            value += (int)b1;
            value += (int)(b2 << 8);
            value += (int)(b3 << 16);
            value += (int)(b4 << 24);
        }
        public static void FourBytesToUInt(in byte b1, in byte b2, in byte b3, in byte b4, out uint value)
        {
            value = 0;
            value += (uint)b1;
            value += (uint)(b2 << 8);
            value += (uint)(b3 << 16);
            value += (uint)(b4 << 24);
        }

        public static void IntTo32Bits(in int int32Bits, out bool[] intAs32Booleans)
        {
            intAs32Booleans = new bool[32];
            for (int i = 0; i < 32; i++)
            {
                intAs32Booleans[i] = GetBit(
                    in int32Bits, in i);
            }
        }
        public static void IntTo32BitsRef(in int int32Bits, ref bool[] intAs32Booleans)
        {
            if(intAs32Booleans==null )
            intAs32Booleans = new bool[32];
            for (int i = 0; i < 32; i++)
            {
                if(i< intAs32Booleans.Length)
                intAs32Booleans[i] = GetBit(
                    in int32Bits, in i);
            }
        }

        public static void LongToEightBytes(in long now, out byte v0, out byte v1, out byte v2, out byte v3, out byte v4, out byte v5, out byte v6, out byte v7)
        {
            byte[] b = LongToBytes(now);
            v0 = b[0];
            v1 = b[1];
            v2 = b[2];
            v3 = b[3];
            v4 = b[4];
            v5 = b[5];
            v6 = b[6];
            v7 = b[7];
        }
        public static void EightBytesToLong(in byte p0, in byte p1, in byte  p2, in byte  p3, in byte  p4, in byte  p5, in byte  p6, in byte  p7,  out long value)
        {
           value = BytesToLong(new byte[] { p0, p1, p2, p3, p4, p5, p6, p7 });
        }
        public static byte[] LongToBytes(in long longGiven)
        {
            long l = longGiven;
            byte[] result = new byte[8];
            for (int i = 7; i >= 0; i--)
            {
                result[i] = (byte)(l & 0xFF);
                l >>= 8;
            }
            return result;
        }

        public static long BytesToLong(in byte[] b)
        {
            long result = 0;
            for (int i = 0; i < 8; i++)
            {
                result <<= 8;
                result |= (b[i] & 0xFF);
            }
            return result;
        }


    }
}
