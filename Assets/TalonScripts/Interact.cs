using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Vector2 boxSize;
    public LayerMask boxLayer;

    private Collider2D _currentHitCollider;

    [SerializeField] Image itemImage;

    [SerializeField] GameObject image;

    [SerializeField] GameObject warningText;

    float cooldownTimer = 0f;

    public bool hasItem = false;

    private bool isInteracted = false;

    public void InteractWith(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
            return;

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.zero, 1, boxLayer);
        
        if(hit && hit.collider.TryGetComponent(out Interactable interactable) && !isInteracted && hasItem)
        {
            interactable.onInteract.Invoke();
            hasItem = false;
            isInteracted = true;
            image.SetActive(false);
            itemImage.sprite = null;
        }
        else if(hit && hit.collider.TryGetComponent(out Interactable interactable2) && !isInteracted && !hasItem && cooldownTimer <= 0)
        {
            warningText.SetActive(true);
            cooldownTimer = 2f;
            StartCoroutine(WarningTextCounter(2f));
        }
    }

    IEnumerator WarningTextCounter(float time)
    {
        yield return new WaitForSeconds(time);
        warningText.SetActive(false);
    }
    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;

        }
     
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
