using UnityEngine;
using System.Collections.Generic;

public class StageUpdater : MonoBehaviour
{
    [SerializeField] private StageInfo _currentStage;
    [SerializeField] private List<StageInfo> _stages = new List<StageInfo>(3);

    private ScoreCounter _scoreCounter;

    public static event OnUpdateStage UpdateStageEvent;
    public delegate void OnUpdateStage(StageInfo stageInfo, StageInfo nextStage = null);

    private void Start()
    {
        _scoreCounter = GetComponentInChildren<ScoreCounter>();
        UpdateStageEvent(_currentStage, GetNextStage());
    }

    private StageInfo GetNextStage()
    {
        if(_stages.Count != _currentStage.index + 1)
        {
            return _stages[_currentStage.index + 1];
        }

        return null;
    }

    private void Update()
    {
        if (_stages.Count != _currentStage.index + 1 && _scoreCounter.LevelScore >= _stages[_currentStage.index + 1].scoreToUnlock)
        {
            _currentStage = _stages[_currentStage.index + 1];
            UpdateStageEvent(_currentStage, GetNextStage());
            Debug.Log("stage unlocked");
        }
    }

    public StageInfo GetCurrentStage()
    {
        return _currentStage;
    }
}
