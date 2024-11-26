using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Coin _coin; 

    private HealthBar _healthBar;
    private Animator _animator;
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody;
    private float _health = 100;
    private bool _isDead = false;

    private void Start()
    {
        _healthBar = GetComponentInChildren<HealthBar>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Die()
    {
        DropCoins();
        _animator.SetTrigger("Die");
        _healthBar.DestroyBar();
        _boxCollider.isTrigger = true;
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        _isDead = true;
    }

    private void DropCoins()
    {
        for(int i = 0; i < 3; i++)
        {
            Coin coin = Instantiate(_coin, transform.position, Quaternion.identity);
            float vectorX = Random.Range(-100, 100);
            coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(vectorX, 100));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player) && _isDead == false)
        {
            player.Die();
        }
    }

    public void GetDamage(float damage)
    {
        if(_isDead == false)
        {
            _health = _health - damage;
            _healthBar.UpdateBar(_health);

            if (_health <= 0)
            {
                Die();
            }
        }
    }
}
