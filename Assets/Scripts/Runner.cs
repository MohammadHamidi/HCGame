using UnityEngine;

public class Runner : MonoBehaviour 
{
    private bool isTarget = false;

    public bool IsTarget() => isTarget;

    public void SetTarget() 
    {
        isTarget = true;
    }
}