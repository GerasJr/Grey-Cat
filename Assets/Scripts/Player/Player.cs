using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerAnimation _playerAnimation;

    public static event OnDying DieEvent;
    public delegate void OnDying();

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void Die()
    {
        _playerMovement.enabled = false;
        _playerAnimation.enabled = false;
        DieEvent?.Invoke();
    }
}
