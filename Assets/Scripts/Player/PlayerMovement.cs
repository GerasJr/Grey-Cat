using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;

    private Vector3 _moveDirection = Vector3.right;
    private PlayerJump _playerJump;

    void Start()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
        _playerJump = GetComponent<PlayerJump>();
    }

    private void Update()
    {
        Run();
    }

    private void OnSwipe(Vector2 direction)
    {
        if(direction.y > 0)
        {
            Jump();
        }
    }

    private void Run()
    {
        transform.position += _moveDirection * _speed * Time.deltaTime;
    }

    private void Jump()
    {
        _playerJump.Jump();
    }

    private void OnDestroy()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }
}
