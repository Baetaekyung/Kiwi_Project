using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;
    private static bool destroyed = false;
    public static T Instance
    {
        get
        {
            if (destroyed)
            {
                instance = null;
                return null;
            }

            if(instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if(instance == null)
                {
                    instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                }
            }
            return instance;
        }
    }

    private void OnApplicationQuit()
    {
        destroyed = true;
    }
}
