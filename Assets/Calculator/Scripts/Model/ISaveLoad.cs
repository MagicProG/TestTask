using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveLoad
{
    public void Save<T>(string key, T value);
    public T Load<T>(string key);
}
