using UnityEngine;

public class Runner : MonoBehaviour 
{
    public bool isTarget = false;

    private void Update()
    {
        if (GameManager.instance.IsGameState())
        {
            StartRunning();
        }
        else
        {
            StopRunning();
        }
    }
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

    private void StartRunning()
    {
        GetComponent<Animator>().Play("Fast Run");
    }


    public void SetTarget() 
    {
        isTarget = true;
    }
}