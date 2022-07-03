using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
/// <summary>
/// This class is in charge of wander the player's PC files as level data
/// </summary>
public static class FileWanderer
{
    //@"C:\Users\1248a\Desktop"
    public static string CurrentPath { get; private set; } = @"C:\Users\1248a\Desktop";
    //Tree of visited paths
    static HashSet<string> visited = new HashSet<string>();
    //Our handle
    static FileStream currentHandle = null;
    [RuntimeInitializeOnLoadMethod]
    static void Init()
    {
        Application.quitting += CloseHandle;
    }
    static void CloseHandle() { if (currentHandle != null) currentHandle.Close(); }
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
        retry://Retry in case of a sort of failure
        if (File.Exists(CurrentPath)) CurrentPath = Directory.GetParent(CurrentPath).FullName;
        if (Random.value > 0.6) CurrentPath = Directory.GetParent(CurrentPath).FullName;
        //Get all entries in this directory
        string[] dirs;
        string[] files;
        if ((bool)Settings.Items["Hidden Files"])//Get everything but system flagged files/dir
        {
            dirs = Directory.GetDirectories(CurrentPath).Where(f => !File.GetAttributes(f).HasFlag(FileAttributes.System)).ToArray();
            files = Directory.GetFiles(CurrentPath).Where(f => !File.GetAttributes(f).HasFlag(FileAttributes.System)).ToArray();
        }
        else //Get only non-hidden, non-sytem flagged files/dirs
        {
            dirs = Directory.GetDirectories(CurrentPath).Where(f => !File.GetAttributes(f).HasFlag(FileAttributes.System & FileAttributes.Hidden)).ToArray();
            files = Directory.GetFiles(CurrentPath).Where(f => !File.GetAttributes(f).HasFlag(FileAttributes.System & FileAttributes.Hidden)).ToArray();
        }
        //Get random range
        int selector = Random.Range(0, dirs.Length + files.Length);
        //Add to visited
        visited.Add(CurrentPath);
        if (selector < files.Length) CurrentPath = files[selector];//Get a file if we got files
        else if (dirs.Length != 0)//Enter a new directory and get a file in it
        {
            Debug.Log($"Path is at {CurrentPath}");
            Debug.Log($"Index {selector}, arr lev {dirs.Length}");
            CurrentPath = dirs[selector - files.Length];
            files = Directory.GetFiles(CurrentPath);
            if (files.Length == 0)
            {
                CurrentPath = Directory.GetParent(CurrentPath).FullName; //Go back up in failure and try random selection again if the chosen directory is empty / Remove from flow LATER
                goto retry; //oh no, a goto. Try and stab me 
            }
            selector = Random.Range(0, files.Length);
            Debug.Log($"Index {selector}, arr len {files.Length}");
            CurrentPath = files[selector];
        }
        else //If the directory we were in just happens to be emptied while we were in it
        {
            CurrentPath = Directory.GetParent(CurrentPath).FullName;
            goto retry;
        }
        long size = new FileInfo(CurrentPath).Length;
        Debug.Log($"{CurrentPath} is {size} bytes");
        
    }
    

}
