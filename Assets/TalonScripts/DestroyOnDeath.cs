using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    public void Dead()
    {
        Destroy(gameObject);
    }
}
