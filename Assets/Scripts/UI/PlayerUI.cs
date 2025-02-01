using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Text _ammo;
    [SerializeField] private Image _weaponIcon;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private TMP_Text _coinsCount;
    [SerializeField] private TMP_Text _levelScore;
    [SerializeField] private TMP_Text _generalScore;
    [SerializeField] private TMP_Text _recordScore;
    [SerializeField] private TMP_Text _stageInfo;
    [SerializeField] private TMP_Text _comboInfo;
    [SerializeField] private Slider _comboSlider;
    [SerializeField] private WeaponPanelAnimation _weaponPanel;
    [SerializeField] private StageSliderAnimation _stageSlider;
    [SerializeField] private List<BoostSliderWork> _boostSliders = new List<BoostSliderWork>();

    private void Awake()
    {
        PlayerWeapon.UpdateEvent += UpdateWeaponInfo;
        PlayerArms.UpdateStateEvent += UpdateWeaponState;
        Wallet.UpdateEvent += UpdateWalletInfo;
        Player.DieEvent += OverGame;
        ScoreCounter.UpdateScoreEvent += UpdateScoreInfo; 
        StageUpdater.UpdateStageEvent += UpdateStageNumber;
        KillCounter.UpdateCounterEvent += UpdateKillCounter;
        PlayerShield.ShieldEvent += UpdateShieldInfo;
        PlayerMovement.SpeedBoostEvent += UpdateSpeedBoostInfo;
    }

    private void Start()
    {
        _weaponPanel.Fade();
        UpdateShieldInfo(0);
        UpdateSpeedBoostInfo(0);
    }

    private void UpdateWeaponInfo(WeaponInfo weaponInfo, int currentAmmo)
    {
        _ammo.text = $"{currentAmmo.ToString()} / {weaponInfo.magazineAmount}";
        _weaponIcon.sprite = weaponInfo.sprite;
        _weaponIcon.SetNativeSize();

        _ammo.color = (float)currentAmmo / (float)weaponInfo.magazineAmount < 0.3 ? Color.red : Color.white;
    }

    private void UpdateWeaponState(bool isHaveWeapon)
    {
        if (isHaveWeapon)
        {
            _weaponPanel.ShowUp();
        }
        else
        {
            _weaponPanel.Fade();
        }
    } 

    private void OverGame()
    {
        Instantiate(_gameOverScreen, transform);
    }

    private void UpdateWalletInfo(int coinsCount)
    {
        _coinsCount.text = coinsCount.ToString();
    }

    private void UpdateScoreInfo(int levelScore, int generalScore, int recordScore)
    {
        _levelScore.text = $"{levelScore.ToString()}";
        _generalScore.text = $"XP {generalScore.ToString()}";
        _recordScore.text = $"R {recordScore.ToString()}";

        _stageSlider.SetValue(levelScore);
    }

    private void UpdateStageNumber(StageInfo stageInfo, StageInfo nextStage)
    {
        _stageInfo.text = $"Stage: {stageInfo.number}";

        if(nextStage != null)
        {
            _stageSlider.SetMaxValue(nextStage.scoreToUnlock);
            _stageSlider.SetMinValue(stageInfo.scoreToUnlock);
        }
    }

    private void UpdateKillCounter(int kills, float coolDown)
    {
        if(kills == 0)
        {
            _comboSlider.GetComponent<SliderFadeAnimation>().Fade();
            _comboInfo.text = "";
        }
        else
        {
            _comboSlider.GetComponent<SliderFadeAnimation>().ShowUp();
            _comboSlider.value = coolDown;
            _comboInfo.text = $"x{kills}";
        }
    }

    private void UpdateShieldInfo(float coolDown)
    {
        for(int i = 0; i < _boostSliders.Count; i++)
        {
            if (_boostSliders[i].IsSpeedBoost())
            {
                continue;
            }
            
            _boostSliders[i].CountDown(coolDown, true);
            break;
        }
    }

    private void UpdateSpeedBoostInfo(float coolDown)
    {
        for (int i = 0; i < _boostSliders.Count; i++)
        {
            if (_boostSliders[i].IsShield())
            {
                continue;
            }

            _boostSliders[i].CountDown(coolDown, false, true);
            break;
        }
    }

    private void OnDestroy()
    {
        PlayerWeapon.UpdateEvent -= UpdateWeaponInfo;
        PlayerArms.UpdateStateEvent -= UpdateWeaponState;
        Wallet.UpdateEvent -= UpdateWalletInfo;
        Player.DieEvent -= OverGame;
        ScoreCounter.UpdateScoreEvent -= UpdateScoreInfo;
        StageUpdater.UpdateStageEvent -= UpdateStageNumber;
        KillCounter.UpdateCounterEvent -= UpdateKillCounter;
        PlayerShield.ShieldEvent -= UpdateShieldInfo;
        PlayerMovement.SpeedBoostEvent -= UpdateSpeedBoostInfo;
    }
}
