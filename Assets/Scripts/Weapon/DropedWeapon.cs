using UnityEngine;

public class DropedWeapon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Vector2 _reboundForce;

    private UnityEngine.Camera camera;
    private Vector3 _flyDirection = Vector3.right;
    private bool _isHited = false;
    private float _speed = 30f;

    private void Start()
    {
        camera = UnityEngine.Camera.main;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 viewPos = camera.WorldToViewportPoint(transform.position);

        if(!(viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(_isHited == false)
        {
            transform.position += _flyDirection * _speed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy) && _isHited == false)
        {
            enemy.GetDamage(100);
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
    }
}
