using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour 
{
    [Header("Level Generation")]
    [SerializeField] private Chunk[] chunks;
    [SerializeField] private LevelSO[] levels;
    [SerializeField] private int chunckCount;
    [Header("References")]
    private GameObject finishLine;
    private Vector3 position = Vector3.zero;
    public static ChunkManager instance;
    public Chunk FinishChunk;

    public List<Chunk> allChuns=new List<Chunk>();
    private void Awake() 
    {
        if (instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        if (levels != null && levels.Length > 0)
        {
            GenerateLevel();
        }
        else
        {
            CreateRandomLevel(chunckCount);
        }

        finishLine=GameObject.FindWithTag("FinishLine");
    }

    private void GenerateLevel() 
    {
        int currentLevel = GetLevel() % levels.Length;
        LevelSO level = levels[currentLevel];
        //CreatePredefinedLevel(level.chunks);
        CreateRandomLevel(chunckCount);
    }

    private void CreatePredefinedLevel(Chunk[] levelChunks)
    {
        position = Vector3.zero;
        foreach (Chunk chunk in levelChunks)
        {
            if (chunk == null) continue;
            
            if (position.z > 0)
            {
                position.z += chunk.GetSize() / 2;
            }
            
            var instance = Instantiate(chunk, position, Quaternion.identity, transform);
            position.z += instance.GetSize() / 2;
        }
    }

    private void CreateRandomLevel(int count)
    {
        position = Vector3.zero;
        for (int i = 0; i < count; i++)
        {
            Chunk chunkPrefab = GetRandomChunk();
            if (chunkPrefab == null) continue;
            
            if (position.z > 0)
            {
                position.z += chunkPrefab.GetSize() / 2;
            }
            if (i == count - 2)
            {
             var chunk=   Instantiate(FinishChunk, position, Quaternion.identity, transform);
                
            }

            var instance = Instantiate(chunkPrefab, position, Quaternion.identity, transform);
            allChuns.Add(instance);
            position.z += instance.GetSize() / 2;
        }
    }

    public Transform GetFinishLine()
    {
        return finishLine.transform;
    }

    //public float GetPlayerProgress() 
    //{
    //    if (!PlayerController.instance || !finishLine) return 0;

    //    float playerZ = PlayerController.instance.transform.position.z;
    //    float finishZ = finishLine.transform.position.z;
    //    return playerZ / finishZ;
    //}

    public float GetPlayerProgress()
    {
        var playerPos = PlayerController.instance.transform.position;
        var levelEnd = GetFinishLine().position;
        var Distance = playerPos.z /levelEnd.z ;
        var Progress=Distance / CalculateLevelLength();
        Debug.Log($"==============Progress : {Progress}");
        return Progress*10;
    }

    private float CalculateLevelLength()
    {
        float levelLength = 0;
        foreach (var item in chunks)
        {
            if (item == null) continue;
            levelLength+=item.GetSize();
        }
        Debug.Log($"Level Length is {levelLength}");
        return levelLength;
    }


    public int GetLevel() 
    {
        return PlayerPrefs.GetInt("Level", 0);
    }

    private Chunk GetRandomChunk()
    {
        if (chunks == null || chunks.Length <= 0)
            return null;
        return chunks[Random.Range(0, chunks.Length)];
    }
}