using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/// <summary>
/// This class is in charge of wander the player's PC files as level data
/// </summary>
public static class FileWanderer
{
    static string CurrentPath;
    
    public static void SetPath(string path) => CurrentPath = path;
    /// <summary>
    /// Gets a new random path relatively close to ours
    /// </summary>
    static void GetNewPath()
    {
        string path = Path.GetDirectoryName(CurrentPath);
        CurrentPath = path;
    }

}
