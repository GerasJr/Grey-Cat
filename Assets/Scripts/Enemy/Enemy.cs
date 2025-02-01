using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private EnemyWeapon _weapon;
    [SerializeField] private EnemyHelmet _helmet;
    [SerializeField] private EnemyInfo _enemyInfo;
    [SerializeField] private HealthBar _healthBar;

    public bool IsDead { get; private set; } = false;
    private bool _isHaveHelmet;
    private Animator _animator;
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody;
    private float _health = 100;
    private int _coinsToDrop = 0;
    private int _maxCoinsToDrop = 5;

    public static event OnDie EnemyDieEvent;
    public delegate void OnDie();

    private void Awake()
    {
        KillCounter.UpdateCounterEvent += CountCoins;
    }

    private void Start()
    {
        _healthBar = GetComponentInChildren<HealthBar>();
        _helmet = GetComponentInChildren<EnemyHelmet>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Die()
    {
        EnemyDieEvent.Invoke();
        _animator.SetTrigger("Die");
        _weapon.gameObject.SetActive(false);
        _healthBar.DestroyBar();
        _boxCollider.isTrigger = true;
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        IsDead = true;
        DropCoins(Mathf.Clamp(_coinsToDrop, 0, _maxCoinsToDrop));

        if(_isHaveHelmet == true)
        {
            _helmet.Drop();
        }
    }

    private void DropCoins(int coinsToDrop)
    {
        for(int i = 0; i < coinsToDrop; i++)
        {
            Coin coin = Instantiate(_coin, transform.position, Quaternion.identity);
            float vectorX = Random.Range(-100, 100);
            coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(vectorX, 100));
        }
    }

    private void CountCoins(int kills, float coolDown)
    {
        _coinsToDrop = kills;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player) && IsDead == false)
        {
            BoxCollider2D playerCollider = player.GetComponent<BoxCollider2D>();
            float lowerPlayerSideY = playerCollider.bounds.center.y - playerCollider.size.y / 2;
            float higherEnemySideY = _boxCollider.bounds.center.y + _boxCollider.size.y * 0.4f;

            if (lowerPlayerSideY > higherEnemySideY)
            {
                this.Die();
            }
            else if(player.transform.position.x < transform.position.x)
            {
                if (player.gameObject.TryGetComponent<PlayerShield>(out PlayerShield playerShield) && playerShield.IsHaveShield())
                {
                    playerShield.DestroyShield();
                    this.Die();
                }
                else
                {
                    player.Die();
                }
            }
        }
    }

    public void GetDamage(float damage)
    {
        if(IsDead == false)
        {
            _health = _health - damage;
            _healthBar.UpdateBar(_health);

            if (_health <= 0)
            {
                Die();
            }
        }
    }

    public void SetNewInfo(EnemyInfo enemyInfo)
    {
        _enemyInfo = enemyInfo;
        _health = _enemyInfo.health;
        _healthBar.SetMaxValue(_enemyInfo.health);
        _healthBar.UpdateBar(_health);
        _weapon.gameObject.SetActive(_enemyInfo.isHaveWeapon);
        _helmet.gameObject.SetActive(_enemyInfo.isHaveHelmet);
        _isHaveHelmet = enemyInfo.isHaveHelmet;
    }
}
