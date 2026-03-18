using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float cameraSpeed = 5f;

    public Vector3 offset;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.fixedDeltaTime * cameraSpeed);
    }

}
