using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void UpdateBar(float HealthValue)
    {
        _slider.value = HealthValue;
    }

    public void DestroyBar()
    {
        Destroy(gameObject);
    }
}
