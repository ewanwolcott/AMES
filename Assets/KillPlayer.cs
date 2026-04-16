using Unity.Cinemachine;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.TakeDamage(99999999);
        }

    }
}
