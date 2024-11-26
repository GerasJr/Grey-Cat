using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _moneyCount = 10;

    public int Get()
    {
        Destroy(this.gameObject);
        return _moneyCount;
    }
}
