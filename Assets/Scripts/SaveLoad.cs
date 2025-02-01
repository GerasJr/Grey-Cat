using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveLoad : MonoBehaviour
{
    private string _fileName = "SaveData.json";
    private PlayerData _playerData;
    private string _saveFilePath;

    public static event OnLoadGame LoadEvent;
    public delegate void OnLoadGame(PlayerData playerData);

    void Start()
    {
        List<WeaponInfo> weaponsList = new List<WeaponInfo>();
        _playerData = new PlayerData(0, weaponsList, 0, 0, 0);
        _saveFilePath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + _fileName;
        LoadGame();
        LoadEvent.Invoke(_playerData);
        Wallet.UpdateEvent += SaveWalletInfo;
        Shop.BuyEvent += SaveWeaponsInfo;
        ScoreCounter.SaveScoreEvent += SaveScoreInfo;
    }

    private void SaveWalletInfo(int walletCount)
    {
        _playerData.WalletData = walletCount;
        SaveGame();
    }

    private void SaveWeaponsInfo(WeaponInfo weaponInfo)
    {
        _playerData.WeaponsList.Add(weaponInfo);
        SaveGame();
    }

    private void SaveScoreInfo(int generalScore, int recordScore)
    {
        _playerData.GeneralScore = generalScore;
        _playerData.RecordScore = recordScore;
        SaveGame();
    }

    public void SaveGame()
    {
        string savePlayerData = JsonUtility.ToJson(_playerData);
        File.WriteAllText(_saveFilePath, savePlayerData);

        Debug.Log("Save file created at: " + _saveFilePath);
    }

    public void LoadGame()
    {
        if (File.Exists(_saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(_saveFilePath);
            _playerData = JsonUtility.FromJson<PlayerData>(loadPlayerData);
            Debug.Log("Game Loaded from file " + loadPlayerData);
        }
        else
        {
            //Debug.Log("There is no save files to load!");
        }
    }

    private void OnDestroy()
    {
        Wallet.UpdateEvent -= SaveWalletInfo;
        Shop.BuyEvent -= SaveWeaponsInfo;
        ScoreCounter.SaveScoreEvent -= SaveScoreInfo;
    }
}
