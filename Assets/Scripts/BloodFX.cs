using UnityEngine;
using System.Collections.Generic;

public class BloodFX : MonoBehaviour
{
    [SerializeField] private List<Sprite> _spritesFX = new List<Sprite>();

    public void SetRandomSprite()
    {
        GetComponent<SpriteRenderer>().sprite = _spritesFX[Random.Range(0, _spritesFX.Count)];
    }
}
