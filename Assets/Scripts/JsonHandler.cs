using UnityEngine;
using System.IO;

public static class JsonHandler
{
    public static T ReadData<T>(string path) where T : class
    {
        if (!File.Exists(path)) return null;
        var o = JsonUtility.FromJson<T>(path);
        return o;
    }

    public static void SaveData<T>(T o, string path)
    {
        var c = JsonUtility.ToJson(o);
        File.WriteAllText(path, c); 
    }
}