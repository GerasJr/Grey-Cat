using UnityEngine;

public class BulletHitDetect : MonoBehaviour
{
    private Vector2 _previousPosition;
    private Vector2 _currentPosition;
    private RaycastHit2D _raycast;
    private float _damage = 0f;

    private void Awake()
    {
        _previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        _currentPosition = transform.position;
        _raycast = Physics2D.Raycast(_currentPosition, _previousPosition, Vector2.Distance(_currentPosition, _previousPosition));

        try
        {
            if (_raycast.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.GetDamage(_damage);
                Destroy(gameObject);
            }
        }
        catch {}

        _previousPosition = transform.position;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}
