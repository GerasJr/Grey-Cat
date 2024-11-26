using UnityEngine;
using System.Collections;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _deadMessage;
    [SerializeField] private TMP_Text _tapMessage;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _firstScreenColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private float _firstScreenDuration;
    [SerializeField] private float _changingDuration;
    [SerializeField] private float _textDuration;

    private void Start()
    {
        SwipeDetection.TapEvent += RestartGame;
        StartCoroutine(StartScreen());
    }

    IEnumerator StartScreen()
    {
        _deadMessage.DOColor(Color.white, _textDuration);
        _tapMessage.DOColor(Color.white, _textDuration);
        yield return new WaitForSeconds(_textDuration);
        _spriteRenderer.DOColor(_firstScreenColor, _firstScreenDuration);
        yield return new WaitForSeconds(_firstScreenDuration);
        _spriteRenderer.DOColor(_endColor, _changingDuration);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        SwipeDetection.TapEvent -= RestartGame;
    }
}
