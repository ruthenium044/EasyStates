using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

    public void SetStartPos(Vector3 start, Vector3 end)
    {
        startPos = start;
        endPos = end;
    }

    public void MoveObject(float time)
    {
        float t = Mathf.PingPong(time, 1);
        t *= t;
        var newPosition = Vector3.Lerp(startPos, endPos, t);
        transform.localPosition = newPosition;
    }
    
}
    