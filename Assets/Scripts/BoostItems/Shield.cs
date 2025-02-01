using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    private float _coolDown = 10f;

    public float GetShield()
    {
        GetComponent<Booster>().StartDestroyWork();
        return _coolDown;
    }
}
