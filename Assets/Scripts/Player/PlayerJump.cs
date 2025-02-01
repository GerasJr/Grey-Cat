using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _jumpForce = 0f;

    public bool IsJump { get; private set; } = false;
    private bool _isCollission = false;
    private SurfaceDetector _surfaceDetector;
    private float _currentTime, _totalTime;
    private float yPosition;

    private void Start()
    {
        _surfaceDetector = GetComponent<SurfaceDetector>();
        _totalTime = _jumpCurve.keys[_jumpCurve.keys.Length - 1].time;
    }

    private void Update()
    {
        if (IsJump == true)
        {
            transform.position = new Vector3(transform.position.x, yPosition + _jumpCurve.Evaluate(_currentTime) * _jumpForce);
            _currentTime += Time.deltaTime;

            if (_currentTime >= _totalTime || _surfaceDetector.IsCeilingDetect())
            {
                _currentTime = 0;
                IsJump = false;
            }
        }
        else
        {
            yPosition = transform.position.y;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Collider2D>(out Collider2D collider))
        {
            _isCollission = true;
        }
        else
        {
            _isCollission = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isCollission = false;
    }

    public void Jump()
    {
        if (_surfaceDetector.IsDetectGround() && _isCollission == true)
        {
            IsJump = true;
        }
    }
}
