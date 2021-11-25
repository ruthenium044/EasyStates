using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public void MoveObject()
    {
        var newPosition = transform.position;
        newPosition = new Vector3(newPosition.x, newPosition.y + Time.deltaTime, newPosition.z);
        transform.position = newPosition;
    }
}
