using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ShopWeaponInfo : MonoBehaviour
{
    [SerializeField] private Slider _ammoSlider;
    [SerializeField] private Slider _damageSlider;
    [SerializeField] private Slider _fireRateSlider;

    private TMP_Text _ammoText;
    private TMP_Text _damageText;
    private TMP_Text _fireRateText;

    private void Start()
    {
        _ammoText = _ammoSlider.GetComponentInChildren<TMP_Text>();
        _damageText = _damageSlider.GetComponentInChildren<TMP_Text>();
        _fireRateText = _fireRateSlider.GetComponentInChildren<TMP_Text>();
    }

    public void ShowNewInfo(WeaponInfo weaponInfo)
    {
        _ammoText.text = $"Ammo: {weaponInfo.magazineAmount}";
        _damageText.text = $"Damage: {weaponInfo.damage}";
        _fireRateText.text = $"Fire Rate: {weaponInfo.rateOfFire}";
        _ammoSlider.DOValue(weaponInfo.magazineAmount, 0.5f);
        _damageSlider.DOValue(weaponInfo.damage, 0.5f);
        _fireRateSlider.DOValue(_fireRateSlider.maxValue - weaponInfo.rateOfFire, 0.5f);
    }
}
