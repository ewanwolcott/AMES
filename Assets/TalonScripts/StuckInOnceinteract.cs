using UnityEngine;

public class StuckInOnceinteract : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StuckInOnce()
    {
        playerRigidbody.linearVelocity = Vector2.zero;
        playerMovement.canMove = false;
    }
}
