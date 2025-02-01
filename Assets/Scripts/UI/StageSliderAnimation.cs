using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using DG.Tweening;

public class StageSliderAnimation : MonoBehaviour
{
    [SerializeField] private List<Image> _images = new List<Image>();
    [SerializeField] private List<TMP_Text> _texts = new List<TMP_Text>();

    private Slider _slider;
    private RectTransform _rectTransform;
    private Vector2 _startPosition;
    private float _shiftDuration = 100f;
    private float _moveDuration = 0.5f;
    private float _fadeDuration = 1f;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _rectTransform = GetComponent<RectTransform>();
        _texts.AddRange(GetComponentsInChildren<TMP_Text>());
        _images.AddRange(GetComponentsInChildren<Image>());
        _startPosition = _rectTransform.localPosition;
    }

    public void SetValue(float value)
    {
        _slider.value = value;
    }

    public void SetMinValue(float minValue)
    {
        _slider.minValue = minValue;
    }

    public void SetMaxValue(float maxValue)
    {
        _slider.maxValue = maxValue;
    }

    public void Fade()
    {
        _rectTransform.DOLocalMoveY(_startPosition.y, _moveDuration);

        for (int i = 0; i < _texts.Count; i++)
        {
            _texts[i].DOFade(0, _fadeDuration);
        }

        for (int i = 0; i < _images.Count; i++)
        {
            _images[i].DOFade(0, _fadeDuration);
        }
    }

    public void ShowUp()
    {
        _rectTransform.DOLocalMoveY(_startPosition.y + _shiftDuration, _moveDuration);

        for (int i = 0; i < _texts.Count; i++)
        {
            _texts[i].DOFade(1, _fadeDuration);
        }

        for (int i = 0; i < _images.Count; i++)
        {
            _images[i].DOFade(1, _fadeDuration);
        }
    }
}
