using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;

public class SliderFadeAnimation : MonoBehaviour
{
    private List<Image> _images = new List<Image>();

    private void Start()
    {
        _images.AddRange(GetComponentsInChildren<Image>());
    }

    public void Fade()
    {
        for(int i = 0; i < _images.Count; i++)
        {
            _images[i].DOFade(0, 2);
        }
    }

    public void ShowUp()
    {
        for (int i = 0; i < _images.Count; i++)
        {
            _images[i].DOFade(1, 2);
        }
    }
}
