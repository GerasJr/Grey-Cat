using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private float _boost = 1.5f;
    private float _coolDown = 5f;

    public float GetBoost(ref float coolDown)
    {
        coolDown = _coolDown;
        GetComponent<Booster>().StartDestroyWork();
        return _boost;
    }
}
