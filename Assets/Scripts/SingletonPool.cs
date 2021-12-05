using System.Collections.Generic;
using UnityEngine;

public class SingletonPool : MonoBehaviour
{
    [SerializeField] private int initialPool;
    [SerializeField] private GameObject objectPrefab;
    
    private Stack<GameObject> pool;
    
    public static SingletonPool Instance { get; private set; }

    private void Awake()
    {
        SetInstance();
        PoolObjects();
    }

    public GameObject GetObjectFromPool()
    {
        if (pool.TryPop(out GameObject obj))
        {
            obj.SetActive(true);
            return obj;
        }
        GameObject temp = PoolObject();
        temp.SetActive(true);
        return temp;
    }

    public void BackToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Push(obj);
    }
    
    private void PoolObjects()
    {
        pool = new Stack<GameObject>();
        for (int i = 0; i < initialPool; i++)
        {
            PoolObject();
        }
    }

    private GameObject PoolObject()
    {
        GameObject temp = Instantiate(objectPrefab, transform);
        temp.SetActive(false);
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

}
