using UnityEngine;

public class RotationBackState : MonoBehaviour, IState
{
    private JellyObject jellyObject;

    private void Awake()
    {
        jellyObject = GetComponent<JellyObject>();
    }

    public void EnterState()
    {
        jellyObject.dt = -Time.deltaTime;
    }

    public void UpdateState()
    {
        
    }

    public void ExitState()
    {
        jellyObject.dt = 0;
    }
}
