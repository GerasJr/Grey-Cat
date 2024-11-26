using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Text _ammo;
    [SerializeField] private Image _weaponIcon;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private TMP_Text _coinsCount;

    private void Start()
    {
        PlayerWeapon.UpdateEvent += UpdateInfo;
        Wallet.PickUpEvent += UpdateWalletInfo;
        Player.DieEvent += OverGame;
    }

    private void UpdateInfo(WeaponInfo weaponInfo, int currentAmmo)
    {
        _ammo.text = $"{currentAmmo.ToString()} / {weaponInfo.magazineAmount}";
        _weaponIcon.sprite = weaponInfo.sprite;
        _weaponIcon.SetNativeSize();
    }

    private void OverGame()
    {
        Instantiate(_gameOverScreen, transform);
    }

    private void UpdateWalletInfo(int coinsCount)
    {
        _coinsCount.text = coinsCount.ToString();
    }

    private void OnDestroy()
    {
        PlayerWeapon.UpdateEvent -= UpdateInfo;
        Player.DieEvent -= OverGame;
    }
}
