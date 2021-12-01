using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private static readonly int EmissionColor = Shader.PropertyToID("EmissionColor");

    public void SetColor(Material[] materials, Color color)
    {
        foreach (var t in materials)
        {
            t.SetColor(EmissionColor, color);
        }
    }
}
