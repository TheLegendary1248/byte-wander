using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Simple settings handler
public static class Settings
{
    [RuntimeInitializeOnLoadMethod]
    public static void HardCodedSettingsInit()
    {
#if UNITY_EDITOR //If in development, use all features
        Items.Add("Hidden Files", true);
#else //Otherwise, play it safe
        Items.Add("Hidden Files", false);
#endif
        //Default hardcoded settings
    }
    public static Dictionary<string, object> Items = new Dictionary<string, object>();
    public static void LoadSettings()
    {
        //Code to load settings
    }
}
