using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : Singleton<PoolManager>
{
    [System.Serializable]
    private class WeaponInfo
    {
        public string weaponName;
        public GameObject weaponPrefab;
        public int count;
    }
    public bool isReady { get; private set; }
    [SerializeField]
    private WeaponInfo[] weaponInfos = null;

    private string weaponName;

    private Dictionary<string, IObjectPool<GameObject>>
        weaponDictionary = new Dictionary<string, IObjectPool<GameObject>>();
    private Dictionary<string, GameObject> gameObjectDictionary = 
        new Dictionary<string, GameObject>();

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        isReady = false;

        for(int idx = 0; idx < weaponInfos.Length; idx++)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreateNewObject, OnGetPoolObject,
                OnReleasePoolObject, OnDestroyPoolObject, true, weaponInfos[idx].count, 
                weaponInfos[idx].count);

            if (gameObjectDictionary.ContainsKey(weaponInfos[idx].weaponName))
            {
                Debug.Log("Already Assigned");
            }

            gameObjectDictionary.Add(weaponInfos[idx].weaponName,
                weaponInfos[idx].weaponPrefab);
            weaponDictionary.Add(weaponInfos[idx].weaponName, pool);

            for(int i = 0; i < weaponInfos[idx].count; i++)
            {
                weaponName = weaponInfos[idx].weaponName;
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

    private void OnGetPoolObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    private GameObject CreateNewObject()
    {
        GameObject newObject = Instantiate(gameObjectDictionary[weaponName]);
        newObject.GetComponent<Poolable>().pool = weaponDictionary[weaponName];
        return newObject;
    }
}
