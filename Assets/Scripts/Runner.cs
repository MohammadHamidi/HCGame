using UnityEngine;

public class Runner : MonoBehaviour 
{
    private bool isTarget = false;


    private void OnEnable()
    {
        GameEventManager.StopRunning += StopRunning;
    }
    private void OnDisable()
    {
        GameEventManager.StopRunning -= StopRunning;
    }

    private void StopRunning()
    {
        GetComponent<Animator>().Play("Breathing Idle");
    }
    public bool IsTarget() => isTarget;

    public void SetTarget() 
    {
        isTarget = true;
    }
}