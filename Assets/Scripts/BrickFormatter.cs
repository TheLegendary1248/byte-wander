using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class represents the abstract structure for formatting arbitrary bytes into level data
/// </summary>
public abstract class BrickFormatter
{
    public abstract Brick Load(byte[] d);
}
