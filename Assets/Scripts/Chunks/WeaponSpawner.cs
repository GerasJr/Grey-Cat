using UnityEngine;
using System.Collections.Generic;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private PlayerArms _playerArms;
    [SerializeField] private WeaponItem _weaponItem;
    [SerializeField] private WeaponContainer _weaponContainer;
    [SerializeField] private StageUpdater _stageUpdater;

    private int _withWeaponSpawnChance = 25;

    private void Awake()
    {
        ChunksUpdater.SpawnedEvent += SpawnWeapons;
    }

    private void SpawnWeapons(Chunk spawnedChunk)
    {
        for (int i = 0; i < _stageUpdater.GetCurrentStage().weaponsOnChunk; i++)
        {
            if (IsSpawnWeapon())
            {
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
                WeaponItem item = Instantiate(_weaponItem, spawnedChunk.SpawnPoints[pointIndex].transform);
                WeaponInfo spawnedWeapon = _weaponContainer.GetWeapon(Random.Range(0, _weaponContainer.GetWeaponsCount()));
                item.SetNewInfo(spawnedWeapon);
            }
        }
    }

    private bool IsSpawnWeapon()
    {
        int integer = 100;
        bool decision;

        if (_playerArms.IsHaveWeapon())
        {
            decision = _withWeaponSpawnChance >= Random.Range(0, integer);
        }
        else
        {
            decision = true;
        }

        return decision;
    }

    private void OnDestroy()
    {
        ChunksUpdater.SpawnedEvent -= SpawnWeapons;
    }
}
