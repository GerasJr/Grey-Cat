using UnityEngine;

public class Shell : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(new Vector2(transform.position.x -1, transform.position.y + 1) * 10);
        _rigidbody.AddTorque(0);
    }
}
