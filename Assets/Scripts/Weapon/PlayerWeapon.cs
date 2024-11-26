using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private WeaponInfo _weaponInfo;

    public static event OnAmmoUpdate UpdateEvent;
    public delegate void OnAmmoUpdate(WeaponInfo weaponInfo, int currentAmmo);
    private Animator _animator;
    private Muzzle _muzzle;
    private SpriteRenderer _spriteRenderer;
    private Coroutine _rollBackJob;
    private int _currentAmmo = 0;
    private bool _isRollBack = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _muzzle = GetComponentInChildren<Muzzle>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentAmmo = _weaponInfo.magazineAmount;
        UpdateEvent?.Invoke(_weaponInfo, _currentAmmo);
    }

    public void Shoot()
    {
        if(_currentAmmo > 0 && _isRollBack == false)
        {
            if (_weaponInfo.isShotgun == true)
            {
                float distance = 10;
                int shells = 9;
                float angleRange = 40;
                float angle;
                Vector2 direction;
                RaycastHit2D hit;

                for(int i = 0; i < shells; i++)
                {
                    angle = angleRange / 2 - Random.Range(0, angleRange);
                    direction = new Vector2(Vector2.right.x, angle / 100);
                    hit = Physics2D.Raycast(_muzzle.transform.position, direction, distance);
                    Debug.DrawLine(_muzzle.transform.position, (Vector2)_muzzle.transform.position + direction * distance, Color.green, 5);

                    try
                    {
                        if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                        {
                            enemy.GetDamage(_weaponInfo.damage / shells);
                        }
                    }
                    catch { };
                }
            }
            else
            {
                Bullet bullet = Instantiate(_bullet, _muzzle.transform.position, _bullet.transform.rotation);
                bullet.GetComponent<BulletHitDetect>().SetDamage(_weaponInfo.damage);
            }

            ShootAnimation();
            --_currentAmmo;
            UpdateEvent?.Invoke(_weaponInfo, _currentAmmo);

            if (_rollBackJob != null)
            {
                StopCoroutine(_rollBackJob);
            }

            _rollBackJob = StartCoroutine(RollBack());
        }
    }

    private IEnumerator RollBack()
    {
        _isRollBack = true;
        yield return new WaitForSeconds(_weaponInfo.rateOfFire);
        _isRollBack = false;
    }

    public void SetNewWeapon(WeaponInfo weaponInfo)
    {
        _weaponInfo = weaponInfo;
        _currentAmmo = _weaponInfo.magazineAmount;
        _spriteRenderer.sprite = _weaponInfo.spriteInArms;
        GetComponentInParent<PlayerArms>().transform.localPosition = _weaponInfo.armsPosition;
        _muzzle.transform.localPosition = weaponInfo.muzzlePosition;
        UpdateEvent?.Invoke(_weaponInfo, _currentAmmo);
    }

    public WeaponInfo GetInfo()
    {
        return _weaponInfo;
    }

    private void ShootAnimation()
    {
        _animator.Rebind();
        _animator.SetTrigger("Tapped");
    }
}
