using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    [SerializeField] private Transform Target;
    private void LateUpdate()
    {
        transform.position = Target.position+offset;
    }

}
