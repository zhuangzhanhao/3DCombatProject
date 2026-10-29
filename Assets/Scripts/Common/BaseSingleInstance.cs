using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingleInstance<T> where T : class, new()
{
    private static object lockObj = new object();
    private static T instance;
    public static T Instance
    {
        get
        {
            lock (lockObj)
            {
                if(instance == null)
                    instance = new T();
                return instance;
            }
        }
    }
}
