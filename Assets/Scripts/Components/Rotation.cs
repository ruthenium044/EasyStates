using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public void RotateRandom()
    {
        float angle = Random.Range(0, 360);
        transform.Rotate(Vector3.forward, angle);
    }
}
