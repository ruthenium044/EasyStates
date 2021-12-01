using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : MonoBehaviour, State
{
    private Movement movement;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private float runningTime;
    
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    public void EnterState()
    {
        movement.SetStartPos(startPos, endPos);
    }

    public void UpdateState()
    {
        runningTime += Time.deltaTime;
        movement.MoveObject(runningTime);
    }

    public void ExitState()
    {
        StartCoroutine(MoveToPosition());
    }

    private IEnumerator MoveToPosition()
    {
        while (transform.localPosition != startPos)
        {
            runningTime += Time.deltaTime;
            float t = Time.deltaTime * 10f;
            t *= t;
            Vector3 newPosition = Vector3.MoveTowards(transform.position, startPos, t);
            transform.localPosition = newPosition;
            yield return null;
        }
    }
}
