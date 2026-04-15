using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public float shootCooldown = 2f;

    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > shootCooldown)
        {
            timer = 0;
            shoot();
        }
    }
    void shoot()
    {         
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
