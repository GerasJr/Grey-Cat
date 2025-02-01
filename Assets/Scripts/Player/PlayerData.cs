using UnityEngine;
using System.Collections.Generic;

public class PlayerData
{
    public int WalletData;
    public List<WeaponInfo> WeaponsList = new List<WeaponInfo>();
    public int GeneralScore;
    public int RecordScore;
    public int StageIndex;

    public PlayerData(int walletData, List<WeaponInfo> weaponsList, int generalScore, int recordScore, int stageIndex)
    {
        WalletData = walletData;
        WeaponsList = weaponsList;
        GeneralScore = generalScore;
        RecordScore = recordScore;
        StageIndex = stageIndex;
    }
}
