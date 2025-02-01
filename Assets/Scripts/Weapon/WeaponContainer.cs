using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
    [SerializeField] public List<WeaponInfo> _weaponsList = new List<WeaponInfo>();

    private void Awake()
    {
        SaveLoad.LoadEvent += LoadWeaponList;
    }

    private void LoadWeaponList(PlayerData playerData)
    {
        _weaponsList.Clear();
        _weaponsList.AddRange(playerData.WeaponsList);
    }

    public WeaponInfo GetWeapon(int index)
    {
        return _weaponsList[index];
    }

    public int GetWeaponsCount()
    {
        return _weaponsList.Count;
    }

    public bool IsHaveWeapon(WeaponInfo selectedWeapon)
    {
        return _weaponsList.Contains(selectedWeapon);
    }

    public void AddWeapon(WeaponInfo weaponInfo)
    {
        _weaponsList.Add(weaponInfo);
    }

    private void OnDestroy()
    {
        SaveLoad.LoadEvent -= LoadWeaponList;
    }
}
