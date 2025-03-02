﻿using System;

namespace UntieUnite.Core
{
    /// <summary>
    /// Borrowed (with permission) from PKHeX.
    /// </summary>
    /// <remarks>Because Big Endian byte ordering confuses reverse engineers? (no).</remarks>
    public static class BigEndian
    {
        public static ulong ToUInt64(byte[] data, int offset)
        {
            ulong val = 0;
            val |= (ulong)data[offset + 0] << 56;
            val |= (ulong)data[offset + 1] << 48;
            val |= (ulong)data[offset + 2] << 40;
            val |= (ulong)data[offset + 3] << 32;
            val |= (ulong)data[offset + 4] << 24;
            val |= (ulong)data[offset + 5] << 16;
            val |= (ulong)data[offset + 6] << 8;
            val |= (ulong)data[offset + 7];
            return val;
        }

        public static uint ToUInt32(byte[] data, int offset)
        {
            int val = 0;
            val |= data[offset + 0] << 24;
            val |= data[offset + 1] << 16;
            val |= data[offset + 2] << 8;
            val |= data[offset + 3];
            return (uint)val;
        }

        public static ushort ToUInt16(byte[] data, int offset)
        {
            int val = 0;
            val |= data[offset + 0] << 8;
            val |= data[offset + 1];
            return (ushort)val;
        }

        public static long ToInt64(byte[] data, int offset)
        {
            ulong val = 0;
            val |= (ulong)data[offset + 0] << 56;
            val |= (ulong)data[offset + 1] << 48;
            val |= (ulong)data[offset + 2] << 40;
            val |= (ulong)data[offset + 3] << 32;
            val |= (ulong)data[offset + 4] << 24;
            val |= (ulong)data[offset + 5] << 16;
            val |= (ulong)data[offset + 6] << 8;
            val |= (ulong)data[offset + 7];
            return (long)val;
        }

        public static int ToInt32(byte[] data, int offset)
        {
            int val = 0;
            val |= data[offset + 0] << 24;
            val |= data[offset + 1] << 16;
            val |= data[offset + 2] << 8;
            val |= data[offset + 3];
            return val;
        }

        public static short ToInt16(byte[] data, int offset)
        {
            int val = 0;
            val |= data[offset + 0] << 8;
            val |= data[offset + 1];
            return (short)val;
        }

        public static byte[] GetBytes(long value)
        {
            return Invert(BitConverter.GetBytes(value));
        }

        public static byte[] GetBytes(int value)
        {
            return Invert(BitConverter.GetBytes(value));
        }

        public static byte[] GetBytes(short value)
        {
            return Invert(BitConverter.GetBytes(value));
        }

        public static byte[] GetBytes(ulong value)
        {
            return Invert(BitConverter.GetBytes(value));
        }

        public static byte[] GetBytes(uint value)
        {
            return Invert(BitConverter.GetBytes(value));
        }

        public static byte[] GetBytes(ushort value)
        {
            return Invert(BitConverter.GetBytes(value));
        }

        private static byte[] Invert(byte[] data)
        {
            int i = 0;
            int j = 0 + data.Length - 1;
            while (i < j)
            {
                var temp = data[i];
                data[i] = data[j];
                data[j] = temp;
                i++;
                j--;
            }
            return data;
        }

        /// <summary>
        /// Swaps byte ordering in a byte array based on 32bit value writes.
        /// </summary>
        /// <remarks>The <see cref="data"/> is reversed in-place.</remarks>
        public static void SwapBytes32(byte[] data)
        {
            for (int i = 0; i < data.Length; i += 4)
            {
                byte tmp = data[0 + i];
                data[0 + i] = data[3 + i];
                data[3 + i] = tmp;

                byte tmp1 = data[1 + i];
                data[1 + i] = data[2 + i];
                data[2 + i] = tmp1;
            }
        }
    }
}
