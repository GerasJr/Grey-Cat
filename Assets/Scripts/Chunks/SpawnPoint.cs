using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsTaken { get; private set; } = false;

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Take()
    {
        IsTaken = true;
    }
}
