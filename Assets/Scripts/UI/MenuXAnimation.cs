using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class MenuXAnimation : MonoBehaviour
{
    [SerializeField] private float _shiftDuration = 310;
    [SerializeField] private float _moveDuration = 0.5f;
    [SerializeField] private float _fadeDuration = 1f;
    [SerializeField] private List<Image> _images = new List<Image>();
    [SerializeField] private List<TMP_Text> _texts = new List<TMP_Text>();

    private RectTransform _rectTransform;
    private Vector2 _startPosition;

    private void Start()
    {
        _texts.AddRange(GetComponentsInChildren<TMP_Text>());
        _images.AddRange(GetComponentsInChildren<Image>());
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.localPosition;
    }

    public void Fade()
    {
        _rectTransform.DOLocalMoveX(_startPosition.x, _moveDuration);

        for(int i = 0; i < _texts.Count; i++)
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
        _rectTransform.DOLocalMoveX(_startPosition.x - _shiftDuration, _moveDuration);

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
