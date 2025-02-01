using UnityEngine;

public class PlayerArms : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private DropedWeapon _dropedWeapon;

    private PlayerWeapon _currentWeapon;
    private PlayerMovement _playerMovement;

    public static event OnWeaponState UpdateStateEvent;
    public delegate void OnWeaponState(bool isHaveWeapon);

    private void Start()
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
            UpdateStateEvent.Invoke(true);
            Destroy(weaponItem.gameObject);
        }
    }

    private void DropWeapon(Vector2 direction)
    {
        if (direction == Vector2.right && _currentWeapon != null)
        {
            Vector2 startPosition = new Vector2(_currentWeapon.transform.position.x, _currentWeapon.transform.position.y + 0.3f);

            DropedWeapon dropedWeapon = Instantiate(_dropedWeapon, startPosition, _dropedWeapon.transform.rotation);
            dropedWeapon.SetWeapon(_currentWeapon.GetInfo());
            UpdateStateEvent.Invoke(false);
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

    public bool IsHaveWeapon()
    {
        if(_currentWeapon == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnDestroy()
    {
        SwipeDetection.TapEvent -= Shoot;
        SwipeDetection.SwipeEvent -= DropWeapon;
    }
}
