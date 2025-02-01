using UnityEngine;
using System.Collections.Generic;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] List<Booster> _boosters = new List<Booster>();
    [SerializeField] private float _spawnChance;

    private void Awake()
    {
        ChunksUpdater.SpawnedEvent += SpawnBooster;
    }

    private void SpawnBooster(Chunk spawnedChunk)
    {
        if (_spawnChance < Random.Range(0, 100))
        {
            return;
        }

        int pointIndex = Random.Range(0, spawnedChunk.SpawnPoints.Count);

        while (spawnedChunk.SpawnPoints[pointIndex].IsTaken)
        {
            if (spawnedChunk.SpawnPoints.Count == pointIndex + 1)
            {
                pointIndex = 0;
            }
            else
            {
                pointIndex++;
            }
        }

        spawnedChunk.SpawnPoints[pointIndex].Take();
        Instantiate(_boosters[Random.Range(0, _boosters.Count)], spawnedChunk.SpawnPoints[pointIndex].transform);
    }

    private void OnDestroy()
    {
        ChunksUpdater.SpawnedEvent -= SpawnBooster;
    }
}
