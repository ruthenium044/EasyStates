using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pool;
    [SerializeField] private int initialPool;
    [SerializeField] private GameObject objectPrefab;
    
    public static ObjectPool Instance { get; private set; }

    private void Awake()
    {
        SetInstance();
        PoolObjects();
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        return PoolObject();
    }
    
    private void PoolObjects()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < initialPool; i++)
        {
            PoolObject();
        }
    }

    private GameObject PoolObject()
    {
        GameObject temp = Instantiate(objectPrefab);
        temp.SetActive(false);
        pool.Add(temp);
        return temp;
    }

    private void SetInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Activate One"))
        {
            GameObject temp = GetObjectFromPool();
            temp.SetActive(true);
        }

        if (GUI.Button(new Rect(160, 10, 150, 100), "Deactivate One"))
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (pool[i].activeInHierarchy)
                {
                    pool[i].SetActive(false);
                    return;
                }
            }
        }
    }
}
