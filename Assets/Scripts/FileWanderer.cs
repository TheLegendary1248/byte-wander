using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/// <summary>
/// This class is in charge of wander the player's PC files as level data
/// </summary>
public static class FileWanderer
{
    static string CurrentPath = "C:\\Users\\1248a\\Desktop";
    
    public static void SetPath(string path) => CurrentPath = path;
    /// <summary>
    /// Gets a new random path relatively close to ours
    /// </summary>
    public static void GetNewPath()
    {
        string[] dirs = Directory.GetDirectories(CurrentPath);
        for (int i = 0; i < dirs.Length; i++)
        {
            Debug.Log(dirs[i]);
        }
        dirs = Directory.GetFiles(CurrentPath);
        for (int i = 0; i < dirs.Length; i++)
        {
            Debug.Log(dirs[i]);
        }
        return;
        string path = Path.GetDirectoryName(CurrentPath);
        CurrentPath = path;
    }

}
