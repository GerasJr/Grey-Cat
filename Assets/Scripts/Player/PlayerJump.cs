using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _jumpForce = 0f;

    public bool IsJump { get; private set; } = false;
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

    public void Jump()
    {
        if (_surfaceDetector.IsDetectGround())
        {
            IsJump = true;
        }
    }
}
