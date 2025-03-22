using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveLoadService 
{
    void Save(string key, object data);
    T Load<T>(string key);
}
