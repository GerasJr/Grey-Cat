using UnityEngine;

public class EnemyHelmet : MonoBehaviour
{
    [SerializeField] private Vector2 _reboundForce;

    private Rigidbody2D _rigidbody;
    private PolygonCollider2D _collider;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<PolygonCollider2D>();
    }

    public void Drop()
    {
        transform.SetParent(null);
        _collider.enabled = true;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.AddForce(_reboundForce);
        _rigidbody.AddTorque(-15);
    }
}
