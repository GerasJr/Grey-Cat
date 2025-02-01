using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(DestroyBarAnimation))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private DestroyBarAnimation _destroyAnimation;

    private void Start()
    {
        _destroyAnimation = GetComponent<DestroyBarAnimation>();
    }

    public void UpdateBar(float HealthValue)
    {
        _slider.value = HealthValue;
    }

    public void SetMaxValue(float maxValue)
    {
        _slider.maxValue = maxValue;
    }

    public void DestroyBar()
    {
        StartCoroutine(DestroyAnimWork());
    }

    private IEnumerator DestroyAnimWork()
    {
        _destroyAnimation.StartAnimation();
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
