using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

    private void Start()
    {
        startPos = transform.position;
        endPos = transform.position + Vector3.down;
    }

    public void MoveObject(float dt)
    {
        float t = Mathf.PingPong(Time.time, 1);
        t *= t;
        var newPosition = Vector3.Lerp(startPos, endPos, t);
        transform.localPosition = newPosition;
    }
}
    