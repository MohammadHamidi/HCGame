using UnityEngine;

public enum EnemyState
{
    Idle,Attacking,Running,Death,Victory
}

public class Enemy : MonoBehaviour 
{


    // Search Player 
    // Atack Player

    private EnemyState state;
    //[Header("Settings")]
    [SerializeField] private float searchRadius = 5f;
    [SerializeField] float runningSpeed=1;
    [SerializeField] float attackRange=.3f;


    //private State state;
    private Transform targetRunner;

    private void Start()
    {
        state = EnemyState.Idle;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
    
    // Player In Range 
    private void SerachForPlayer()
    {
       var Players= Physics.OverlapSphere(transform.position, searchRadius);
        for (int i = 0; i < Players.Length; i++)
        {
            var player = Players[i].GetComponent<Runner>();
            if (player!= null && !player.isTarget)
            {
                targetRunner = player.transform;
                player.SetTarget();
                state = EnemyState.Running;
                break;
            }
        }
    }
    private void Update()
    {
        UpdateStateBehaviour();
    }
    private void UpdateStateBehaviour()
    {
        switch (state)
        {
            case EnemyState.Idle:
                IdleStateBehaviur();
                break;
            case EnemyState.Running:
                RunnungTowardStateBehaviur();
                break;
            case EnemyState.Attacking:
                AtakingStateBehaviour();
                break;
            case EnemyState.Victory:
                
                break;
            case EnemyState.Death:
                
                break;
        }
    }
    private void IdleStateBehaviur()
    {
        var animator=gameObject.GetComponent<Animator>();
        animator.Play("Breathing Idle");
        SerachForPlayer();
    }
    private void RunnungTowardStateBehaviur()
    {
        var animator = gameObject.GetComponent<Animator>();
        transform.LookAt(targetRunner);
        RunTowardTarget();
        animator.Play("Fast Run");
        // Distance Runner -Target < ?
        if (Vector3.Distance(transform.position,targetRunner.position)<1)
        {
            state = EnemyState.Attacking;
        }
        
    }

    private void AtakingStateBehaviour()
    {
        var animator = gameObject.GetComponent<Animator>();
        animator.Play("Fight");
    }

    private void RunTowardTarget()
    {
        if (targetRunner != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetRunner.position, Time.deltaTime * runningSpeed);
            if (Vector3.Distance(transform.position, targetRunner.position) <= attackRange)
            {
                Destroy(targetRunner.gameObject);
                Destroy(gameObject);
            }
        }


    }

   
    //private void RunTowardsTarget() 
    //{
    //    if (targetRunner == null) return;

    //    transform.position = Vector3.MoveTowards(
    //        transform.position,
    //        targetRunner.position,
    //        moveSpeed * Time.deltaTime
    //    );

    //    if (Vector3.Distance(transform.position, targetRunner.position) < 0.1f) 
    //    {
    //        Destroy(targetRunner.gameObject);
    //        Destroy(gameObject);
    //    }
    //}

    //private void StartRunningTowardsTarget() 
    //{
    //    state = State.Running;
    //    GetComponent<Animator>().Play("Run");
    //}



}