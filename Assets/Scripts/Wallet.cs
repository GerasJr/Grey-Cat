using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private KillCounter _killCounter;
    [SerializeField] private StageUpdater _stageUpdater;

    public int MoneyCount { get; private set; } = 0;

    public static event OnUpdateCount UpdateEvent;
    public delegate void OnUpdateCount(int coinsCount);

    private void Awake()
    {
        SaveLoad.LoadEvent += LoadWalletData;
    }

    private void Start()
    {
        UpdateEvent.Invoke(MoneyCount);
    }

    private void LoadWalletData(PlayerData playerData)
    {
        MoneyCount = playerData.WalletData;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            MoneyCount += coin.Get(_stageUpdater.GetCurrentStage().coinPrice);
            UpdateEvent.Invoke(MoneyCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            MoneyCount += coin.Get(_stageUpdater.GetCurrentStage().coinPrice);
            UpdateEvent.Invoke(MoneyCount);
        }
    }

    private void OnDestroy()
    {
        SaveLoad.LoadEvent -= LoadWalletData;
    }

    public void PayForWeapon(WeaponInfo weaponInfo)
    {
        MoneyCount = MoneyCount - weaponInfo.cost;
        UpdateEvent.Invoke(MoneyCount);
    }
}
