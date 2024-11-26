using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Quaternion _rotation = Quaternion.Euler(0, 0, -90);
    private Vector3 _direction = Vector2.right;
    private float _speed = 100f;
    private UnityEngine.Camera camera;

    private void Start()
    {
        camera = UnityEngine.Camera.main;
    }

    void Update()
    {
        Vector3 viewPos = camera.WorldToViewportPoint(transform.position);

        if (!(viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
