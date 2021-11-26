using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void MoveObject()
    {
        var newPosition = transform.localPosition;
        newPosition = new Vector3(newPosition.x, newPosition.y + Time.deltaTime, newPosition.z);
        transform.localPosition += transform.InverseTransformPoint(Vector3.up) * Time.deltaTime;//  newPosition;
        
    }
}
    