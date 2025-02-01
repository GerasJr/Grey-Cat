using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponInfo", menuName = "Weapon Info", order = 51)]
public class WeaponInfo : ScriptableObject
{
    [SerializeField] private string _weaponName;
    [SerializeField] private int _id;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _spriteInArms;
    [SerializeField] private Vector2 _armsPosition;
    [SerializeField] private Vector2 _muzzlePosition;
    [SerializeField] private float _damage;
    [SerializeField] private int _magazineAmount;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private int _cost;
    [SerializeField] private bool _isShotgun;
    [SerializeField] private bool _isShootingThrough;

    public string weaponName => this._weaponName;
    public int id => this._id;
    public Sprite sprite => this._sprite;
    public Sprite spriteInArms => this._spriteInArms;
    public Vector2 armsPosition => this._armsPosition;
    public Vector2 muzzlePosition => this._muzzlePosition;
    public float damage => this._damage;
    public int magazineAmount => this._magazineAmount;
    public float rateOfFire => this._rateOfFire;
    public int cost => this._cost;
    public bool isShotgun => this._isShotgun;
    public bool isShootingThrough => this._isShootingThrough;
}
