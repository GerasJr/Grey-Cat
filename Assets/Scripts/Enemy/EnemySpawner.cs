using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private StageUpdater _stageUpdater;

    private float _nextSpawnChance = 100;
    int _integer = 100;

    private void Start()
    {
        ChunksUpdater.SpawnedEvent += SpawnEnemies;
    }

    private void SpawnEnemies(Chunk spawnedChunk)
    {
        _nextSpawnChance = _integer;
        bool spawnEnemy = true;

        for(int i = 0; i < _stageUpdater.GetCurrentStage().enemiesOnChunk && spawnEnemy; i++)
        {
            int pointIndex = Random.Range(0, spawnedChunk.SpawnPoints.Count);

            while (spawnedChunk.SpawnPoints[pointIndex].IsTaken)
            {
                if(spawnedChunk.SpawnPoints.Count == pointIndex + 1)
                {
                    pointIndex = 0;
                }
                else
                {
                    pointIndex++;
                }
            }

            spawnedChunk.SpawnPoints[pointIndex].Take();
            Enemy enemy = Instantiate(_enemy, spawnedChunk.SpawnPoints[pointIndex].transform);
            EnemyInfo enemyInfo = _stageUpdater.GetCurrentStage().enemies[Random.Range(0, _stageUpdater.GetCurrentStage().enemies.Count)];
            enemy.SetNewInfo(enemyInfo);

            _nextSpawnChance = _nextSpawnChance / _stageUpdater.GetCurrentStage().enemyNextSpawnMultiplier;
            spawnEnemy = _nextSpawnChance >= Random.Range(0, _integer);
        }
    }

    private void OnDestroy()
    {
        ChunksUpdater.SpawnedEvent -= SpawnEnemies;
    }
}
