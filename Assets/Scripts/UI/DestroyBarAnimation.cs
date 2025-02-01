using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DestroyBarAnimation : MonoBehaviour
{
    public void StartAnimation()
    {
        transform.DOMoveX(transform.position.x + 3, 2f);
        GetComponent<SpriteRenderer>().DOFade(0, 0.5f);
        GetComponentInChildren<Image>().DOFade(0, 0.5f);
    }
}
