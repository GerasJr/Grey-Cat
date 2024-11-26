using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _moneyCount = 0;

    public static event OnPickUp PickUpEvent;
    public delegate void OnPickUp(int coinsCount);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            _moneyCount += coin.Get();
            PickUpEvent.Invoke(_moneyCount);
        }
    }
}
