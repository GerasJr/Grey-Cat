using UnityEngine;
using System.Collections.Generic;

public class WeaponItem : MonoBehaviour
{
    [SerializeField] private WeaponInfo _currentWeaponInfo;

    private void Start()
    {
        if(_currentWeaponInfo != null)
        {
            GetComponent<SpriteRenderer>().sprite = _currentWeaponInfo.sprite;
        }
    }

    public void SetNewInfo(WeaponInfo weaponInfo)
    {
        _currentWeaponInfo = weaponInfo;
        GetComponent<SpriteRenderer>().sprite = weaponInfo.sprite;
    }

    public WeaponInfo GetWeapon()
    {
        return _currentWeaponInfo;
    }
}
