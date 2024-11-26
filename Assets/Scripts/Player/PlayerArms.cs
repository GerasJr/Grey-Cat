using UnityEngine;

public class PlayerArms : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private DropedWeapon _dropedWeapon;

    private PlayerWeapon _currentWeapon;
    private PlayerMovement _playerMovement;

    void Start()
    {
        SwipeDetection.TapEvent += Shoot;
        SwipeDetection.SwipeEvent += DropWeapon;
        _playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<WeaponItem>(out WeaponItem weaponItem) && _currentWeapon == null)
        {
            _currentWeapon = Instantiate(_playerWeapon, transform);
            _currentWeapon.SetNewWeapon(weaponItem.GetWeapon());
            Destroy(weaponItem.gameObject);
        }
    }

    private void DropWeapon(Vector2 direction)
    {
        if (direction == Vector2.right && _currentWeapon != null)
        {
            DropedWeapon dropedWeapon = Instantiate(_dropedWeapon, _currentWeapon.transform.position, _dropedWeapon.transform.rotation);
            dropedWeapon.SetWeapon(_currentWeapon.GetInfo());
            Destroy(_currentWeapon.gameObject);
        }
    }

    private void Shoot()
    {
        if (GetComponentInChildren<PlayerWeapon>() && _playerMovement.enabled)
        {
            _currentWeapon = GetComponentInChildren<PlayerWeapon>();
            _currentWeapon.Shoot();
        }
    }

    private void OnDestroy()
    {
        SwipeDetection.TapEvent -= Shoot;
        SwipeDetection.SwipeEvent -= DropWeapon;
    }
}
