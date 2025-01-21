using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] Vector3 Size;

    [SerializeField] float Range=10;
    public float GetSize()
    {
        return Size.z;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        var center = new Vector3(transform.position.x, transform.position.y-Size.y/2, transform.position.z);
        Gizmos.DrawWireCube(center, Size);
        
    }


}
