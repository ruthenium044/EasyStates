using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarObject : MonoBehaviour
{
    private Movement movement;
    private Rotation rotation;
    
    void Start()
    {
        movement = GetComponent<Movement>();
        rotation = GetComponent<Rotation>();
        
        rotation.RotateRandom();
    }
    
    void Update()
    {
        movement.MoveObject();
    }
}
