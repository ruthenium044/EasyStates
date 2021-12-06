using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.Mathf;

public class DrawShape : MonoBehaviour
{
    [SerializeField] private int vertexCount;
    [SerializeField] private float scaler;
    private float step;
    
    private GameObject[] points;
    private readonly Stack<GameObject> used = new();
    [HideInInspector] public Material[] materials;
    
    public void InitializeObjects()
    {
        points = new GameObject[vertexCount * vertexCount];
        materials = new Material[vertexCount * vertexCount];
        
        step = 2f / vertexCount;
        Vector3 scale = Vector3.one * step * scaler;
        for (int i = 0; i < points.Length; i++) 
        {
            GameObject temp = SingletonPool.Instance.GetObjectFromPool();
            points[i] = temp;
            used.Push(temp);
            materials[i] = points[i].GetComponent<MeshRenderer>().material;
            points[i].transform.localScale = scale;
        }
    }

    public void Deactivate(int num)
    {
        num = Min(num, used.Count);
        for (int i = 0; i < num; i++)
        {
            SingletonPool.Instance.BackToPool(used.Pop());
        }
    }

    public void Activate(int num)
    {
        for (int i = 0; i < num; i++)
        {
            used.Push(SingletonPool.Instance.GetObjectFromPool());
        }
    }
    
    public void UpdateSphere(float time)
    {
        float v = 0.5f * step - 1f;
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == vertexCount)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            points[i].transform.localPosition = Sphere(u, v, time);
        }
    }

    private static Vector3 Sphere (float u, float v, float t) 
    {
        float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));
        float s = r * Cos(0.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(0.5f * PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }
}
