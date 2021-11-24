using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int objectsNumber;
    
    public static ObjectPool Instance { get; private set; }

    private void Awake()
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
        if (GUI.Button(new Rect(10, 10, 150, 100), "AddOne"))
        {
            objectsNumber++;
        }
        
        if (GUI.Button(new Rect(170, 10, 150, 100), "Get Count"))
        {
            print(objectsNumber);
        }
        
        if (GUI.Button(new Rect(330, 10, 150, 100), "Delete Onet"))
        {
            objectsNumber--;
        }
    }
}
