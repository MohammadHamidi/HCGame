using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private Chunk chunkPrefab;


    private void Start()
    {
         Vector3 postion = Vector3.zero;
     
        for (int i = 0; i < 5; i++)
        {
            if (i > 0)
            {
                postion.z+=chunkPrefab.GetSize()/2;
            }
         var instance=Instantiate(chunkPrefab, postion, Quaternion.identity,transform);
         postion.z += instance.GetSize()/2;
        }
    }
}
