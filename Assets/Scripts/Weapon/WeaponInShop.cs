using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponInShop : MonoBehaviour
{
    [SerializeField] private WeaponInfo _weaponInfo;

    private Button _button;
    private Shop _shop;
    private Image _image;
    private TMP_Text _text;

    private void Start()
    {
        _image = GetComponentInChildren<Image>();
        _image.sprite = _weaponInfo.sprite;
        _image.SetNativeSize();
        _shop = GetComponentInParent<Shop>();
        _button = GetComponentInChildren<Button>();
        _text = GetComponentInChildren<TMP_Text>();
        _text.text = _weaponInfo.weaponName;
        _button.onClick.AddListener(Visualize);
    }

    private void Visualize()
    {
        _shop.ShowWeapon(_weaponInfo);
    }
}
