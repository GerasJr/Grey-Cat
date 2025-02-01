using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LogoAnimation : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Image _image;
    private Vector2 _startPosition;
    private float _shiftDuration = 300f;
    private float _moveDuration = 0.5f;
    private float _fadeDuration = 1f;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _startPosition = _rectTransform.localPosition;
        ShowUp();
    }

    public void Fade()
    {
        _rectTransform.DOLocalMoveY(_startPosition.y, _moveDuration);
        _image.DOFade(0, _fadeDuration);
    }

    public void ShowUp()
    {
        _rectTransform.DOLocalMoveY(_startPosition.y - _shiftDuration, _moveDuration);
        _image.DOFade(1, _fadeDuration);
    }
}
