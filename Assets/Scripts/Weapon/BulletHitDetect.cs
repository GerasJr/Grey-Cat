using UnityEngine;
using System.Collections.Generic;

public class BulletHitDetect : MonoBehaviour
{
    [SerializeField] private BloodFX _bloodFX;
    [SerializeField] private ParticleBlood _particleBlood;
    [SerializeField] private List<Enemy> _hitedEnemies = new List<Enemy>();

    private Vector2 _previousPosition;
    private Vector2 _currentPosition;
    private RaycastHit2D _raycast;
    private float _damage = 0f;
    private bool _isFliesThrough;

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
            if (_raycast.collider.TryGetComponent<Enemy>(out Enemy enemy) && enemy.IsDead == false)
            {
                foreach(Enemy enemy1 in _hitedEnemies)
                {
                    if(enemy1 == enemy)
                    {
                        return;
                    }
                }

                enemy.GetDamage(_damage);
                Vector2 bloodPosition = new Vector2(2, 0);
                BloodFX bloodFX = Instantiate(_bloodFX, _raycast.point + bloodPosition, Quaternion.identity);
                Instantiate(_particleBlood, _raycast.point, Quaternion.identity);
                bloodFX.SetRandomSprite();

                if (_isFliesThrough == true)
                {
                    _hitedEnemies.Add(enemy);
                    _damage = _damage / 2;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else if(_raycast.collider.TryGetComponent<Player>(out Player player))
            {
                if (player.gameObject.TryGetComponent<PlayerShield>(out PlayerShield playerShield) && playerShield.IsHaveShield())
                {
                    playerShield.DestroyShield();
                }
                else
                {
                    player.Die();
                }

                Destroy(gameObject);
            }
        }
        catch {}

        _previousPosition = transform.position;
    }

    public void SetSettings(float damage, bool isFliesTrough = false)
    {
        _damage = damage;
        _isFliesThrough = isFliesTrough;
    }
}
