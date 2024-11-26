using UnityEngine;
using System.Collections.Generic;

public class WeaponItem : MonoBehaviour
{
    [SerializeField] public List<WeaponInfo> _weaponInfo = new List<WeaponInfo>();

    private int _index = 0;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _weaponInfo[_index].sprite;
    }

    public void SetRandom()
    {
        _index = Random.Range(0, _weaponInfo.Count);
    }

    public WeaponInfo GetWeapon()
    {
        return _weaponInfo[_index];
    }

    public bool IsHaveWeapon(WeaponInfo selectedWeapon)
    {
        return _weaponInfo.Contains(selectedWeapon);
    }

    public void AddWeapon(WeaponInfo weaponInfo)
    {
        _weaponInfo.Add(weaponInfo);
    }
}
