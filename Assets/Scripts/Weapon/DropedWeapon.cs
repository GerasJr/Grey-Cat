using UnityEngine;

public class DropedWeapon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Vector2 _reboundForce;
    [SerializeField] private ParticleBlood _particleBlood;

    private Vector3 _flyDirection = Vector3.right;
    private bool _isHited = false;
    private float _speed = 30f;
    private float _torqueSpeed = 15f;
    private float _zRotation = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(_isHited == false)
        {
            _zRotation = _zRotation - _torqueSpeed;
            transform.rotation = Quaternion.Euler(0, 0, _zRotation);
            transform.position += _flyDirection * _speed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy) && enemy.IsDead == false && _isHited == false)
        {
            enemy.GetDamage(100);
            Instantiate(_particleBlood, collision.ClosestPoint(transform.position), Quaternion.identity);
            _isHited = true;
            Rebound();
        }
    }

    public void SetWeapon(WeaponInfo weaponInfo)
    {
        _spriteRenderer.sprite = weaponInfo.sprite;
        PolygonCollider2D polygonCollider2D = gameObject.AddComponent<PolygonCollider2D>();
        polygonCollider2D.isTrigger = true;
    }

    private void Rebound()
    {
        Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>();
        polygonCollider.isTrigger = false;
        rigidbody2D.AddForce(_reboundForce);
        rigidbody2D.AddTorque(35f);
    }
}
