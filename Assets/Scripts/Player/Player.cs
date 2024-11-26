using UnityEngine;

public class Player : MonoBehaviour
{
    public static event OnDying DieEvent;
    public delegate void OnDying();

    public void Die()
    {
        DieEvent?.Invoke();
    }
}
