using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction = Vector2.right;
    private float _speed = 100f;

    private void FixedUpdate()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}
