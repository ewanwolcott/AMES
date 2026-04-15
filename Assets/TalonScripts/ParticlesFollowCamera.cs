using UnityEngine;

public class ParticlesFollowCamera : MonoBehaviour
{
    public GameObject target;

    private void FixedUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
    }
}
