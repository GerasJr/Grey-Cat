using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class WeaponPanelAnimation : MonoBehaviour
{
    [SerializeField] private List<Image> _images = new List<Image>();
    [SerializeField] private Text text;

    private float _shiftDuration = 110;
    private RectTransform _rectTransform;
    private Vector2 _startPosition;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.localPosition;
    }

    public void Fade()
    {
        _rectTransform.DOLocalMoveY(_startPosition.y, 1);
        text.DOFade(0, 1);

        for (int i = 0; i < _images.Count; i++)
        {
            _images[i].DOFade(0, 1);
        }
    }

    public void ShowUp()
    {
        _rectTransform.DOLocalMoveY(_startPosition.y - _shiftDuration, 1);
        text.DOFade(1, 1);

        for (int i = 0; i < _images.Count; i++)
        {
            _images[i].DOFade(1, 1);
        }
    }
}
