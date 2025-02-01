using UnityEngine;

public class DeliteOutOfCamera : MonoBehaviour
{
    private UnityEngine.Camera camera;

    private void Start()
    {
        camera = UnityEngine.Camera.main;
    }

    private void Update()
    {
        Vector3 viewPos = camera.WorldToViewportPoint(transform.position);

        if (!(viewPos.x >= -1 && viewPos.x <= 1.5 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0))
        {
            Destroy(gameObject);
        }
    }
}
