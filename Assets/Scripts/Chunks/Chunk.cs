using UnityEngine;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    public List<SpawnPoint> SpawnPoints { get; private set; } = new List<SpawnPoint>();
    private Chunk_StartPoint _startPoint;
    private Chunk_EndPoint _endPoint;

    private void Awake()
    {
        _startPoint = GetComponentInChildren<Chunk_StartPoint>();
        _endPoint = GetComponentInChildren<Chunk_EndPoint>();
        SpawnPoints.AddRange(GetComponentsInChildren<SpawnPoint>());
    }

    public Vector3 GetStartPoint()
    {
        return _startPoint.GetPosition();
    }

    public Vector3 GetEndPoint()
    {
        return _endPoint.GetPosition();
    }
}
