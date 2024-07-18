using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{


    /// <summary>
    /// Will grab and return a random element from any given list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">List to grab random item from</param>
    /// <returns></returns>
    public static T RandomFromList<T>(this IList<T> list){
        return list[Random.Range(0, list.Count)];
    }
}
