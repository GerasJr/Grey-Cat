using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New StageInfo", menuName = "StageInfo", order = 53)]
public class StageInfo : ScriptableObject
{
    [SerializeField] private int _index;
    [SerializeField] private int _number;
    [SerializeField] private int _scoreToUnlock;
    [SerializeField] private List<WeaponInfo> _weapons;
    [SerializeField] private List<EnemyInfo> _enemies;
    [SerializeField] private int _enemiesOnChunk;
    [SerializeField] private float _enemyNextSpawnMultiplier;
    [SerializeField] private int _weaponsOnChunk;
    [SerializeField] private int _coinPrice;
    [SerializeField] private int _diePenalty;

    public int index => this._index;
    public int number => this._number;
    public int scoreToUnlock => this._scoreToUnlock;
    public List<WeaponInfo> weapons => this._weapons;
    public List<EnemyInfo> enemies => this._enemies;
    public int enemiesOnChunk => this._enemiesOnChunk;
    public float enemyNextSpawnMultiplier => this._enemyNextSpawnMultiplier;
    public int weaponsOnChunk => this._weaponsOnChunk;
    public int coinPrice => this._coinPrice;
    public int diePenalty => this._diePenalty;
}
