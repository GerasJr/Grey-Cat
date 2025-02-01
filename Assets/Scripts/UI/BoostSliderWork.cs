using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoostSliderWork : MonoBehaviour
{
    [SerializeField] private Sprite _shieldSprite;
    [SerializeField] private Sprite _speedBoostSprite;
    [SerializeField] private Image _boosterImage;

    private SliderFadeAnimation _sliderFadeAnimation;
    private Slider _slider;
    private float _value;
    private float _currentTime = 0;
    private bool _isWork = false;
    private bool _isShield = false;
    private bool _isSpeedBoost = false;

    private void Start()
    {
        _sliderFadeAnimation = GetComponent<SliderFadeAnimation>();
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (_isWork == true)
        {
            if (_currentTime >= _value)
            {
                _sliderFadeAnimation.Fade();
                _isShield = false;
                _isSpeedBoost = false;
                _isWork = false;
                _currentTime = 0;
                return;
            }

            _currentTime = _currentTime + Time.deltaTime;
            _slider.maxValue = _value;
            _slider.value = _value - _currentTime;
        }
    }

    public void CountDown(float value, bool isShield = false, bool isSpeedBoost = false)
    {
        if(value > 0)
        {
            _isShield = isShield;
            _isSpeedBoost = isSpeedBoost;
            _sliderFadeAnimation.ShowUp();
            _isWork = true;
            _value = value;
            _currentTime = 0;

            _boosterImage.sprite = isShield ? _shieldSprite : _speedBoostSprite;
        }
        else
        {
            _sliderFadeAnimation.Fade();
            _isShield = false;
            _isSpeedBoost = false;
        }
    }

    public bool IsWork()
    {
        return _isWork;
    }

    public bool IsShield()
    {
        return _isShield;
    }

    public bool IsSpeedBoost()
    {
        return _isSpeedBoost;
    }
}
