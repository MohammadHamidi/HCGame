using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{


    [SerializeField] private Chunk[] chunks;

    
  

    Vector3 postion = Vector3.zero;
    private void Start()
    {

        CreateLevel(8);
        
        

    }

    private void CreateLevel(int count)
    {

        for (int i = 0; i < count; i++)
        {
            Chunk chunkPrefab=GetRandomChunk();
            if (chunkPrefab == null) continue;
            if (i > 0)
            {
                postion.z += chunkPrefab.GetSize() / 2;

            }
            var instance=Instantiate(chunkPrefab, postion, Quaternion.identity,transform);
            postion.z += instance.GetSize()/2;
        }
    }

    private Chunk GetRandomChunk()
    {
        if(chunks.Length<=0)
            return null;
        return chunks[RandomNumberGenreator(0,chunks.Length)];
    }
    private int RandomNumberGenreator(int min , int max)
    {
        return Random.Range(min, max);

    }

}
