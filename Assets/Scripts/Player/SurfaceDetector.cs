using UnityEngine;

public class SurfaceDetector : MonoBehaviour
{
    [SerializeField] private Transform CeilingDetector;
    [SerializeField] private Transform GroundDetector;

    private RaycastHit2D _groundRay;
    private RaycastHit2D _ceilingRay;
    private float _rayDistance = 1f;
    private int _layerMask = 1;

    private void Start()
    {
        _layerMask = ~(_layerMask << gameObject.layer) & ~(_layerMask << LayerMask.NameToLayer("Interact Item"));
    }

    public bool IsDetectGround()
    {
        _groundRay = Physics2D.Raycast(GroundDetector.position, Vector2.right, _rayDistance, _layerMask);
        return _groundRay.collider;
    }

    public bool IsCeilingDetect()
    {
        _ceilingRay = Physics2D.Raycast(CeilingDetector.position, Vector2.right, _rayDistance, _layerMask);
        return _ceilingRay.collider;
    }
}
