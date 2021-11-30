using System.Collections.Generic;
using UnityEngine;

public class SingletonPool : MonoBehaviour
{
    private List<GameObject> pool;
    [SerializeField] private int initialPool;
    [SerializeField] private GameObject objectPrefab;
    
    public static SingletonPool Instance { get; private set; }

    private void Awake()
    {
        SetInstance();
        PoolObjects();
    }

    public GameObject GetObjectFromPool()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
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
        GameObject temp = Instantiate(objectPrefab, transform);
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
    
    private void ActivateObject()
    {
        GameObject temp = GetObjectFromPool();
        temp.SetActive(true);
    }

    private void DeactivateObject()
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

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 50), "Activate 1 object"))
        {
            ActivateObject();
        }
        
        if (GUI.Button(new Rect(170, 10, 150, 50), "Activate 100 objects"))
        {
            for (int i = 0; i < 100; i++)
            {
                ActivateObject();
            }
        }
    
        if (GUI.Button(new Rect(330, 10, 150, 50), "Deactivate 1 object"))
        {
            DeactivateObject();
        }
        
        if (GUI.Button(new Rect(490, 10, 150, 50), "Deactivate 100 objects"))
        {
            for (int i = 0; i < 100; i++)
            {
                DeactivateObject();
            }
        }
    }
}
