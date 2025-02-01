using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyInfo", menuName = "EnemyInfo", order = 52)]
public class EnemyInfo : ScriptableObject
{
    [SerializeField] private string _enemyName;
    [SerializeField] private int _id;
    [SerializeField] private float _health;
    [SerializeField] private bool _isHaveWeapon;
    [SerializeField] private bool _isHaveHelmet;

    public string enemyName => this._enemyName;
    public int id => this._id;
    public float health => this._health;
    public bool isHaveWeapon => this._isHaveWeapon;
    public bool isHaveHelmet => this._isHaveHelmet;
}
