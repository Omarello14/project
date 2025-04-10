using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "Scriptable Objects/EnemyWave")]
public class EnemySpawnConfig : ScriptableObject
{
    [field: SerializeField] public Enemy[] Prefabs { get; private set; }
    [field: SerializeField] public int EnemyPerLevel { get; private set; } //how many prefabs from the array belong to the same level
    [field: SerializeField] public int EnemyPerSpawn { get; private set; } //how many enemies will spawn in 1 time
    [field: SerializeField] public int SpawnCooldown { get; private set; }
}
