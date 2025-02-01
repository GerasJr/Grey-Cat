using UnityEngine;
using DG.Tweening;

public class PickUpAnimation : MonoBehaviour
{
    public void StartAnimation()
    {
        transform.DOJump(new Vector2(transform.position.x, transform.position.y + 1), 1, 1, 2);
        GetComponent<SpriteRenderer>().DOFade(0, 2);
    }
}
