using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public void RotateRandom()
    {
        float angle = Random.Range(0, 360);
        transform.RotateAround(transform.position, Vector3.forward, angle);
        
        Matrix4x4 rotationZ = new Matrix4x4(
            new Vector4(Mathf.Cos(angle),      Mathf.Sin(angle), 0, 0),
            new Vector4(-1 * Mathf.Sin(angle), Mathf.Cos(angle), 0, 0),
            new Vector4(0,                     0,                1, 0),
            new Vector4(0,                     0,                0, 1));
    }
}
