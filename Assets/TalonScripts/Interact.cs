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

    [SerializeField] GameObject usedText;

    float cooldownTimer = 0f;

    public bool hasItem = false;

    public bool isInteracted = false;

    public void InteractWith(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
            return;

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.zero, 1, boxLayer);
        
        if(hit && hit.collider.TryGetComponent(out Interactable interactable) && !isInteracted && hasItem && interactable.isInteractable)
        {
            interactable.onInteract.Invoke();
            hasItem = false;
            isInteracted = true;
            interactable.isInteractable = false;
            image.GetComponent<Image>().color = new(0, 0, 0, 0);
            itemImage.sprite = null;
        }
        else if(hit && hit.collider.TryGetComponent(out Interactable interactable2) && !isInteracted && !hasItem && cooldownTimer <= 0 && interactable2.isInteractable)
        {
            warningText.SetActive(true);
            cooldownTimer = 2f;
            StartCoroutine(WarningTextCounter(2f));
        }

        else if (hit && hit.collider.TryGetComponent(out Interactable interactable3) && !isInteracted && !hasItem && cooldownTimer <= 0 && !interactable3.isInteractable)
        {
            usedText.SetActive(true);
            cooldownTimer = 2f;
            StartCoroutine(UsedTextCounter(2f));
        }
    }

    IEnumerator WarningTextCounter(float time)
    {
        yield return new WaitForSeconds(time);
        warningText.SetActive(false);
    }

    IEnumerator UsedTextCounter(float time)
    {
        yield return new WaitForSeconds(time);
        usedText.SetActive(false);
    }
    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;

        }
     
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.zero, 1, boxLayer);

        if (hit && hit.collider.TryGetComponent(out Interactable interactable) && !isInteracted && interactable.isInteractable)
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
