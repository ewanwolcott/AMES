using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public Vector2 boxSize;
    public LayerMask boxLayer;

    private Collider2D _currentHitCollider;

    private bool isInteracted = false;

    public void InteractWith(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
            return;

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.zero, 1, boxLayer);
        
        if(hit && hit.collider.TryGetComponent(out Interactable interactable) && !isInteracted)
        {
            interactable.onInteract.Invoke();
            isInteracted = true;
        }
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.zero, 1, boxLayer);

        if (hit && hit.collider.TryGetComponent(out Interactable interactable) && !isInteracted)
        {
            hit.collider.GetComponent<Interactable>().interactPrompt.SetActive(true);
            _currentHitCollider = hit.collider;
        }
        else
        {
            if(_currentHitCollider != null)
                _currentHitCollider.GetComponent<Interactable>().interactPrompt.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
