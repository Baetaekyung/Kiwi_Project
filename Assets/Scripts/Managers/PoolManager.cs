using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : Singleton<PoolManager>
{
    [System.Serializable]
    private class info
    {
        public string weaponName;
        public GameObject weaponPrefab;
        public int count;
    }
    public bool isReady { get; private set; }
    [SerializeField]
    private info[] infos = null;

    private string weaponName;

    private Dictionary<string, IObjectPool<GameObject>>
        dictionary = new Dictionary<string, IObjectPool<GameObject>>();
    private Dictionary<string, GameObject> gameObjectDictionary = 
        new Dictionary<string, GameObject>();

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        isReady = false;

        for(int idx = 0; idx < infos.Length; idx++)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreateNewObject, OnGetPoolObject,
                OnReleasePoolObject, OnDestroyPoolObject, true, infos[idx].count, 
                infos[idx].count);

            if (gameObjectDictionary.ContainsKey(infos[idx].weaponName))
            {
                Debug.Log("Already Assigned");
            }

            gameObjectDictionary.Add(infos[idx].weaponName,
                infos[idx].weaponPrefab);
            dictionary.Add(infos[idx].weaponName, pool);

            for(int i = 0; i < infos[idx].count; i++)
            {
                weaponName = infos[idx].weaponName;
                Poolable poolable = CreateNewObject().GetComponent<Poolable>();
                poolable.pool.Release(poolable.gameObject);
            }
        }
        Debug.Log("[PoolManager] Ready to Pool");
        isReady = true;
    }

    private void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);
    }

    private void OnReleasePoolObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void OnGetPoolObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    private GameObject CreateNewObject()
    {
        GameObject newObject = Instantiate(gameObjectDictionary[weaponName]);
        newObject.GetComponent<Poolable>().pool = dictionary[weaponName];
        return newObject;
    }
}
