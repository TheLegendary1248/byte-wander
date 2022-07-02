using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/// <summary>
/// This class is in charge of wander the player's PC files as level data
/// </summary>
public static class FileWanderer
{
    //@"C:\Users\1248a\Desktop"
    public static string CurrentPath { get; private set; } = @"C:\Users\1248a\Desktop";
    static HashSet<string> visited = new HashSet<string>();
    
    
    public static bool SetPath(string path)
    {
        bool exists = Directory.Exists(path);
        if (exists) CurrentPath = path;
        return exists;
    }
    /// <summary>
    /// Gets a new random path relatively close to ours
    /// </summary>
    public static void GetNewPath()
    {
        if (!Directory.Exists(CurrentPath) & !File.Exists(CurrentPath)) //If the path may have been deleted or moved while playing
        {
            throw new System.Exception($"{CurrentPath} : Path no longer exists");
            while (true)//Try to go up
            {
                //Exception handler code. DO LATER
                break;
            }
        }
        //If it's a file, use the parent directory
        if (File.Exists(CurrentPath)) CurrentPath = Directory.GetParent(CurrentPath).FullName;
        if (Random.value > 0.6) CurrentPath = Directory.GetParent(CurrentPath).FullName;
        //Get all entries in this directory
        string[] dirs = Directory.GetDirectories(CurrentPath);
        string[] files = Directory.GetFiles(CurrentPath);
        //Get random range
        int selector = Random.Range(0, dirs.Length + files.Length);
        //Add to visited
        visited.Add(CurrentPath);
        if (selector < files.Length) CurrentPath = files[selector];//Get a files
        else //Enter a new directory and get a file in it
        {
            CurrentPath = dirs[selector - files.Length];
            files = Directory.GetFiles(CurrentPath);
            selector = Random.Range(0, files.Length);
            CurrentPath = files[selector];
        }
        Debug.Log(CurrentPath);
        
    }

}
