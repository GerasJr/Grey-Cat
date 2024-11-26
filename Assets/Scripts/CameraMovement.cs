using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _leftEdge;
    [SerializeField] private float _distanceFromEdge;
    [SerializeField] private float _smoothTime = .10f;
    [SerializeField] private bool _inMainMenu = true;

    private UnityEngine.Camera _camera;
    private float _distanceEdgeToPlayer;
    private float _positionX;
    private float _smoothSize = 3.682135f;
    private float _menuSmoothSize = 2f;
    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        Application.targetFrameRate = 90;
    }

    private void Start()
    {
        _camera = UnityEngine.Camera.main;

        if (_inMainMenu)
        {
            transform.position = new Vector3(_player.position.x, _player.position.y, -10);
            _camera.orthographicSize = _menuSmoothSize;
        }
    }

    private void Update()
    {
        if (_inMainMenu == false)
        {
            _distanceEdgeToPlayer = _player.position.x - _leftEdge.position.x;
            _positionX = transform.position.x + _distanceEdgeToPlayer - _distanceFromEdge;
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_positionX, Mathf.Clamp(_player.position.y, 0.5f, 1.5f), -10), ref _velocity, _smoothTime);
        }
    }

    public void EnableRunCamera()
    {
        _inMainMenu = false;
        _camera.orthographicSize = Mathf.MoveTowards(_menuSmoothSize, _smoothSize, 3);
    }

    public void EnableMagazineCamera(bool isEnable)
    {
        if(isEnable == true)
        {
            transform.DOMove(new Vector3(_player.position.x + 1.5f, _player.position.y, -10), _smoothTime);
        }
        else
        {
            transform.DOMove(new Vector3(_player.position.x, _player.position.y, -10), _smoothTime);
        }
    }
}
