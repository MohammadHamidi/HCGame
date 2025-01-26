using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 0)]
public class LevelSO : ScriptableObject 
{
    public Chunk[] chunks;
}