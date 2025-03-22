using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONSaveLoadService : ISaveLoadService
{
    public T Load<T>(string key)
    {
        string path = BuildPath(key);
        string content = File.ReadAllText(path);
        T data = JsonUtility.FromJson<T>(content);
        return data;
    }

    public void Save(string key, object data)
    {
        string path = BuildPath(key);
        string content = JsonUtility.ToJson(data);
        File.WriteAllText(path, content);

    }

    string BuildPath(string key)
    {
        string path = Application.dataPath + "/" + key;
        return path;
    }

}
