using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private WeaponItem _weaponItem;

    private void Start()
    {
        ChunksUpdater.SpawnedEvent += SpawnItems;
    }

    private void SpawnItems(Chunk spawnedChunk)
    {
        int pointIndex = Random.Range(0, spawnedChunk.SpawnPoints.Count);

        while (spawnedChunk.SpawnPoints[pointIndex].IsTaken)
        {
            pointIndex = Random.Range(0, spawnedChunk.SpawnPoints.Count);
        }

        spawnedChunk.SpawnPoints[pointIndex].Take();
        WeaponItem item = Instantiate(_weaponItem, spawnedChunk.SpawnPoints[pointIndex].transform);
        item.SetRandom();
    }

    private void OnDestroy()
    {
        ChunksUpdater.SpawnedEvent -= SpawnItems;
    }
}
