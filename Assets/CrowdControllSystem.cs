using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdControllSystem : MonoBehaviour
{
    int previusChildCount=1;
    [SerializeField] private float radious=.5f;
    [SerializeField] private float angle=137.508f;
    // 


    private void Update()
    {
        ChangeChildOrientation();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (previusChildCount != transform.childCount)
        {
            previusChildCount = transform.childCount;
            Debug.Log($"Child Count Changed {previusChildCount}");
           
        }
            
    }

    private void ChangeChildOrientation()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child=transform.GetChild(i);
            child.localPosition = GetRunnerLocalPosition(i);
            child.transform.localRotation = transform.localRotation;

        }
    }
    public Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radious * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radious * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x, transform.localPosition.y, z);
    }
}
