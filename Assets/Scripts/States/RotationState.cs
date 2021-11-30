using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationState : MonoBehaviour, State
{
    private JellyObject jellyObject;
    private Rotation rotation;

    private void Awake()
    {
        jellyObject = GetComponent<JellyObject>();
        rotation = GetComponent<Rotation>();
    }

    public void UpdateState()
    {
        jellyObject.dt = Time.deltaTime;
    }
}
