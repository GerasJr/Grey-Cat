using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Player _player;

    public int LevelScore { get; private set; } = 0;
    public int GeneralScore { get; private set; } = 0;
    public int RecordScore { get; private set; } = 0;
    private Vector2 _startPosition;
    private int _initalGeneralScore = 0;

    public static event OnSaveScore SaveScoreEvent;
    public delegate void OnSaveScore(int generalScore, int recordScore);

    public static event OnUpdateScore UpdateScoreEvent;
    public delegate void OnUpdateScore(int levelScore, int generalScore, int recordScore);

    private void Awake()
    {
        SaveLoad.LoadEvent += LoadScoreInfo;
        Player.DieEvent += SaveOnDie;
    }

    private void Start()
    {
        _startPosition = _player.transform.position;
        _initalGeneralScore = GeneralScore;
    }

    private void Update()
    {
        LevelScore = (int)_player.transform.position.x - (int)_startPosition.x;
        GeneralScore = _initalGeneralScore + LevelScore;

        if(RecordScore < LevelScore)
        {
            RecordScore = LevelScore;
        }

        UpdateScoreEvent(LevelScore, GeneralScore, RecordScore);
    }

    private void SaveOnDie()
    {
        SaveScoreEvent.Invoke(GeneralScore, RecordScore);
    }

    private void LoadScoreInfo(PlayerData playerData)
    {
        GeneralScore = playerData.GeneralScore;
        RecordScore = playerData.RecordScore;
    }

    private void OnDestroy()
    {
        SaveLoad.LoadEvent -= LoadScoreInfo;
        Player.DieEvent -= SaveOnDie;
    }
}
