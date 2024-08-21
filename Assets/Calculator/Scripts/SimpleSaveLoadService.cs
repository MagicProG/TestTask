using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SimpleSaveLoadService : ISaveLoad
{
    public T Load<T>(string key)
    {
        string path = BuildPath(key);

        try
        {
            using var filestream = new StreamReader(path);
            var json = filestream.ReadToEnd();

            return JsonUtility.FromJson<T>(json);
        }
        catch (Exception ex)
        {
            return default;
        }
    }

    public void Save<T>(string key, T value)
    {
        string path = BuildPath(key);
        string json = JsonUtility.ToJson(value);

        using var filestream = new StreamWriter(path);
        filestream.Write(json);
    }

    private string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
