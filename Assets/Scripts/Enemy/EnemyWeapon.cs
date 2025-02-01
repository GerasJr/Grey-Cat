using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    private Animator _animator;
    private Muzzle _muzzle;
    private RaycastHit2D _raycast;
    private Vector2 _direction = Vector2.left;
    private float _shootDistance = 4.5f;
    private bool _shotFired = false;

    private void Start()
    {
        _muzzle = GetComponentInChildren<Muzzle>();
    }

    private void Update()
    {
        if(_shotFired == false)
        {
            _raycast = Physics2D.Raycast(_muzzle.transform.position, _direction, _shootDistance);

            try
            {
                if (_raycast.collider.gameObject.TryGetComponent<Player>(out Player player))
                {
                    Shoot();
                    _shotFired = true;
                }
            }
            catch { };
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bullet, _muzzle.transform.position, _bullet.transform.rotation);
        bullet.SetDirection(_direction);
    }
}
