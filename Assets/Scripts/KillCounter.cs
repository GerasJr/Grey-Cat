using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private int _maxCombo = 0;
    private int _comboKills = 0;
    private float _comboCoolDown = 0;
    private float _maxCoolDown = 5;
    private bool _isCounted = false;

    public static event OnUpdateKillCounter UpdateCounterEvent;
    public delegate void OnUpdateKillCounter(int kills,float coolDown);

    private void Awake()
    {
        Enemy.EnemyDieEvent += CountKill;
    }

    private void Update()
    {
        if(_comboCoolDown > 0)
        {
            _comboCoolDown = _comboCoolDown - Time.deltaTime;
        }
        else
        {
            if(_maxCombo < _comboKills)
            {
                _maxCombo = _comboKills;
            }

            _comboCoolDown = 0;
            _comboKills = 0;
            _isCounted = false;
        }

        UpdateCounterEvent.Invoke(_comboKills, _comboCoolDown);
    }

    private void CountKill()
    {
        _comboKills++;
        _comboCoolDown = _maxCoolDown;
        _isCounted = true;
    }
}
