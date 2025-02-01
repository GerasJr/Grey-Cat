using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _moneyCount = 0;

    public int Get(int price)
    {
        _moneyCount = price;
        GetComponent<Booster>().StartDestroyWork();
        GetComponent<Collider2D>().enabled = false;
        return _moneyCount;
    }
}