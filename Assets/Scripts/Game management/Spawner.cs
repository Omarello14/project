using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float SecondsToLevelUp = 600;
    private const int MaxLevel = 3;

    [SerializeField] private EnemySpawnConfig _config;
    [SerializeField] private int _maxEnemyCount = 100;

    private float _timer = 0;
    private int _currentLevel = 0;

    private int _enemiesSpawned = 0;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= SecondsToLevelUp && _currentLevel < MaxLevel)
        {
            _currentLevel++;
            _timer = 0;
        }
    }

    private IEnumerator Spawn()
    {
        var delay = new WaitForSeconds(_config.SpawnCooldown);

        while (true)
        {
            if (_enemiesSpawned < _maxEnemyCount)
            {
                for (int i = 0; i < _config.EnemyPerSpawn; i++)
                {
                    var obj = Instantiate(_config.Prefabs[
                        Random.Range(_currentLevel * _config.EnemyPerLevel, _currentLevel * _config.EnemyPerLevel + _config.EnemyPerLevel)
                        ]).GetComponent<Health>();
                    obj.Died += OnEnemyKilled;
                    Debug.Log(obj.name);
                }

                _enemiesSpawned += _config.EnemyPerSpawn;
            }

            yield return delay;
        }
    }

    private void OnEnemyKilled(Health _)
    {
        _enemiesSpawned--;
    }
}
