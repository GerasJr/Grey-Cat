using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        ChunksUpdater.SpawnedEvent += SpawnEnemies;
    }

    private void SpawnEnemies(Chunk spawnedChunk)
    {
        int pointIndex = Random.Range(0, spawnedChunk.SpawnPoints.Count);

        while (spawnedChunk.SpawnPoints[pointIndex].IsTaken)
        {
            pointIndex = Random.Range(0, spawnedChunk.SpawnPoints.Count);
        }

        spawnedChunk.SpawnPoints[pointIndex].Take();
        Instantiate(_enemy, spawnedChunk.SpawnPoints[pointIndex].transform);
    }

    private void OnDestroy()
    {
        ChunksUpdater.SpawnedEvent -= SpawnEnemies;
    }
}
