using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class represents the abstract structure for formatting arbitrary bytes into level data
/// </summary>
public abstract class BrickFormatter
{
    /// <summary>
    /// This method represents the loading section of the formatter
    /// </summary>
    /// <param name="space">The space provided in the given section in brick units</param>
    public static void Load(int[] space) { }
}
