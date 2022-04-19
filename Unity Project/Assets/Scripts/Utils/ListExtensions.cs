using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Nebby.CSharpUtils
{
    public static class ListExtensions
    {
        public static T GetRandomElement<T>(this IEnumerable<T> enumerable)
        {
            T[] enumAsArray = enumerable.ToArray();
            int rand = Random.Range(0, enumAsArray.Length);
            return enumAsArray[rand];
        }
    }
}