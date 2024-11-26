using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private PlayerArms _playerArms;
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private WeaponItem _weaponItem;
    [SerializeField] private Button _buyButton;

    private PlayerWeapon _currentPlayerWeapon;
    private WeaponInfo _selectedWeapon;

    public void ShowWeapon(WeaponInfo weaponInfo)
    {
        if (_currentPlayerWeapon != null)
        {
            Destroy(_currentPlayerWeapon.gameObject);
        }

        _selectedWeapon = weaponInfo;
        _currentPlayerWeapon = Instantiate(_playerWeapon, _playerArms.transform);
        _currentPlayerWeapon.SetNewWeapon(weaponInfo);
        _buyButton.gameObject.SetActive(true);

        if (_weaponItem.IsHaveWeapon(_selectedWeapon))
        {
            _buyButton.GetComponentInChildren<TMP_Text>().text = "Buyed";
        }
        else
        {
            _buyButton.GetComponentInChildren<TMP_Text>().text = weaponInfo.cost.ToString();
        }
    }

    public void RemoveShowWeapon()
    {
        if (_currentPlayerWeapon != null)
        {
            Destroy(_currentPlayerWeapon.gameObject);
        }

        _selectedWeapon = null;
        _buyButton.gameObject.SetActive(false);
    }

    public void BuyWeapon()
    {
        if (_selectedWeapon != null && _weaponItem.IsHaveWeapon(_selectedWeapon) == false)
        {
            _weaponItem.AddWeapon(_selectedWeapon);
            _buyButton.GetComponentInChildren<TMP_Text>().text = "Buyed";
        }
    }
}
