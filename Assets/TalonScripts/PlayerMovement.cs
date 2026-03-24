using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpHeight = 10f;

    private BoxCollider2D coll;

    bool doubleJump;

    [SerializeField] LayerMask jumpableGround;

    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    PlayerUpgrades playerUpgrades;
    Animator animator; 
    bool isKnockedback = false;

    float _movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerUpgrades = GetComponent<PlayerUpgrades>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKnockedback)
        {
            rb2d.linearVelocityX = _movement * movementSpeed;
            if (rb2d.linearVelocity.x > 0.01f)
            {
                transform.GetChild(0).localPosition = new Vector3(0.5f, 0, 0);
             
            }
            else if (rb2d.linearVelocity.x < -0.01f)
            {
                transform.GetChild(0).localPosition = new Vector3(-0.5f, 0, 0);
            }
        }

        animator.SetFloat("XInput", rb2d.linearVelocity.x);

        if (IsGrounded())
        {
            doubleJump = true;
        }

    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1 && IsGrounded() || ctx.ReadValue<float>() == 1 && doubleJump && playerUpgrades.speedLevel > 0)
        {
            rb2d.linearVelocityY = jumpHeight;

            doubleJump = !doubleJump;
        }
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedback = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb2d.linearVelocityX = direction.x * force;
        spriteRenderer.color = Color.red; // Change color to red when knocked back
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        spriteRenderer.color = Color.white; // Change color back to white after knockback
        rb2d.linearVelocityX = Vector2.zero.x;
        isKnockedback = false;
    }

    bool IsGrounded()
    {
         return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
