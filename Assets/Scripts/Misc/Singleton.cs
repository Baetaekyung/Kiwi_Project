using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if(instance == null)
                {
                    string componentName = typeof(T).ToString();
                    GameObject findObject = GameObject.Find(componentName);
                    if(findObject == null)
                    {
                        findObject = new GameObject(componentName);
                    }

                    instance = findObject.AddComponent<T>();
                    DontDestroyOnLoad(instance);
                }
            }
            return instance;
        }
    }
}
