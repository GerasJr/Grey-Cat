using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private PlayerArms _playerArms;
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private WeaponContainer _weaponContainer;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ShopWeaponInfo _shopWeaponInfo;

    private PlayerWeapon _currentPlayerWeapon;
    private WeaponInfo _selectedWeapon;

    public static event OnBuyingWeapon BuyEvent;
    public delegate void OnBuyingWeapon(WeaponInfo weaponInfo);

    public void ShowWeapon(WeaponInfo weaponInfo)
    {
        if (_currentPlayerWeapon != null)
        {
            Destroy(_currentPlayerWeapon.gameObject);
        }

        _selectedWeapon = weaponInfo;
        _currentPlayerWeapon = Instantiate(_playerWeapon, _playerArms.transform);
        _currentPlayerWeapon.SetNewWeapon(weaponInfo);

        //_buyButton.gameObject.SetActive(true);
        _buyButton.GetComponent<MenuXAnimation>().ShowUp();

        _shopWeaponInfo.ShowNewInfo(weaponInfo);
        _shopWeaponInfo.GetComponent<MenuXAnimation>().ShowUp();

        if (_weaponContainer.IsHaveWeapon(_selectedWeapon))
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
        //_buyButton.gameObject.SetActive(false);
        _buyButton.GetComponent<MenuXAnimation>().Fade();
        _shopWeaponInfo.GetComponent<MenuXAnimation>().Fade();
    }

    public void BuyWeapon()
    {
        if (_selectedWeapon != null && _weaponContainer.IsHaveWeapon(_selectedWeapon) == false)
        {
            if(_wallet.MoneyCount >= _selectedWeapon.cost)
            {
                _wallet.PayForWeapon(_selectedWeapon);
                _weaponContainer.AddWeapon(_selectedWeapon);
                _buyButton.GetComponentInChildren<TMP_Text>().text = "Buyed";
                BuyEvent.Invoke(_selectedWeapon);
            }
        }
    }
}
