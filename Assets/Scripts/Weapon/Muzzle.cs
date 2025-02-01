using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class Muzzle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _smokeParticle;
    [SerializeField] private Light2D _muzzleFlashLight;
    [SerializeField] private Light2D _muzzleLight;

    private float _smokeParticleTime = 1.5f;
    private float __muzzleFlashTime = 0.07f;
    private Coroutine _smokeParticleJob;
    private Coroutine _muzzleFlashJob;

    private IEnumerator EnableSmoke()
    {
        _smokeParticle.startLifetime = 5f;
        yield return new WaitForSeconds(_smokeParticleTime);
        _smokeParticle.startLifetime = 0f;
        StopCoroutine(_smokeParticleJob);
    }

    private IEnumerator EnableLight()
    {
        _muzzleFlashLight.gameObject.SetActive(true);
        _muzzleLight.gameObject.SetActive(true);
        yield return new WaitForSeconds(__muzzleFlashTime);
        _muzzleFlashLight.gameObject.SetActive(false);
        _muzzleLight.gameObject.SetActive(false);
        StopCoroutine(_muzzleFlashJob);
    }

    public void BlowFX()
    {
        if(_smokeParticleJob != null)
        {
            StopCoroutine(_smokeParticleJob);
        }
        
        if(_muzzleFlashJob != null)
        {
            StopCoroutine(_muzzleFlashJob);
        }

        _muzzleFlashJob = StartCoroutine(EnableLight());
        _smokeParticleJob = StartCoroutine(EnableSmoke());
    }
}
