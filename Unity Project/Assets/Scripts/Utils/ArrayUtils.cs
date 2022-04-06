using System;

namespace NebbyUtils
{
    public static class ArrayUtils
    {
        public static void ArrayAppend<T>(ref T[] tArray, T element)
        {
            int length = tArray.Length;
            int newLength = length++;
            Array.Resize(ref tArray, newLength);
            tArray[newLength] = element;
        }
    }
}
