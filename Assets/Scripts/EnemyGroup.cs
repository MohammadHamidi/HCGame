using UnityEngine;

public class EnemyGroup : MonoBehaviour 
{
    [Header("Elements")]
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemiesParent;

    [Header("Settings")] 
    [SerializeField] private int amount = 10;
    [SerializeField] private float radius = 1f;
    [SerializeField] private float angle = 137.5f;



    private void Start() 
    {
        GenerateEnemies();
    }

    private void GenerateEnemies() 
    {
        for (int i = 0; i < amount; i++) 
        {
            Vector3 enemyLocalPosition = GetRunnerLocalPosition(i);
            Vector3 enemyWorldPosition = transform.TransformPoint(enemyLocalPosition);
            Instantiate(enemyPrefab, enemyWorldPosition, Quaternion.identity, enemiesParent);
        }
    }

    private Vector3 GetRunnerLocalPosition(int index) 
    {
        float r = Mathf.Sqrt(index + 0.5f) * radius;
        float theta = index * angle * Mathf.Deg2Rad;
        
        return new Vector3(
            r * Mathf.Cos(theta),
            0,
            r * Mathf.Sin(theta)
        );
    }
}