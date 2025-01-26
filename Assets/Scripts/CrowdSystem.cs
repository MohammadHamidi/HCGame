using System;
using UnityEngine;

using System;
using UnityEngine;



public class CrowdSystem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float radious;
    [SerializeField] private float angle;
    [SerializeField] private float lerpSpeed = 5f;
    [SerializeField] private GameObject runnerPrefab;
    [Space(4)]
    [SerializeField]
    private Transform runnerParent;
    



    private void Update()
    {
        PlaceRunners();
    }

    public void PlaceRunners()
    {
        for (int i = 0; i < runnerParent.childCount; i++)
        {
            var targetPosition = GetRunnerLocalPosition(i);
            var child = runnerParent.GetChild(i);
            child.localPosition = Vector3.Lerp(child.localPosition, targetPosition, Time.deltaTime * lerpSpeed);
            child.localRotation= runnerParent.transform.localRotation;
        }
    }

    public void ApplyEffect(BonusType type, int amount)
    {
        switch (type)
        {
            case BonusType.Addition:
                AddRunners(amount);
                break;
            case BonusType.Product:
                MultiPlyRunners(amount);
                break;
            case BonusType.Difference:
                SubtractRunners(amount);
                break;
            case BonusType.Division:
                DevideRunnres(amount);
                break;
        }
    }

    private void DevideRunnres(int amount)
    {
        var runnersCount = GetRunnerCount();
        var devidedAmount= Mathf.RoundToInt(runnersCount / amount);
        SubtractRunners(devidedAmount);
    }

    private void SubtractRunners(int amount)
    {

        
        var cuurentCount = GetRunnerCount();
        var endCount = cuurentCount - amount;
        Debug.Log($" [Subtract Runners] Current Count {cuurentCount} , amount {amount} , endValue{endCount}");

        if (endCount > 0)
        {
            Runner[] allChild = runnerParent.GetComponentsInChildren<Runner>();
            for (var i = allChild.Length - 1; i >= endCount; i--)
            {
                Debug.Log($" [Subtract Runners] : Iteration{i}");

                var child = allChild[i].gameObject;
                Destroy(child);
            }
        }
        else
        {
            
        }

    }

    private void MultiPlyRunners(int amount)
    {
        var runnersCount = GetRunnerCount();
        var endValue = runnersCount * (amount - 1);
        AddRunners(endValue);
    }

    public void AddRunners(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CreateRunner();
        }
    }

    private void CreateRunner()
    {
        var created=Instantiate(runnerPrefab,runnerParent.transform.position,Quaternion.identity);
        created.transform.SetParent(runnerParent);
    }

    public int GetRunnerCount()
    {
        return runnerParent.childCount;
    }

    public void ApplyEffect()
    {
        
    }

    public Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radious * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radious * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x, transform.localPosition.y, z);
    }
    public void ApplyBonus(BonusType bonusType, int bonusAmount) 
    {
        
    }
//    {
//        switch (bonusType)
//        {
//            case BonusType.Addition:
//                break;
//            case BonusType.Difference:
//                break;
//            case BonusType.Product:
//                break;
//            case BonusType.Division:
//                break;
//        }
//    }

}


// Runner.cs


// EnemyGroup.cs


//public class CrowdSystem : MonoBehaviour
//{
//    public enum SpiralType
//    {
//        Archimedean1,
//        Archimedean2,
//        Euler,
//        Fermat,
//        Hyperbolic,
//        Lituus,
//        Logarithmic,
//        Theodorus,
//        Fibonacci,
//        Involute,
//        Super,
//        Atomic,
//        Atzema,
//        Vogel,
//        Cochleoid,
//        Sacks
//    }

//    [Header("Settings")]
//    [SerializeField] private SpiralType spiralType;
//    [SerializeField] private float radius = 5f;
//    [SerializeField] private float angleStep = 15f;
//    [SerializeField] private float lerpSpeed = 5f;

//    [Space(4)]
//    [SerializeField]
//    private Transform runnerParent;

//    private void Update()
//    {
//        PlaceRunners();
//    }

//    public void PlaceRunners()
//    {
//        for (int i = 0; i < runnerParent.childCount; i++)
//        {
//            var targetPosition = GetRunnerLocalPosition(i);
//            var child = runnerParent.GetChild(i);
//            child.localPosition = Vector3.Lerp(child.localPosition, targetPosition, Time.deltaTime * lerpSpeed);
//            child.localRotation = runnerParent.transform.localRotation;
//        }
//    }
//    public float GetRadius()
//    {
//        return radius * Mathf.Sqrt(transform.childCount)*2f;    
//    }
//    public Vector3 GetRunnerLocalPosition(int index)
//    {
//        float t = index * Mathf.Deg2Rad * angleStep;
//        float x = 0f, z = 0f;

//        switch (spiralType)
//        {
//            case SpiralType.Archimedean1:
//                x = (radius + t) * Mathf.Cos(t);
//                z = (radius + t) * Mathf.Sin(t);
//                break;

//            case SpiralType.Archimedean2:
//                x = (radius + t) * Mathf.Sin(t);
//                z = (radius + t) * Mathf.Cos(t);
//                break;

//            case SpiralType.Euler:
//                x += Mathf.Cos(t * t) * angleStep;
//                z += Mathf.Sin(t * t) * angleStep;
//                break;

//            case SpiralType.Fermat:
//                float rFermat = radius * Mathf.Sqrt(t);
//                x = rFermat * Mathf.Cos(t);
//                z = rFermat * Mathf.Sin(t);
//                break;

//            case SpiralType.Hyperbolic:
//                float rHyperbolic = radius / t;
//                x = rHyperbolic * Mathf.Cos(t);
//                z = rHyperbolic * Mathf.Sin(t);
//                break;

//            case SpiralType.Lituus:
//                float rLituus = Mathf.Sqrt(radius / t);
//                x = rLituus * Mathf.Cos(t);
//                z = rLituus * Mathf.Sin(t);
//                break;

//            case SpiralType.Logarithmic:
//                float rLog = radius * Mathf.Exp(t * 0.1f);
//                x = rLog * Mathf.Cos(t);
//                z = rLog * Mathf.Sin(t);
//                break;

//            case SpiralType.Theodorus:
//                float rTheodorus = Mathf.Sqrt(index);
//                x = rTheodorus * Mathf.Cos(t);
//                z = rTheodorus * Mathf.Sin(t);
//                break;

//            case SpiralType.Fibonacci:
//                float phi = (1 + Mathf.Sqrt(5)) / 2; // Golden ratio
//                float rFib = (Mathf.Pow(phi, index) - Mathf.Pow(-1 / phi, index)) / Mathf.Sqrt(5);
//                x = radius * rFib * Mathf.Cos(t);
//                z = radius * rFib * Mathf.Sin(t);
//                break;

//            case SpiralType.Involute:
//                x = radius * (Mathf.Cos(t) + t * Mathf.Sin(t));
//                z = radius * (Mathf.Sin(t) - t * Mathf.Cos(t));
//                break;

//            case SpiralType.Super:
//                float rSuper = radius * Mathf.Sqrt(index / (float)runnerParent.childCount);
//                x = rSuper * Mathf.Cos(t);
//                z = rSuper * Mathf.Sin(t);
//                break;

//            case SpiralType.Atomic:
//                float rAtomic = t / (t - radius);
//                x = rAtomic * Mathf.Cos(t);
//                z = rAtomic * Mathf.Sin(t);
//                break;

//            case SpiralType.Atzema:
//                x = Mathf.Sin(t) / t - 2 * Mathf.Cos(t) - t * Mathf.Sin(t);
//                z = -Mathf.Cos(t) / t - 2 * Mathf.Sin(t) + t * Mathf.Cos(t);
//                break;

//            case SpiralType.Vogel:
//                float rVogel = Mathf.Sqrt(index) / Mathf.Sqrt(runnerParent.childCount);
//                x = radius * rVogel * Mathf.Cos(t);
//                z = radius * rVogel * Mathf.Sin(t);
//                break;

//            case SpiralType.Cochleoid:
//                float rCochleoid = Mathf.Sin(t) / t;
//                x = radius * rCochleoid * Mathf.Cos(t);
//                z = radius * rCochleoid * Mathf.Sin(t);
//                break;

//            case SpiralType.Sacks:
//                float sqrtI = Mathf.Sqrt(index);
//                x = radius * -Mathf.Cos(sqrtI * Mathf.PI * 2) * sqrtI;
//                z = radius * Mathf.Sin(sqrtI * Mathf.PI * 2) * sqrtI;
//                break;

//            default:
//                throw new ArgumentOutOfRangeException();
//        }

//        return new Vector3(x, transform.localPosition.y, z);
//    }

//   
//}
