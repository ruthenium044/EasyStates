using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorState : MonoBehaviour, IState
{
    private DrawShape drawShape;
    private ChangeColor changeColor;    
    [SerializeField] private Color mainColor;
    [SerializeField] private Color newColor;
    
    public void EnterState()
    {
        drawShape = GetComponent<DrawShape>();
        changeColor = GetComponent<ChangeColor>();
        changeColor.SetColor(drawShape.materials, newColor);
    }

    public void UpdateState()
    {
        
    }

    public void ExitState()
    {
        changeColor.SetColor(drawShape.materials, mainColor);
    }
}
