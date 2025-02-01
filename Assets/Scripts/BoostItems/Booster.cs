using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PickUpAnimation))]
public class Booster : MonoBehaviour
{
    private PickUpAnimation _pickUpAnimation;

    private void Start()
    {
        _pickUpAnimation = GetComponent<PickUpAnimation>();
    }

    public void StartDestroyWork()
    {
        StartCoroutine(DestroyAnimWork());
    }

    private IEnumerator DestroyAnimWork()
    {
        _pickUpAnimation.StartAnimation();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
