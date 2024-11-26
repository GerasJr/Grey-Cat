using UnityEngine;
using System.Collections.Generic;

public class ChunksUpdater : MonoBehaviour
{
    [SerializeField] private Chunk _firstChunk;
    [SerializeField] private Transform _player;
    [SerializeField] private Chunk[] _chunks = new Chunk[3];

    public static event OnSpawned SpawnedEvent;
    public delegate void OnSpawned(Chunk chunk);
    private float _distanceToEndPoint;
    private float _distanceToSpawn = 25;
    private Vector3 _endPoint;
    private Queue<Chunk> spawnedChunks = new Queue<Chunk>();
    private float _maxSpawnedChunks = 4;

    private void Start()
    {
        spawnedChunks.Enqueue(_firstChunk);
        _endPoint = _firstChunk.GetEndPoint();
    }
    private void Update()
    {
         _distanceToEndPoint = Vector2.Distance(_player.position, _endPoint);

        if (_distanceToEndPoint <= _distanceToSpawn)
        {
            UpdateChunks();
        }
    }
    private void UpdateChunks()
    {
        int randomIndex = Random.Range(0, _chunks.Length);
        Chunk newChunk = Instantiate(_chunks[randomIndex]);
        newChunk.transform.position = _endPoint + new Vector3(newChunk.GetEndPoint().x - newChunk.transform.position.x, 0, 0);
        _endPoint = newChunk.GetEndPoint();
        spawnedChunks.Enqueue(newChunk);
        SpawnedEvent.Invoke(newChunk);

        if (spawnedChunks.Count > _maxSpawnedChunks)
        {
            Destroy(spawnedChunks.Dequeue().gameObject);
        }
    }
}
