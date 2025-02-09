using UnityEngine;

public class Runner : MonoBehaviour 
{
    public bool isTarget = false;
    public bool StopedRunning = false;
    private void Update()
    {
        // if (StopedRunning)return;
        // if (GameManager.instance.IsGameState())
        // {
        //     StartRunning();
        // }
       
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
        StopedRunning = true;
        GetComponent<Animator>().Play("Victory");
        
    }

    private void StartRunning()
    {StopedRunning = false;
        GetComponent<Animator>().Play("Fast Run");
    }


    public void SetTarget() 
    {
        isTarget = true;
    }
}