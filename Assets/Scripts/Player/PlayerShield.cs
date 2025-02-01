using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] ParticleSystem _breakParticles;

    private Coroutine _shieldJob;
    private bool _isHaveShield;

    public static event OnShieldTake ShieldEvent;
    public delegate void OnShieldTake(float coolDown);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.TryGetComponent<Shield>(out Shield shield))
            {
                if (_shieldJob != null)
                {
                    StopCoroutine(_shieldJob);
                }

                float coolDown = shield.GetShield();
                _shieldJob = StartCoroutine(ShieldJob(coolDown));
                ShieldEvent.Invoke(coolDown);
            }
        }
        catch { }
    }

    private IEnumerator ShieldJob(float coolDown)
    {
        _isHaveShield = true;
        yield return new WaitForSeconds(coolDown);
        _isHaveShield = false;
        StopCoroutine(_shieldJob);
    }

    public bool IsHaveShield()
    {
        return _isHaveShield;
    }

    public void DestroyShield()
    {
        if (_isHaveShield == true)
        {
            ShieldEvent.Invoke(0);
            Instantiate(_breakParticles, transform.position, Quaternion.identity);
            StopCoroutine(_shieldJob);
            _isHaveShield = false;
        }
    }
}
