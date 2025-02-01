using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;

    private float _currentSpeed;
    private Coroutine _speedBoostJob;
    private Vector3 _moveDirection = Vector3.right;
    private PlayerJump _playerJump;

    public static event OnSpeedBoostTake SpeedBoostEvent;
    public delegate void OnSpeedBoostTake(float coolDown);

    void Start()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
        _playerJump = GetComponent<PlayerJump>();
        _currentSpeed = _speed;
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
        transform.position += _moveDirection * _currentSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        _playerJump.Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if(collision.gameObject.TryGetComponent<SpeedBoost>(out SpeedBoost speedBoost))
            {
                if(_speedBoostJob != null)
                {
                    StopCoroutine(_speedBoostJob);
                }

                float coolDown = 0;
                _currentSpeed = _speed + speedBoost.GetBoost(ref coolDown);
                _speedBoostJob = StartCoroutine(SpeedBooster(coolDown));
                SpeedBoostEvent.Invoke(coolDown);
            }
        }
        catch { }
    }

    private IEnumerator SpeedBooster(float coolDown)
    {
        yield return new WaitForSeconds(coolDown);
        _currentSpeed = _speed;
        SpeedBoostEvent(0);
        StopCoroutine(_speedBoostJob);
    }

    private void OnDestroy()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }
}
