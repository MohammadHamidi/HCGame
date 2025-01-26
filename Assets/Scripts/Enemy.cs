using UnityEngine;

public class Enemy : MonoBehaviour 
{
    private enum State 
    {
        Idle,
        Running
    }

    [Header("Settings")]
    [SerializeField] private float searchRadius = 5f;
    [SerializeField] private float moveSpeed = 10f;
    
    private State state;
    private Transform targetRunner;

    private void Update() 
    {
        ManageState();
    }

    private void ManageState() 
    {
        switch (state) 
        {
            case State.Idle:
                SearchForTarget();
                break;
            case State.Running:
                RunTowardsTarget();
                break;
        }
    }

    private void SearchForTarget() 
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);
        
        for (int i = 0; i < detectedColliders.Length; i++) 
        {
            if (detectedColliders[i].TryGetComponent<Runner>(out Runner runner)) 
            {
                if (runner.IsTarget()) continue;
                
                runner.SetTarget();
                targetRunner = runner.transform;
                StartRunningTowardsTarget();
                break;
            }
        }
    }

    private void RunTowardsTarget() 
    {
        if (targetRunner == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetRunner.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetRunner.position) < 0.1f) 
        {
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);
        }
    }

    private void StartRunningTowardsTarget() 
    {
        state = State.Running;
        GetComponent<Animator>().Play("Run");
    }
}